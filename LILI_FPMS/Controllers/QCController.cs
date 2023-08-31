using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using LILI_FPMS;
using LILI_FPMS.Models;
using LILI_IMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NPOI.SS.Formula.Eval;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using Org.BouncyCastle.Ocsp;

namespace LILI_IMS.Controllers
{

    [Authorize]
    public class QCController : Controller
    {
        private readonly dbFormulationProductionSystemContext _context;
        private static string SECTION_CODE;

        private readonly IHttpContextAccessor _httpContextAccessor;
        private static long GlobalPlantId;
        public QCController(dbFormulationProductionSystemContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            var plntid = _httpContextAccessor.HttpContext.Session.GetString("PlantId");
            if (!string.IsNullOrEmpty(plntid))
            {
                GlobalPlantId = long.Parse(plntid);
            }
        }

        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["EmpIdSortParm"] = String.IsNullOrEmpty(sortOrder) ? "empId_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            //var plans = from s in eFTestContext.TblMonthlyPlanning 
            //            from d in eFTestContext.TblMonthlyPlanningDetail
            //            where (s.PlanningNo == d.PlanningNo)
            //            select new {s.PlanningNo,s.Year,s.Month,d.Fgcode};

            var qc_data = from master in _context.TblQc.Where(master=>master.PlantId == GlobalPlantId)
                          from process in _context.TblProductionProcess.Where(process => process.PlantId == GlobalPlantId)
                          from bom in _context.View_BOM.Where(bom=> bom.IsActive=="Y")
                          from p in _context.View_Product
                          where( master.ProcessNo == process.ProcessNo && process.ProductCode == bom.ProductCode 
                          && bom.ProductCode== p.ProductCode)
                          select new TblQc {
                              Id = master.Id,
                              ProductCode = process.ProductCode,
                              ProductName = p.ProductName,
                              Qcno = master.Qcno,
                              Qcdate = master.Qcdate,
                              RequisitionNo =  master.RequisitionNo,
                              BatchNo =  process.BatchNo,
                              ProcessNo =  master.ProcessNo,
                              Qcqty =  master.Qcqty,
                              QcpassQty =  master.QcpassQty,
                              QcrejectQty =  master.QcrejectQty
                          };

            if (!String.IsNullOrEmpty(searchString))
            {
                qc_data = qc_data.Where(s => s.Qcno.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    qc_data = qc_data.OrderByDescending(s => s.Qcno);
                    break;
                case "empId_desc":
                    qc_data = qc_data.OrderByDescending(s => s.Qcno);
                    break;
                //case "Date":
                //    employees = employees.OrderBy(s => s.EnrollmentDate);
                //    break;
                //case "date_desc":
                //    employees = employees.OrderByDescending(s => s.EnrollmentDate);
                //    break;
                default:
                    qc_data = qc_data.OrderByDescending(s => s.Qcno);
                    break;
            }
            int pageSize = 7;


            return View(await PaginatedList<TblQc>.CreateAsync(qc_data.AsNoTracking(), pageNumber ?? 1, pageSize));

        }

        public ActionResult Create()
        {
            TblQc entities = new TblQc();

            List<SelectListItem> Year = new List<SelectListItem>();           

            entities.Idate = DateTime.Now;
            entities.Qcdate = DateTime.Now;
            entities.Qcno = GetAutoNumber();

            var businessCode = (from c in _context.TblUserWiseBusinessAndPlantCode
                                where c.PlantId == GlobalPlantId
                                select c.BusinessCode
                  ).FirstOrDefault();

            var productList = (from c in _context.View_Product select c).ToList();
            ViewBag.ListOfProduct = productList;

            List<TblQcparameterType> typeList = new List<TblQcparameterType>();
            typeList = (from c in _context.TblQcparameterType
                        select c).ToList();
            typeList.Insert(0, new TblQcparameterType { TypeCode = "0", TypeName = "Select Type" });
            ViewBag.ListOfType = typeList;

            //entities.TblQcdetails = (from para in eFTestContext.TblQcparameter
            //                                 select new TblQcdetails
            //                                 {
            //                                     Id = para.Id,
            //                                     QcparameterCode = para.QcparameterCode,
            //                                     QcparameterName = para.QcparameterName,
            //                                     QcparameterStandardValue = para.QcparameterStandardValue,
            //                                     QcparameterActualValue = null,
            //                                     Comments = null
            //                                 }).ToList();
            List<TblSection> sectionList= new List<TblSection>();
            //sectionList = _context.TblSection.ToList();
            sectionList = (from c in _context.TblSection.Where(c => c.PlantId == GlobalPlantId).OrderBy(c => c.Id) select c).ToList();
            sectionList.Insert(0, new TblSection { SectionCode = "0", SectionName = "Select Section" });
            ViewBag.ListOfSection = sectionList;
            return View(entities);
        }

        public string GetAutoNumber()
        {

            //Generate Requisition No.---------Start
            String sDate = DateTime.Now.ToString();
            DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));
            //String dy = datevalue.Day.ToString("00");
            String mn = datevalue.Month.ToString("00");
            String yy = datevalue.Year.ToString().Substring(2, 2);
            var QCNo = "QC-" + yy + mn;
            String maxId = "";
            String maxNo = (from c in _context.TblQc.Where(c => c.Qcno.Substring(0, 7) == QCNo).OrderByDescending(t => t.Id) select c.Qcno.Substring(7, 3)).FirstOrDefault();
            if (maxNo == null)
            {
                maxId = "001";
            }
            else
            {
                maxId = (Convert.ToInt16(maxNo) + 1).ToString("000");
            }
            QCNo = "QC-" + yy + mn + maxId;

            return QCNo;

        }

        [HttpPost, ActionName("CreateQC")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateQC(TblQc qc_data)
        //[Bind("EnrollmentDate,FirstMidName,LastName")] Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    //var qc_entity = new TblQc
                    //{
                    //    Qcno = qc_data.Qcno,
                    //    Qcdate = qc_data.Qcdate,
                    //    RequisitionNo = qc_data.RequisitionNo,
                    //    ProcessNo = qc_data.ProcessNo,
                    //    Qcqty = qc_data.Qcqty,
                    //    QcpassQty = qc_data.QcpassQty,
                    //    QcrejectQty = qc_data.QcrejectQty,
                    //    Comments = qc_data.Comments,
                    //    Iuser = User.Identity.Name,
                    //    Idate = DateTime.Now
                    //};
                    //_context.TblQc.Add(qc_entity);
                    //await _context.SaveChangesAsync();


                    //if (qc_data.TblQcdetails != null)
                    //{
                    //    foreach (var item in qc_data.TblQcdetails.ToList())
                    //    {
                    //        TblQcdetails itemDetail = new TblQcdetails();
                    //        itemDetail.Qcno = qc_data.Qcno;
                    //        itemDetail.QcparameterCode = item.QcparameterCode;
                    //        itemDetail.QcparameterActualValue = item.QcparameterActualValue;
                    //        itemDetail.Comments = item.Comments;
                    //        await _context.AddAsync(itemDetail);
                    //    }
                    //}
                    //await _context.SaveChangesAsync();
                    //TempData["Success"] = "Success message text.";


                    qc_data.Iuser = User.Identity.Name;
                    qc_data.Idate = DateTime.Now;
                    qc_data.PlantId = GlobalPlantId;
                    qc_data.Qcno = GetAutoNumber();
                    _context.Add(qc_data);
                    await _context.SaveChangesAsync();

                }
                else
                {
                    ViewData["Error"] = "Error message text.";
                    return View(qc_data);
                }


                // Update tblFloorStock Table
                //var fgCodeQuery = from p in _context.TblProductionProcess
                //             join r in _context.TblRequisition on p.RequisitionNo equals r.RequisitionNo
                //             where p.ProcessNo == qc_data.ProcessNo
                //             select new { ProductCode  = r.ProductCode };
                string fgCode = qc_data.ProductCode;

                var sfgCode = _context.TblProductionProcess.Where(c=>c.ProcessNo==qc_data.ProcessNo).FirstOrDefault().SFGCode;

                if (qc_data.IsSendToFloorStockFG && qc_data.QcpassQty > 0)
                {
                    UpdateFloorStockFromProductionQC(fgCode.ToString(), qc_data.Qcno, qc_data.QcpassQty);
                }

                if (qc_data.IsSendToFloorStockSFG && qc_data.SFGQcpassQty>0)
                {
                    UpdateFloorStockFromProductionQC(sfgCode.ToString(), qc_data.Qcno, qc_data.SFGQcpassQty);
                }


                return RedirectToAction(nameof(Index));



            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }



            

            return RedirectToAction(nameof(Index));
        }

        public JsonResult UpdateFloorStockFromProductionQC(string productId, string qcNo, decimal QCQty)
        {
            var errorViewModel = new ErrorViewModel();
            var sa = new JsonSerializerSettings();
            var productIdParam = new SqlParameter("@productId", productId);
            var qcNoParam = new SqlParameter("@qcNo", qcNo);
            var QCQtyParam = new SqlParameter("@qcQuantity", QCQty);

            //var userType = dbContext.Set().FromSql("dbo.SomeSproc @Id = {0}, @Name = {1}", 45, "Ada");

            var productList = _context.UpdateFloorScockFromForductionQC
                                .FromSql("EXEC sp_UpdateFloorStockFromProductionQC @productId, @qcNo, @qcQuantity", productIdParam, qcNoParam, QCQtyParam)
                                .ToList();

            return Json(productList, sa);
        }

        [HttpPost]
        public bool Delete(int id)
        //public ActionResult Delete(int id)
        {
            try
            {
                TblQc data = _context.TblQc.Where(s => s.Id == id).First();
                _context.TblQcdetails.RemoveRange(_context.TblQcdetails.Where(d => d.Qcno == data.Qcno));
                _context.TblFloorStock.RemoveRange(_context.TblFloorStock.Where(d => d.RequisitionNo == data.Qcno));
                _context.TblQc.Remove(data);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public ActionResult Update(int id)
        {
            Models.TblQc QCModel = new Models.TblQc();
            var dt = _context.TblQc.Where(s => s.Id == id).First();
            QCModel.Id = dt.Id;
            QCModel.Qcno = dt.Qcno;
            QCModel.Qcdate = dt.Qcdate;
            QCModel.Comments = dt.Comments;
            QCModel.RequisitionNo = dt.RequisitionNo;
            QCModel.BatchNo = _context.TblProductionProcess.Where(pro => pro.ProcessNo == dt.ProcessNo).FirstOrDefault().BatchNo;            
            var productCode = dt.ProductCode;
            QCModel.ProductName = _context.View_Product.Where(req => req.ProductCode == productCode).FirstOrDefault().ProductName;
            QCModel.PackSize = _context.View_Product.Where(req => req.ProductCode == productCode).FirstOrDefault().PackSize;
            QCModel.BatchSize = _context.View_BOM.Where(req => req.ProductCode == productCode).FirstOrDefault().BatchSize;
            QCModel.ProcessNo = dt.ProcessNo;
            QCModel.Qcqty = dt.Qcqty;
            QCModel.QcpassQty = dt.QcpassQty;
            QCModel.QcholdQty = dt.QcholdQty;
            QCModel.QcrejectQty = dt.QcrejectQty;
            QCModel.SFGQcqty = dt.SFGQcqty;
            QCModel.SFGQcpassQty = dt.SFGQcpassQty;
            QCModel.SFGQcrejectQty = dt.SFGQcrejectQty;
            QCModel.IsSendToFloorStockFG = dt.IsSendToFloorStockFG;
            QCModel.IsSendToFloorStockSFG = dt.IsSendToFloorStockSFG;
            QCModel.FGQCQtyBeforeConversion = dt.FGQCQtyBeforeConversion;
            QCModel.FGQCQtyConversionFactor = dt.FGQCQtyConversionFactor;
            QCModel.QCReferenceSampleQty = dt.QCReferenceSampleQty;
            QCModel.QCQuarantineQty = dt.QCQuarantineQty;


            ViewBag.ddlProcessList = new SelectList(_context.TblProductionProcess.Where(c => c.RequisitionNo == dt.RequisitionNo), "ProcessNo", "ProcessNo");

            List<TblQcparameterType> typeList = new List<TblQcparameterType>();
            typeList = (from c in _context.TblQcparameterType
                        select c).ToList();
            typeList.Insert(0, new TblQcparameterType { TypeCode = "0", TypeName = "Select Type" });
            ViewBag.ListOfType = typeList;


            var qc_detail =    from master in _context.TblQc
                               from req in _context.TblRequisition
                               from detail in _context.TblQcdetails   
                                from para in _context.TblQcparameter
                               where (master.RequisitionNo == req.RequisitionNo)
                                 where (master.Qcno == detail.Qcno)
                                   where (para.ProductCode == req.ProductCode)
                                   where (detail.QcparameterCode == para.QcparameterCode)                                 
                                 where (master.Qcno == dt.Qcno)
                                 orderby detail.QcparameterCode
                                 select new TblQcdetails
                                 {
                                     Id = detail.Id,
                                     QcparameterCode = detail.QcparameterCode,
                                     QcparameterName = para.QcparameterName,
                                     QcparameterStandardValue = para.QcparameterStandardValue,
                                     QcparameterActualValue = detail.QcparameterActualValue,
                                     Comments = detail.Comments
                                 };

            QCModel.TblQcdetails = qc_detail.ToList();

            return View(QCModel);
        }        



        [HttpPost, ActionName("UpdateQC")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateQC(int id, TblQc qc_data)
        {
            if (id != qc_data.Id)
            {
                return NotFound();
            }
            try
            {
                //eFTestContext.Update(emp);
                //await eFTestContext.SaveChangesAsync();

                var qcdataToUpdate = await _context.TblQc.FirstOrDefaultAsync(s => s.Id == id);
                qcdataToUpdate.Edate = DateTime.Now;
                qcdataToUpdate.Euser = User.Identity.Name;

                if (await TryUpdateModelAsync<TblQc>(
                    qcdataToUpdate,
                    "",
                    s => s.Qcno, s => s.Qcdate, s => s.RequisitionNo, s => s.ProcessNo, s => s.Qcqty, s => s.QcpassQty, s => s.QcholdQty, s => s.QcrejectQty, 
                    s => s.SFGQcqty, s => s.SFGQcpassQty, s => s.SFGQcrejectQty, s => s.Comments, s=>s.FGQCQtyBeforeConversion, s=>s.FGQCQtyConversionFactor,
                    s => s.QCQuarantineQty, s=>s.IsSendToFloorStockFG, s=> s.IsSendToFloorStockSFG))

                _context.TblQcdetails.RemoveRange(_context.TblQcdetails.Where(d => d.Qcno == qc_data.Qcno));

                if (qc_data.TblQcdetails != null)
                {
                    foreach (var item in qc_data.TblQcdetails.ToList())
                    {
                        TblQcdetails itemDetail = new TblQcdetails();
                        itemDetail.Qcno = qc_data.Qcno;
                        itemDetail.QcparameterCode = item.QcparameterCode;
                        itemDetail.QcparameterName = item.QcparameterName;
                        itemDetail.QcparameterStandardValue = item.QcparameterStandardValue;
                        itemDetail.QcparameterActualValue = item.QcparameterActualValue;
                        itemDetail.Comments = item.Comments;
                        await _context.AddAsync(itemDetail);
                    }
                    await _context.SaveChangesAsync();
                }

                // Update tblFloorStock Table
                var fgCodeQuery = from p in _context.TblProductionProcess
                                  where p.ProcessNo == qc_data.ProcessNo
                                  select new { ProductCode = p.ProductCode };
                string fgCode = fgCodeQuery.FirstOrDefault().ProductCode.ToString();

                var sfgCode = _context.TblProductionProcess.Where(c => c.ProcessNo == qc_data.ProcessNo).FirstOrDefault().SFGCode;

                if (qc_data.IsSendToFloorStockFG && qc_data.QcpassQty > 0)
                {
                    UpdateFloorStockFromProductionQC(fgCode.ToString(), qc_data.Qcno, qc_data.QcpassQty);
                }

                if (qc_data.IsSendToFloorStockSFG && qc_data.SFGQcpassQty > 0)
                {
                    UpdateFloorStockFromProductionQC(sfgCode.ToString(), qc_data.Qcno, qc_data.SFGQcpassQty);
                }


                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists, " +
                    "see your system administrator.");
            }
            return View(qc_data);
        }

        public IActionResult addRequisition()
        {

            //var requisitionModel = new List<TblRequisition>(from c in _context.TblRequisition
            //                                                from p in _context.View_Product
            //                                                where (c.ProductCode == p.ProductCode && c.ExtOfRequisitionNo == null) 
            //                                                orderby c.RequisitionDate descending
            //                                                select new TblRequisition
            //                                                {
            //                                                    RequisitionNo = c.RequisitionNo,
            //                                                    ProductCode = c.ProductCode,
            //                                                    ProductName = p.ProductName
            //                                                });

            var requisitionNoParam = new SqlParameter("@requisitionNo", "");
            var plantIdParam = new SqlParameter("@plantId", GlobalPlantId);
            var requisitionModel = _context.GetSearchRequisitionList
                               .FromSql("EXEC sp_SearchRequisitionForQC @requisitionNo, @plantId", requisitionNoParam, plantIdParam)
                               .ToList();

            return PartialView("_RequisitionAreaPartial", requisitionModel);
        }

        [HttpPost]
        public JsonResult SearchRequisition(string RequisitionNo)
        {
            //var model = new List<TblRequisition>(from req in _context.TblRequisition
            //                                     from b in _context.View_BOM
            //                                     from p in _context.View_Product
            //                                     where (req.ProductCode == b.ProductCode && b.ProductCode == p.ProductCode && (req.RequisitionNo.ToUpper().Contains(RequisitionNo.ToUpper())))
            //                                     select new TblRequisition
            //                                     {
            //                                         RequisitionNo = req.RequisitionNo,
            //                                         ProductCode = req.ProductCode,
            //                                         ProductName = p.ProductName
            //                                     });

            var requisitionNoParam = new SqlParameter("@requisitionNo", RequisitionNo == null ? "" : RequisitionNo);
            var plantIdParam = new SqlParameter("@plantId", GlobalPlantId);
            var model = _context.GetSearchRequisitionList
                               .FromSql("EXEC sp_SearchRequisitionForQC @requisitionNo, @plantId", requisitionNoParam, plantIdParam)
                               .ToList();

            var sa = new JsonSerializerSettings();
            return Json(model, sa);
        }

        public JsonResult GetProcessNumber(string RequisitionNo)
        {
            var model = new List<TblProductionProcess>(from prop in _context.TblProductionProcess
                                                       from req in _context.TblRequisition
                                                       where (prop.RequisitionNo == req.RequisitionNo && (prop.RequisitionNo.ToUpper().Contains(RequisitionNo.ToUpper())))
                                                       select new TblProductionProcess
                                                       {
                                                           ProcessNo = prop.ProcessNo,
                                                           ProductionQty = prop.ProductionQty
                                                       });

            //var requisitionNoParam = new SqlParameter("@requisitionNo", RequisitionNo == null ? "" : RequisitionNo);
            //var sectionCodeParam = new SqlParameter("@sectionCode", SECTION_CODE);
            //var model = _context.GetRequisitionWiseProcessList
            //                   .FromSql("EXEC sp_GetRequisitionWiseProcessNoBySection @requisitionNo, @sectionCode", requisitionNoParam, sectionCodeParam)
            //                   .ToList();

            var sa = new JsonSerializerSettings();
            return Json(model, sa);
        }

        public JsonResult GetQCQuantity(string ProcessNo)
        {
            //int isCodingDetailVisible = 0;
            //isCodingDetailVisible = _context.TblVisibility.Where(x => x.ItemName == "Production Coding Detail" && x.PlantId == GlobalPlantId).Count() > 0 ?
            //                        _context.TblVisibility.Where(x => x.ItemName == "Production Coding Detail" && x.PlantId == GlobalPlantId).FirstOrDefault().Isvisible : 0;

            var model = new List<TblProductionProcess>(from prop in _context.TblProductionProcess where prop.ProcessNo==ProcessNo
                                                       select new TblProductionProcess
                                                       {
                                                           RequisitionNo= prop.RequisitionNo,
                                                           ProcessNo = prop.ProcessNo,
                                                           //ProductionQty = isCodingDetailVisible==0? prop.ProductionQty:prop.CodingQty,
                                                           ProductionQty =  prop.ProductionQty,
                                                           SFGProductionQty = prop.SFGProductionQty,
                                                           BatchNo = prop.BatchNo,
                                                           QCReferenceSampleQty = prop.QCReferenceSampleQty,
                                                           LumpQty = prop.LumpQty,
                                                       });
            var sa = new JsonSerializerSettings();
            return Json(model, sa);
        }


        [HttpPost]
        public JsonResult SetRequisitionInfomation(string RequisitionNo)
        {
            var keyVal = _context.TblRequisition.Where(c => c.RequisitionNo == RequisitionNo).ToList();
            if (keyVal != null)
            {
                RequisitionNo = keyVal.FirstOrDefault().RequisitionNo;
            }

            if (RequisitionNo != "")
            {
                var availableFloorStock = from c in _context.TblRequisition
                                              join fs in _context.TblFloorStock on c.ProductCode equals fs.MaterialCode into ps
                                              from f in ps.DefaultIfEmpty()
                                              where (c.RequisitionNo == RequisitionNo)
                                              select new
                                              {
                                                  AvailableStock = (ps != null ? ps.Sum(x => x.AvailableStock) : 0)
                                              };


                var sa = new JsonSerializerSettings();
                var expertiesInfo = from c in _context.TblRequisition
                                    from b in _context.View_BOM
                                    from p in _context.View_Product
                                    where(c.RequisitionNo == RequisitionNo && c.ProductCode == b.ProductCode && b.ProductCode == p.ProductCode)
                                    select new
                                    {
                                        c.RequisitionNo,
                                        c.BatchNo,
                                        c.ProductCode,
                                        p.ProductName,
                                        p.PackSize,
                                        b.BatchSize,
                                        b.ConversionValue,
                                        AvailableStock = availableFloorStock.FirstOrDefault().AvailableStock   // (ps != null ? ps.Sum(x=>x.AvailableStock) : 0) // ps.Sum(x=> (double)x.AvailableStock ?? 0.00).Sum() 
                                    };
                return Json(expertiesInfo, sa);
            }
            else
            {
                return Json("");
            }
        }

        public JsonResult SetRequisitionInfomationByProcessNo(string ProcessNo)
        {
            var RequisitionNo = "";
            var keyVal = _context.TblProductionProcess.Where(c => c.ProcessNo == ProcessNo).ToList();
            if (keyVal != null)
            {
                RequisitionNo = keyVal.FirstOrDefault().RequisitionNo;
            }

            if (RequisitionNo != "")
            {
                var availableFloorStock = from c in _context.TblRequisition
                                          join fs in _context.TblFloorStock on c.ProductCode equals fs.MaterialCode into ps
                                          from f in ps.DefaultIfEmpty()
                                          where (c.RequisitionNo == RequisitionNo)
                                          select new
                                          {
                                              AvailableStock = (ps != null ? ps.Sum(x => x.AvailableStock) : 0)
                                          };


                var sa = new JsonSerializerSettings();
                var expertiesInfo = from c in _context.TblRequisition
                                    from b in _context.View_BOM
                                    from p in _context.View_Product
                                    where (c.RequisitionNo == RequisitionNo && c.ProductCode == b.ProductCode && b.ProductCode == p.ProductCode)
                                    select new
                                    {
                                        c.RequisitionNo,
                                        c.BatchNo,
                                        c.ProductCode,
                                        p.ProductName,
                                        p.PackSize,
                                        b.BatchSize,
                                        b.ConversionValue,
                                        AvailableStock = availableFloorStock.FirstOrDefault().AvailableStock   // (ps != null ? ps.Sum(x=>x.AvailableStock) : 0) // ps.Sum(x=> (double)x.AvailableStock ?? 0.00).Sum() 
                                    };
                return Json(expertiesInfo, sa);
            }
            else
            {
                var productCode = "";
                if (keyVal != null)
                {
                    productCode = keyVal.FirstOrDefault().ProductCode;
                }
                var floorStockByProductCode = from pp in _context.TblProductionProcess
                                              join fs in _context.TblFloorStock on pp.ProductCode equals fs.MaterialCode into ps
                                              from f in ps.DefaultIfEmpty()
                                              where (pp.ProductCode == productCode)
                                              select new
                                              {
                                                  AvailableStock = (ps != null ? ps.Sum(x => x.AvailableStock) : 0)
                                              };


                var sa = new JsonSerializerSettings();
                var expertiesInfo = from pp in _context.TblProductionProcess
                                    from b in _context.View_BOM
                                    from p in _context.View_Product
                                    where ( pp.ProductCode == b.ProductCode && b.ProductCode == p.ProductCode)
                                    select new
                                    {
                                        pp.RequisitionNo,
                                        pp.BatchNo,
                                        pp.ProductCode,
                                        pp.ProductionQty,
                                        p.ProductName,
                                        p.PackSize,
                                        b.BatchSize,
                                        b.ConversionValue,
                                        AvailableStock = floorStockByProductCode.FirstOrDefault().AvailableStock   // (ps != null ? ps.Sum(x=>x.AvailableStock) : 0) // ps.Sum(x=> (double)x.AvailableStock ?? 0.00).Sum() 
                                    };
                return Json(expertiesInfo, sa);
                //return Json("");
            }
        }

        [HttpPost]
        public JsonResult GetTypeWiseQCParameter(string type)
        {
            //var model = new List<TblQcdetails>(from para in _context.TblQcparameter where para.TypeCode == type
            //                                   select new TblQcdetails
            //                                   {
            //                                       Id = para.Id,
            //                                       QcparameterCode = para.QcparameterCode,
            //                                       QcparameterName = para.QcparameterName,
            //                                       QcparameterStandardValue = para.QcparameterStandardValue,
            //                                       QcparameterActualValue = "",
            //                                       Comments = ""
            //                                   });

            var model = new List<TblQcdetails>(from para in _context.TblQcparameter
                                               where (para.ProductCode == type) && (para.PlantId==GlobalPlantId)
                                               select new TblQcdetails
                                               {
                                                   Id = para.Id,
                                                   QcparameterCode = para.QcparameterCode,
                                                   QcparameterName = para.QcparameterName,
                                                   QcparameterStandardValue = para.QcparameterStandardValue,
                                                   QcparameterActualValue = "",
                                                   Comments = ""
                                               });

            var sa = new JsonSerializerSettings();
            return Json(model, sa);
        }
        public ActionResult SetSectionCode(string SectionCode)
        {
            SECTION_CODE = SectionCode;
            return Ok();
        }
        //public ActionResult GetProcessNoList(string SectionCode)
        //{
        //    var sa = new JsonSerializerSettings();
        //    //var sectionCodeParam = new SqlParameter("@SectionCode", SectionCode);
        //    //var model = _context.GetProcessNoList.FromSql("EXEC sp_GetProcessNoList @SectionCode", sectionCodeParam).ToList();
        //    var model = (from c in _context.TblProductionProcess
        //                 where c.SectionCode==SectionCode
        //                 select new TblProductionProcess
        //                 { 
        //                  ProcessNo = c.ProcessNo,
        //                 }
        //                 ).ToList();

        //    return Json(model, sa);
        //}

        public ActionResult GetProcessNoList(string SectionCode, string ProductCode)
        {
            var sa = new JsonSerializerSettings();
            var sectionCodeParam = new SqlParameter("@SectionCode", SectionCode);
            var plantIdParam = new SqlParameter("@PlantId", GlobalPlantId);
            var productCodeParam = new SqlParameter("@ProductCodeNo", ProductCode);
            var model = _context.GetProcessNoListQC.FromSql("EXEC sp_GetProcessNoListForQC  @SectionCode, @PlantId,@ProductCodeNo", sectionCodeParam, plantIdParam, productCodeParam).ToList();

            return Json(model, sa);
        }
    }
}