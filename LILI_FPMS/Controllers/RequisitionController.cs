using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using LILI_FPMS;
using LILI_FPMS.Models;
using LILI_IMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace LILI_IMS.Controllers
{
    [Authorize]
    public class RequisitionController : Controller
    {
        private readonly dbFormulationProductionSystemContext _context;

        public RequisitionController(dbFormulationProductionSystemContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "requisition_desc" : "";
            ViewData["ProductCodeSortParm"] = String.IsNullOrEmpty(sortOrder) ? "productCode_desc" : "";
            ViewData["ProductNameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "productName_desc" : "";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var req = from s in _context.TblRequisition.Where(x=>x.PlantId==GlobalVariable.PlantId)
                      from p in _context.View_Product
                      where s.ProductCode == p.ProductCode
                      select new TblRequisition
                      {
                          Id = s.Id,
                          RequisitionNo = s.RequisitionNo,
                          ProductCode = s.ProductCode,
                          ProductName = p.ProductName,
                          BatchNo = s.BatchNo,
                          NumberOfBatch = s.NumberOfBatch,
                          RequisitionDate = s.RequisitionDate,
                          IssueStatus = s.IssueStatus,
                      };

            if (!String.IsNullOrEmpty(searchString))
            {
                req = req.Where(s => s.RequisitionNo.Contains(searchString)
                                    || s.ProductCode.Contains(searchString)
                                    || s.ProductName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "requisition_desc":
                    req = req.OrderByDescending(s => s.RequisitionNo);
                    break;
                case "productCode_desc":
                    req = req.OrderByDescending(s => s.ProductCode);
                    break;
                case "productName_desc":
                    req = req.OrderByDescending(s => s.ProductCode);
                    break;

                default:
                    req = req.OrderByDescending(s => s.RequisitionNo);
                    break;
            }
            int pageSize = 10;
            return View(await PaginatedList<TblRequisition>.CreateAsync(req.AsNoTracking(), pageNumber ?? 1, pageSize));

            //return View(await employees.AsNoTracking().ToListAsync());
        }

        public ActionResult Create()
        {
            ////Generate Requisition No.---------Start
            //String sDate = DateTime.Now.ToString();
            //DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));
            ////String dy = datevalue.Day.ToString("00");
            //String mn = datevalue.Month.ToString("00");
            //String yy = datevalue.Year.ToString().Substring(2, 2);
            //var requisitionNo = "REQ-" + yy + mn;
            //String maxId = "";
            //String maxNo = (from c in _context.TblRequisition.Where(c => c.RequisitionNo.Substring(0, 8) == requisitionNo).OrderByDescending(t => t.Id) select c.RequisitionNo.Substring(8, 3)).FirstOrDefault();
            //if (maxNo == null)
            //{
            //    maxId = "001";
            //}
            //else
            //{
            //    maxId = (Convert.ToInt16(maxNo) + 1).ToString("000");
            //}
            //requisitionNo = "REQ-" + yy + mn + maxId;

            ////Generate Requisition No.---------End

            TblRequisition entities = new TblRequisition();
            //entities.RequisitionNo = requisitionNo;
            entities.RequisitionNo = GenerateRequisitionNo();
            entities.RequisitionDate = DateTime.Now;
            return View(entities);
        }

        public string GenerateRequisitionNo()
        {
            //Generate Requisition No.---------Start
            String sDate = DateTime.Now.ToString();
            DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));
            //String dy = datevalue.Day.ToString("00");
            String mn = datevalue.Month.ToString("00");
            String yy = datevalue.Year.ToString().Substring(2, 2);
            var requisitionNo = "REQ-" + yy + mn;
            String maxId = "";
            String maxNo = (from c in _context.TblRequisition.Where(c => c.RequisitionNo.Substring(0, 8) == requisitionNo).OrderByDescending(t => t.Id) select c.RequisitionNo.Substring(8, 3)).FirstOrDefault();
            if (maxNo == null)
            {
                maxId = "001";
            }
            else
            {
                maxId = (Convert.ToInt16(maxNo) + 1).ToString("000");
            }
            requisitionNo = "REQ-" + yy + mn + maxId;

            return requisitionNo;
            //Generate Requisition No.---------End
        }

        [HttpPost, ActionName("CreateRequisition")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRequisition(TblRequisition req)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    req.Iuser = User.Identity.Name;
                    req.Idate = DateTime.Now;
                    req.IssueStatus = "Pending";
                    req.PlantId = GlobalVariable.PlantId;
                    req.RequisitionNo = GenerateRequisitionNo();
                    _context.Add(req);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    ViewData["Error"] = "Error message text.";
                    return View(req);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException ex)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            //return View(student);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public bool Delete(int id)
        {
            try
            {
                
                TblRequisition req = _context.TblRequisition.Where(s => s.Id == id).First();
                if (IsEditableDeleteable(req.RequisitionNo) == true)
                {
                    _context.TblRequisitionDetail.RemoveRange(_context.TblRequisitionDetail.Where(d => d.RequisitionNo == req.RequisitionNo));
                    _context.TblRequisition.Remove(req);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
                
                //return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return false;
                //return RedirectToAction(nameof(Index));
            }
        }

        public ActionResult Update(int id)
        {
            Models.TblRequisition reqModel = new Models.TblRequisition();
            var dt = _context.TblRequisition.Where(s => s.Id == id).First();
            reqModel.Id = dt.Id;
            reqModel.RequisitionNo = dt.RequisitionNo;
            reqModel.RequisitionDate = dt.RequisitionDate;
            reqModel.BatchNo = dt.BatchNo;
            reqModel.NumberOfBatch = dt.NumberOfBatch;
            reqModel.BatchSize = _context.View_BOM.Where(s => s.ProductCode == dt.ProductCode).FirstOrDefault().BatchSize;
            reqModel.StandardOutput = _context.View_BOM.Where(s => s.ProductCode == dt.ProductCode).FirstOrDefault().StandardOutput;
            reqModel.ProductCode = dt.ProductCode;
            reqModel.ProductName = _context.View_Product.Where(s => s.ProductCode == dt.ProductCode).FirstOrDefault().ProductName;
            reqModel.Comments = dt.Comments;
            reqModel.ExtOfRequisitionNo = dt.ExtOfRequisitionNo;
            reqModel.TblRequisitionDetail = _context.TblRequisitionDetail.Where(d => d.RequisitionNo == dt.RequisitionNo).ToList();
            reqModel.BOMId = dt.BOMId;

            var requisitionDetail = from reqDtl in _context.TblRequisitionDetail
                                 from mat in _context.View_Material
                                 where (reqDtl.RequisitionNo == dt.RequisitionNo && reqDtl.MaterialCode == mat.MaterialCode)
                                 orderby reqDtl.MaterialCode
                                select new TblRequisitionDetail
                                 {
                                     Id = reqDtl.Id,
                                     MaterialCode = reqDtl.MaterialCode,
                                     MaterialName = mat.MaterialName,
                                     Unit = mat.BaseUnit,
                                     StandardRecipeQty = reqDtl.StandardRecipeQty,
                                     FloorStock = reqDtl.FloorStock,
                                     RequiredQty = reqDtl.RequiredQty,
                                     AvailableStock = reqDtl.AvailableStock
                                 };

            reqModel.TblRequisitionDetail = requisitionDetail.ToList();

            
            return View(reqModel);
        }

        [HttpPost, ActionName("UpdateRequisition")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateRequisition(int id, TblRequisition req)
        {
            if (id != req.Id)
            {
                return NotFound();
            }
            try
            {
                //eFTestContext.Update(emp);
                //await eFTestContext.SaveChangesAsync();

                var requisitionToUpdate = await _context.TblRequisition.FirstOrDefaultAsync(s => s.Id == id);

                if (IsEditableDeleteable(req.RequisitionNo) == true)
                {
                    requisitionToUpdate.Euser = User.Identity.Name;
                    requisitionToUpdate.Edate = DateTime.Now;
                    if (await TryUpdateModelAsync<TblRequisition>(
                        requisitionToUpdate,
                        "",
                        s => s.RequisitionNo, s => s.RequisitionDate, s => s.BatchNo, s => s.NumberOfBatch, s => s.ProductCode, s => s.Comments, s => s.Euser, s => s.Edate, s => s.ExtOfRequisitionNo))

                        _context.TblRequisitionDetail.RemoveRange(_context.TblRequisitionDetail.Where(d => d.RequisitionNo == req.RequisitionNo));

                    if (req.TblRequisitionDetail != null)
                    {
                        foreach (var item in req.TblRequisitionDetail.ToList())
                        {
                            TblRequisitionDetail reqDetail = new TblRequisitionDetail();
                            reqDetail.RequisitionNo = req.RequisitionNo;
                            reqDetail.MaterialCode = item.MaterialCode;
                            reqDetail.StandardRecipeQty = item.StandardRecipeQty;
                            reqDetail.FloorStock = item.FloorStock;
                            reqDetail.RequiredQty = item.RequiredQty;
                            reqDetail.AvailableStock = item.AvailableStock;

                            await _context.AddAsync(reqDetail);
                        }
                        await _context.SaveChangesAsync();
                    }
                }
                else
                {

                    TempData["AlertMessage"] = "Can't edit, May have data dependency !";

                }

                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException ex)
            {
                //Log the error (uncomment ex variable name and write a log.)
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists, " +
                    "see your system administrator.");
            }
            //}
            return View(req);
        }

        private bool IsEditableDeleteable(string reqNo)
        {
            int countApp = 0;
            int countIssued = 0;
            countApp = _context.TblRequisitionApprovalStatus.Where(a => a.RequisitionNo == reqNo && a.ApprovalStatus== "Approved").Count();
            countIssued = _context.TblRequisition.Where(r => r.RequisitionNo == reqNo && r.IssueStatus== "Issued").Count();
            if ((countApp + countIssued) > 0)
            {
                return false;
            }
            else
            { 
                return true;
            }
        }

        public IActionResult SearchProduct()
        {
            //var model = new List<TblRequisition>(from c in npsContext.View_Product 
            //                                     select c);

            var model = new List<TblRequisition>(from b in _context.View_BOM
                        from p in _context.View_Product
                        where (b.ProductCode == p.ProductCode) && b.IsActive == "Y"
                        select new TblRequisition
                        {
                            ProductCode = b.ProductCode,
                            ProductName = p.ProductName,
                            StandardOutput = b.StandardOutput,
                            BatchSize = b.BatchSize
                        });

            return PartialView("_ProductPartial", model);
        }


        [HttpPost]
        public JsonResult SetProduct(string productId)
        {
            var keyVal = _context.View_BOM.Where(c => c.ProductCode == productId).ToList();
            if (keyVal != null)
            {
                productId = keyVal.FirstOrDefault().ProductCode;
            }

            if (productId.Length >= 0)
            {
                var sa = new JsonSerializerSettings();
                
                //var productInfo = from b in _context.View_BOM
                //                  from p in _context.View_Product
                //                  where (b.ProductCode == p.ProductCode && b.ProductCode == productId && b.IsActive == "Y")
                //                  select new TblRequisition
                //                  {
                //                      ProductCode = b.ProductCode,
                //                      ProductName = p.ProductName,
                //                      StandardOutput = b.StandardOutput,
                //                      BatchSize = b.BatchSize,
                //                      MonthlyPlannedQty = MonthlyPlannedQTY(productId)
                //                  };

                var productNoParam = new SqlParameter("@productId", productId);

                var productInfo = _context.SetProductInfoWithPlanning
                                    .FromSql("EXEC sp_SetProductInfoWithPlanning @productId", productNoParam)
                                    .ToList();

                return Json(productInfo, sa);
            }
            else
            {
                return Json("");
            }
        }

        public decimal MonthlyPlannedQTY(string productCode)
        {
            var monthlyPlanningQty = from mp in _context.TblMonthlyPlanning
                              from mpd in _context.TblMonthlyPlanningDetail 
                              where (mp.PlanningNo == mpd.PlanningNo && mpd.Fgcode == productCode 
                                        && mp.Year == DateTime.Now.Year && mp.Month == DateTime.Now.ToString("MMMM"))
                              select new 
                              {
                                  revisedPlanQty = (mp==null ||  mpd==null)?0: mpd.RevisedPlanQty
                              };
            decimal revisedPlanQty = 0;
            if (monthlyPlanningQty.Count() > 0)
            {
                revisedPlanQty = monthlyPlanningQty.FirstOrDefault().revisedPlanQty;
            }
            return revisedPlanQty;
        }

        [HttpPost]
        public JsonResult SearchProductByKey(string searchKey)
        {
            var errorViewModel = new ErrorViewModel();
            var sa = new JsonSerializerSettings();
            var productList = from b in _context.View_BOM
                              from p in _context.View_Product
                              where (b.ProductCode == p.ProductCode) && b.IsActive == "Y"
                              && (b.ProductCode.ToUpper().Contains(searchKey.ToUpper()) || (p.ProductName.ToUpper().Contains(searchKey.ToUpper())))
                              select new TblRequisition
                              {
                                  ProductCode = b.ProductCode,
                                  ProductName = p.ProductName,
                                  StandardOutput = b.StandardOutput,
                                  BatchSize = b.BatchSize
                              };
            return Json(productList, sa);
        }

        [HttpPost]
        public JsonResult GetBOMDetail(string productId, decimal noOfBatch)
        {
            var errorViewModel = new ErrorViewModel();
            var sa = new JsonSerializerSettings();
            //var productList = from b in _context.View_BOM
            //                  from p in _context.View_Product
            //                  from bd in _context.View_BOMDetail
            //                  from m in _context.View_Material                              
            //                  where (b.ProductCode == p.ProductCode && b.Id == bd.Bomid && bd.MaterialCode == m.MaterialCode)
            //                  && (b.ProductCode == productId) && b.IsActive=="Y"
            //                  orderby bd.MaterialCode
            //                  select new TblRequisitionDetail
            //                  {
            //                      MaterialCode = bd.MaterialCode,
            //                      MaterialName = m.MaterialName,
            //                      Unit = m.BaseUnit,
            //                      StandardRecipeQty = bd.QuantityPerBatch * noOfBatch,
            //                      FloorStock = 0,
            //                      RequiredQty = bd.QuantityPerBatch * noOfBatch,
            //                      AvailableStock = 0
            //                  };

            var requisitionNoParam = new SqlParameter("@productId", productId);
            var productionQtyParam = new SqlParameter("@noOfBatch", noOfBatch);

            var productList = _context.GetProductWiseBOMDetail
                                .FromSql("EXEC sp_GetProductWiseBOMDetail @productId, @noOfBatch", requisitionNoParam, productionQtyParam)
                                .ToList();

            return Json(productList, sa);
        }

        public IActionResult AddMaterialSearch()
        {
            Models.TblRequisitionDetail materialSearchModel = new Models.TblRequisitionDetail();
            return PartialView("_MaterialSearchPartial", materialSearchModel);
        }

        [HttpPost]
        public JsonResult SearchMaterial(string MaterialSearchKey)
        {
            var model = new List<TblRequisitionDetail>(from b in _context.View_Material
                                                 where ((b.MaterialCode.ToUpper().Contains(MaterialSearchKey.ToUpper()) || b.MaterialName.ToUpper().Contains(MaterialSearchKey.ToUpper())))
                                                 select new TblRequisitionDetail
                                                 {
                                                     MaterialCode = b.MaterialCode,
                                                     MaterialName = b.MaterialName,
                                                     Unit = b.BaseUnit,
                                                     RequiredQty = 0
                                                 });
            var sa = new JsonSerializerSettings();
            return Json(model, sa);
        }

        [HttpPost]
        public JsonResult SetMaterial(string MaterialCode)
        {
            var keyVal = _context.View_Material.Where(c => c.MaterialCode == MaterialCode).ToList();
            if (keyVal != null)
            {
                MaterialCode = keyVal.FirstOrDefault().MaterialCode;
            }

            if (MaterialCode != "")
            {
                var sa = new JsonSerializerSettings();
                var materialInfo = from c in _context.View_Material.Where(c => c.MaterialCode == MaterialCode).ToList()
                                    select new
                                    {
                                        c.MaterialCode,
                                        c.MaterialName,
                                        c.BaseUnit
                                    };
                return Json(materialInfo, sa);
            }
            else
            {
                return Json("");
            }
        }

        public IActionResult SearchRequisition()
        {
            var model = new List<TblRequisition>(from r in _context.TblRequisition
                                                 from p in _context.View_Product
                                                 where (r.ProductCode == p.ProductCode && r.ExtOfRequisitionNo==null)
                                                 orderby r.RequisitionDate descending
                                                 select new TblRequisition
                                                 {
                                                     RequisitionNo = r.RequisitionNo,
                                                     RequisitionDate = r.RequisitionDate,
                                                     ProductCode = r.ProductCode,
                                                     ProductName = p.ProductName
                                                 });

            return PartialView("_RequisitionPartial", model);
        }

        public JsonResult SearchRequisitionByKey(string searchKey)
        {
            var errorViewModel = new ErrorViewModel();
            var sa = new JsonSerializerSettings();
            
            var reqList = from r in _context.TblRequisition
                          from p in _context.View_Product
                          where (r.ProductCode == p.ProductCode && r.ExtOfRequisitionNo == null)
                          && (r.RequisitionNo.ToUpper().Contains(searchKey.ToUpper()) || r.ProductCode.ToUpper().Contains(searchKey.ToUpper()) || (p.ProductName.ToUpper().Contains(searchKey.ToUpper())))
                          orderby r.RequisitionDate descending
                          select new TblRequisition
                          {
                              RequisitionNo = r.RequisitionNo,
                              RequisitionDate = r.RequisitionDate,
                              ProductCode = r.ProductCode,
                              ProductName = p.ProductName
                          };

            return Json(reqList, sa);
        }

    }
}
