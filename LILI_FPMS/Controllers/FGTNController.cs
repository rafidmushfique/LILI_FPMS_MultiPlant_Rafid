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
using Microsoft.EntityFrameworkCore.Query.ResultOperators.Internal;
using Newtonsoft.Json;
using Org.BouncyCastle.Ocsp;

namespace LILI_IMS.Controllers
{

    [Authorize]
    public class FGTNController : Controller
    {
        private readonly dbFormulationProductionSystemContext _context;

        private readonly IHttpContextAccessor _httpContextAccessor;
        private static long GlobalPlantId;

        public FGTNController(dbFormulationProductionSystemContext context, IHttpContextAccessor httpContextAccessor)
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

            var fgtn_data = from master in _context.TblFgtn.Where(master => master.PlantId == GlobalPlantId)
                          select new TblFgtn {
                              Id = master.Id,
                              Fgtnno = master.Fgtnno,
                              Fgtndate = master.Fgtndate,
                              Comments = master.Comments
                          };

            if (!String.IsNullOrEmpty(searchString))
            {
                fgtn_data = fgtn_data.Where(s => s.Fgtnno.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    fgtn_data = fgtn_data.OrderByDescending(s => s.Fgtnno);
                    break;
                
                //case "Date":
                //    employees = employees.OrderBy(s => s.EnrollmentDate);
                //    break;
                //case "date_desc":
                //    employees = employees.OrderByDescending(s => s.EnrollmentDate);
                //    break;
                default:
                    fgtn_data = fgtn_data.OrderByDescending(s => s.Fgtnno);
                    break;
            }
            int pageSize = 7;


            return View(await PaginatedList<TblFgtn>.CreateAsync(fgtn_data.AsNoTracking(), pageNumber ?? 1, pageSize));

        }

        public ActionResult Create()
        {
            TblFgtn entities = new TblFgtn();

            List<SelectListItem> Year = new List<SelectListItem>();           

            entities.Idate = DateTime.Now;
            entities.Fgtndate = DateTime.Now;
            entities.Fgtnno = GetAutoNumber();

            var errorViewModel = new ErrorViewModel();
            var sa = new JsonSerializerSettings();

            List<TblFgtransferLocation> locationList = new List<TblFgtransferLocation>();
            locationList = (from c in _context.TblFgtransferLocation
                        select c).ToList();
            locationList.Insert(0, new TblFgtransferLocation { LocationCode = "0", LocationName = "Select Location" });
            ViewBag.ListOfLocation = locationList;

            var plantIdParam = new SqlParameter("@plantId", GlobalPlantId);
            var pendingList = _context.GetFGTNPendingList
                                .FromSql("EXEC sp_GetFGTNPendingList @plantId", plantIdParam)
                                .ToList();


            entities.TblFgtndetails = (from c in pendingList
                                       select new TblFgtndetails
                                       {
                                           ProductCode = c.ProductCode,
                                           ProductName = c.ProductName,
                                           Qcno = c.Qcno,
                                           RequisitionNo = c.RequisitionNo,
                                           ProcessNo = c.ProcessNo,
                                           BatchNo = c.BatchNo,
                                           QcpassQty = c.QcpassQty,
                                           PendingFGTNQty = c.PendingFGTNQty,
                                           Fgtnqty = 0,
                                           Comments = ""
                                       }).ToList();


            return View(entities);
        }

        public string GetAutoNumber()
        {

            //Generate FGTN No.---------Start
            String sDate = DateTime.Now.ToString();
            DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));
            //String dy = datevalue.Day.ToString("00");
            String mn = datevalue.Month.ToString("00");
            String yy = datevalue.Year.ToString().Substring(2, 2);
            var FGTNNo = "FT-" + yy + mn;
            String maxId = "";
            String maxNo = (from c in _context.TblFgtn.Where(c => c.Fgtnno.Substring(0, 7) == FGTNNo).OrderByDescending(t => t.Id) select c.Fgtnno.Substring(7, 3)).FirstOrDefault();
            if (maxNo == null)
            {
                maxId = "001";
            }
            else
            {
                maxId = (Convert.ToInt16(maxNo) + 1).ToString("000");
            }
            FGTNNo = "FT-" + yy + mn + maxId;

            return FGTNNo;

        }

        [HttpPost, ActionName("CreateFGTN")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFGTN(TblFgtn fgtn_data)
        //[Bind("EnrollmentDate,FirstMidName,LastName")] Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    fgtn_data.TblFgtndetails = fgtn_data.TblFgtndetails.Where(c => c.Fgtnqty > 0).ToList();

                    fgtn_data.Iuser = User.Identity.Name;
                    fgtn_data.Idate = DateTime.Now;
                    fgtn_data.Fgtnno = GetAutoNumber();
                    fgtn_data.PlantId = GlobalPlantId;
                    _context.Add(fgtn_data);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    ViewData["Error"] = "Error message text.";
                    return View(fgtn_data);
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


        [HttpPost]
        public bool Delete(int id)
        {
            try
            {
                TblFgtn data = _context.TblFgtn.Where(s => s.Id == id).First();
                _context.TblFgtndetails.RemoveRange(_context.TblFgtndetails.Where(d => d.Fgtnno == data.Fgtnno));
                _context.TblFgtn.Remove(data);
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
            TblFgtn fgtnModel = new TblFgtn();
            var dt = _context.TblFgtn.Where(s => s.Id == id).First();
            fgtnModel.Id = dt.Id;
            fgtnModel.Fgtnno = dt.Fgtnno;
            fgtnModel.Fgtndate = dt.Fgtndate;            
            fgtnModel.BusinessCode = dt.BusinessCode;
            fgtnModel.LocationCode = dt.LocationCode;
            fgtnModel.Comments = dt.Comments;

            List<TblFgtransferLocation> locationList = new List<TblFgtransferLocation>();
            locationList = (from c in _context.TblFgtransferLocation
                            select c).ToList();
            locationList.Insert(0, new TblFgtransferLocation { LocationCode = "0", LocationName = "Select Location" });
            ViewBag.ListOfLocation = locationList;

            //fgtnModel.TblFgtndetails = (from c in _context.TblFgtndetails
            //                            from p in _context.View_Product
            //                            from pp in _context.TblProductionProcess
            //                            where c.Fgtnno == fgtnModel.Fgtnno & c.ProductCode == p.ProductCode & c.ProcessNo == pp.ProcessNo
            //                            select new TblFgtndetails
            //                            {
            //                                ProductCode = c.ProductCode,
            //                                ProductName = p.ProductName,
            //                                Qcno = c.Qcno,
            //                                RequisitionNo = c.RequisitionNo,
            //                                ProcessNo = c.ProcessNo,
            //                                BatchNo = pp.BatchNo,
            //                                QcpassQty = c.QcpassQty,
            //                                PendingFGTNQty = 0,
            //                                Fgtnqty = c.Fgtnqty,
            //                                Comments = c.Comments
            //                            }).ToList();


            var fgtnNoParam = new SqlParameter("@FGTNNo", fgtnModel.Fgtnno);

            var  fgtndetails = _context.GetFGTNPendingList
                                        .FromSql("EXEC sp_GetFGTNByFGTNNo @FGTNNo", fgtnNoParam)
                                        .ToList();
            fgtnModel.TblFgtndetails = (from c in fgtndetails
                                        select new TblFgtndetails
                                        {
                                            ProductCode = c.ProductCode,
                                            ProductName = c.ProductName,
                                            Qcno = c.Qcno,
                                            RequisitionNo = c.RequisitionNo,
                                            ProcessNo = c.ProcessNo,
                                            BatchNo = c.BatchNo,
                                            QcpassQty = c.QcpassQty,
                                            PendingFGTNQty = Convert.ToDecimal(0),
                                            Fgtnqty = c.Fgtnqty,
                                            Comments = c.Comments
                                        }).ToList();

            return View(fgtnModel);
        }        



        [HttpPost, ActionName("UpdateFGFTN")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateFGFTN(int id, TblFgtn fgtnData)
        {
            if (id != fgtnData.Id)
            {
                return NotFound();
            }
            try
            {
                var fgtnDataToUpdate = await _context.TblFgtn.FirstOrDefaultAsync(s => s.Id == id);
                fgtnDataToUpdate.Edate = DateTime.Now;
                fgtnDataToUpdate.Euser = User.Identity.Name;

                if (await TryUpdateModelAsync<TblFgtn>(
                    fgtnDataToUpdate,
                    "",
                    s => s.Fgtnno, s => s.Fgtndate, s => s.LocationCode, s => s.Comments))

                _context.TblFgtndetails.RemoveRange(_context.TblFgtndetails.Where(d => d.Fgtnno == fgtnData.Fgtnno));

                if (fgtnData.TblFgtndetails != null)
                {
                    foreach (var item in fgtnData.TblFgtndetails.ToList())
                    {
                        TblFgtndetails itemDetail = new TblFgtndetails();
                        itemDetail.Fgtnno = fgtnData.Fgtnno;
                        itemDetail.ProductCode = item.ProductCode;
                        itemDetail.RequisitionNo = item.RequisitionNo;
                        itemDetail.ProcessNo = item.ProcessNo;
                        itemDetail.Qcno = item.Qcno;
                        itemDetail.QcpassQty = item.QcpassQty;
                        itemDetail.Fgtnqty = item.Fgtnqty;
                        itemDetail.Comments = item.Comments;
                        await _context.AddAsync(itemDetail);
                    }
                    await _context.SaveChangesAsync();
                }


                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists, " +
                    "see your system administrator.");
            }
            return View(fgtnData);
        }

        //public IActionResult addRequisition()
        //{
        //    //Models.TblRequisition requisitionModel = new Models.TblRequisition();

        //    //var requisitionModel = new List<TblRequisition>();


        //    var requisitionModel = new List<TblRequisition>(from c in _context.TblRequisition
        //                                                    from p in _context.View_Product
        //                                                    where (c.ProductCode == p.ProductCode) 
        //                                                    orderby c.RequisitionDate descending
        //                                                    select new TblRequisition
        //                                                    {
        //                                                        RequisitionNo = c.RequisitionNo,
        //                                                        ProductCode = c.ProductCode,
        //                                                        ProductName = p.ProductName
        //                                                    });

        //    return PartialView("_RequisitionAreaPartial", requisitionModel);
        //}

        //[HttpPost]
        //public JsonResult SearchRequisition(string RequisitionNo)
        //{            
        //    var model = new List<TblRequisition>(from req in _context.TblRequisition
        //                                         from b in _context.View_BOM
        //                                         from p in _context.View_Product
        //                                         where (req.ProductCode == b.ProductCode && b.ProductCode == p.ProductCode && (req.RequisitionNo.ToUpper().Contains(RequisitionNo.ToUpper())))
        //                                         select new TblRequisition
        //                                         {
        //                                             RequisitionNo = req.RequisitionNo,
        //                                             ProductCode = req.ProductCode,
        //                                             ProductName = p.ProductName
        //                                         });
        //    var sa = new JsonSerializerSettings();
        //    return Json(model, sa);
        //}

        //public JsonResult GetProcessNumber(string RequisitionNo)
        //{
        //    var model = new List<TblProductionProcess>(from prop in _context.TblProductionProcess
        //                                         from req in _context.TblRequisition                                                
        //                                         where (prop.RequisitionNo == req.RequisitionNo && (prop.RequisitionNo.ToUpper().Contains(RequisitionNo.ToUpper())))
        //                                         select new TblProductionProcess
        //                                         {
        //                                            ProcessNo = prop.ProcessNo,
        //                                            ProductionQty = prop.ProductionQty
        //                                         });
        //    var sa = new JsonSerializerSettings();
        //    return Json(model, sa);
        //}

        //public JsonResult GetQCQuantity(string ProcessNo)
        //{
        //    var model = new List<TblProductionProcess>(from prop in _context.TblProductionProcess where prop.ProcessNo==ProcessNo
        //                                               select new TblProductionProcess
        //                                               {
        //                                                   ProcessNo = prop.ProcessNo,
        //                                                   ProductionQty = prop.ProductionQty,
        //                                                   SFGProductionQty = prop.SFGProductionQty
        //                                               });
        //    var sa = new JsonSerializerSettings();
        //    return Json(model, sa);
        //}


        //[HttpPost]
        //public JsonResult SetRequisitionInfomation(string RequisitionNo)
        //{
        //    var keyVal = _context.TblRequisition.Where(c => c.RequisitionNo == RequisitionNo).ToList();
        //    if (keyVal != null)
        //    {
        //        RequisitionNo = keyVal.FirstOrDefault().RequisitionNo;
        //    }

        //    if (RequisitionNo != "")
        //    {
        //        var sa = new JsonSerializerSettings();
        //        var expertiesInfo = from c in _context.TblRequisition
        //                            from b in _context.View_BOM
        //                            from p in _context.View_Product
        //                            where(c.RequisitionNo == RequisitionNo && c.ProductCode == b.ProductCode && b.ProductCode == p.ProductCode)
        //                            select new
        //                            {
        //                                c.RequisitionNo,
        //                                c.BatchNo,
        //                                p.ProductName,
        //                                p.PackSize,
        //                                b.BatchSize
        //                            };
        //        return Json(expertiesInfo, sa);
        //    }
        //    else
        //    {
        //        return Json("");
        //    }
        //}

        //[HttpPost]
        //public JsonResult GetTypeWiseQCParameter(string type)
        //{
        //    var model = new List<TblQcdetails>(from para in _context.TblQcparameter where para.TypeCode == type
        //                                       select new TblQcdetails
        //                                       {
        //                                           Id = para.Id,
        //                                           QcparameterCode = para.QcparameterCode,
        //                                           QcparameterName = para.QcparameterName,
        //                                           QcparameterStandardValue = para.QcparameterStandardValue,
        //                                           QcparameterActualValue = "",
        //                                           Comments = ""
        //                                       });
        //    var sa = new JsonSerializerSettings();
        //    return Json(model, sa);
        //}
    }
}