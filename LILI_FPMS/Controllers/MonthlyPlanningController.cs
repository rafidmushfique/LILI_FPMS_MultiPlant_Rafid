using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LILI_IMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace LILI_IMS.Controllers
{

    [Authorize]
    public class MonthlyPlanningController : Controller
    {
        private readonly dbFormulationProductionSystemContext _context;

        public MonthlyPlanningController(dbFormulationProductionSystemContext context)
        {
            _context = context;
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

            var plans = from s in _context.TblMonthlyPlanning select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                plans = plans.Where(s => s.PlanningNo.Contains(searchString) 
                                      || s.Year.Equals(searchString)
                                      || s.Month.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    plans = plans.OrderByDescending(s => s.PlanningNo);
                    break;
                case "empId_desc":
                    plans = plans.OrderByDescending(s => s.PlanningNo);
                    break;
                //case "Date":
                //    employees = employees.OrderBy(s => s.EnrollmentDate);
                //    break;
                //case "date_desc":
                //    employees = employees.OrderByDescending(s => s.EnrollmentDate);
                //    break;
                default:
                    plans = plans.OrderByDescending(s => s.PlanningNo);
                    break;
            }
            int pageSize = 7;
            return View(await PaginatedList<TblMonthlyPlanning>.CreateAsync(plans.AsNoTracking(), pageNumber ?? 1, pageSize));

        }

        public ActionResult Create()
        {
            TblMonthlyPlanning entities = new TblMonthlyPlanning();
            //entities.Year = DateTime.Parse(DateTime.Now).Year;

            List<SelectListItem> Year = new List<SelectListItem>();
            //Year.Add(new SelectListItem { Text = "2020", Value = "2020" });
            Year.Add(new SelectListItem { Text = DateTime.Now.Year.ToString(), Value = DateTime.Now.Year.ToString() });
            Year.Add(new SelectListItem { Text = (DateTime.Now.Year +1).ToString(), Value = (DateTime.Now.Year+1).ToString() });
            ViewData["ddlYear"] = Year;

            List<SelectListItem> month = new List<SelectListItem>();
            month.Add(new SelectListItem { Text = "January", Value = "January" });
            month.Add(new SelectListItem { Text = "February", Value = "February" });
            month.Add(new SelectListItem { Text = "March", Value = "March" });
            month.Add(new SelectListItem { Text = "April", Value = "April" });
            month.Add(new SelectListItem { Text = "May", Value = "May" });
            month.Add(new SelectListItem { Text = "June", Value = "June" });
            month.Add(new SelectListItem { Text = "July", Value = "July" });
            month.Add(new SelectListItem { Text = "August", Value = "August" });
            month.Add(new SelectListItem { Text = "September", Value = "September" });
            month.Add(new SelectListItem { Text = "October", Value = "October" });
            month.Add(new SelectListItem { Text = "November", Value = "November" });
            month.Add(new SelectListItem { Text = "December", Value = "December" });
            ViewData["ddlMonth"] = month;

            entities.Idate = DateTime.Now;
            entities.PlanningNo = GetAutoNumber();

            return View(entities);
        }

        public string GetAutoNumber()
        {

            String sDate = DateTime.Now.ToString();
            DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));

            String dy = datevalue.Day.ToString("00");
            String mn = datevalue.Month.ToString("00");
            String yy = datevalue.Year.ToString("00").Substring(datevalue.Year.ToString("00").Length - 2);

            String Hour = datevalue.Hour.ToString("00");
            String Minute = datevalue.Month.ToString("00");
            String Second = datevalue.Second.ToString("00");
            //var ReqNo = user + dy + mn + yy;

            var ReqNo = yy + mn;//4 digit

            String maxId = "";
            
            //String maxNo = (from c in _tblCylinderReceivedService.BMSUnit.tblCylinderReceiveRepository.GetAll().Where(c => c.ReceiveNo.ToString().Substring(0, 4) == ReqNo).OrderByDescending(t => t.Id) select c.ReceiveNo.ToString().Substring(4, 6)).FirstOrDefault();

            var maxNo = (from s in _context.TblMonthlyPlanning 
                        where (s.PlanningNo.ToString().Substring(0,4) == ReqNo)
                        orderby s.Id descending
                        select s.PlanningNo.ToString().Substring(4,6)).FirstOrDefault();


            if (maxNo == null)
            {
                maxId = "000001";
            }
            else
            {
                maxId = (Convert.ToInt16(maxNo) + 1).ToString("000000");
            }


            var ReceiveNo = ReqNo + maxId;

            return ReceiveNo;

        }

        [HttpPost, ActionName("CreatePlan")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePlan(TblMonthlyPlanning plan)
        //[Bind("EnrollmentDate,FirstMidName,LastName")] Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //eFTestContext.Add(plan);
                    //await eFTestContext.SaveChangesAsync();

                    var planning = new TblMonthlyPlanning
                    {
                        PlanningNo = plan.PlanningNo,
                        Year = plan.Year,
                        Month = plan.Month,
                        Comments = plan.Comments,
                        Iuser = User.Identity.Name,
                        Idate = DateTime.Now
                    };
                    _context.TblMonthlyPlanning.Add(planning);
                    await _context.SaveChangesAsync();


                    if (plan.TblMonthlyPlanningDetail != null)
                    {
                        foreach (var item in plan.TblMonthlyPlanningDetail.ToList())
                        {
                            TblMonthlyPlanningDetail itemDetail = new TblMonthlyPlanningDetail();
                            itemDetail.PlanningNo = plan.PlanningNo;
                            itemDetail.Fgcode = item.Fgcode;
                            itemDetail.FgName = item.FgName;
                            itemDetail.ActualForecast = item.ActualForecast;
                            itemDetail.ReviewedForecast = item.ReviewedForecast;
                            itemDetail.OpeningStock = item.OpeningStock;
                            itemDetail.ProductionRequirement = item.ProductionRequirement;
                            itemDetail.PlanQty = item.PlanQty;
                            itemDetail.RevisedPlanQty = item.RevisedPlanQty;
                            itemDetail.Closing = item.Closing;
                            itemDetail.Comments = item.Comments;
                            await _context.AddAsync(itemDetail);
                        }
                    }
                    await _context.SaveChangesAsync();
                    TempData["Success"] = "Success message text.";

                }
                else
                {
                    ViewData["Error"] = "Error message text.";
                    return View(plan);
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
        //public ActionResult Delete(int id)
        {
            try
            {
                TblMonthlyPlanning plan = _context.TblMonthlyPlanning.Where(s => s.Id == id).First();
                _context.TblMonthlyPlanningDetail.RemoveRange(_context.TblMonthlyPlanningDetail.Where(d => d.PlanningNo == plan.PlanningNo));
                _context.TblMonthlyPlanning.Remove(plan);
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
            Models.TblMonthlyPlanning planModel = new Models.TblMonthlyPlanning();
            var dt = _context.TblMonthlyPlanning.Where(s => s.Id == id).First();
            planModel.Id = dt.Id;
            planModel.PlanningNo = dt.PlanningNo;
            planModel.Year = dt.Year;
            planModel.Month = dt.Month;
            planModel.Comments = dt.Comments;
            //planModel.TblMonthlyPlanningDetail = eFTestContext.TblMonthlyPlanningDetail.Where(d => d.PlanningNo == dt.PlanningNo).ToList();

            var plan_detail =    from master in _context.TblMonthlyPlanning
                                 from detail in _context.TblMonthlyPlanningDetail   
                                 from product in _context.View_Product
                                 where (master.PlanningNo == detail.PlanningNo)
                                 where (detail.Fgcode == product.ProductCode)                                 
                                 where (master.PlanningNo == dt.PlanningNo)
                                 select new TblMonthlyPlanningDetail
                                 {
                                     Id = detail.Id,
                                     Fgcode = detail.Fgcode,
                                     FgName = product.ProductName,
                                     ActualForecast =detail.ActualForecast,
                                     ReviewedForecast =detail.ReviewedForecast, 
                                     OpeningStock =detail.OpeningStock, 
                                     ProductionRequirement =detail.ProductionRequirement,
                                     PlanQty = detail.PlanQty,
                                     RevisedPlanQty = detail.RevisedPlanQty,
                                     Closing = detail.Closing,
                                     Comments = detail.Comments
                                 };


            planModel.TblMonthlyPlanningDetail = plan_detail.ToList();

            List<SelectListItem> Year = new List<SelectListItem>();
            //Year.Add(new SelectListItem { Text = "2020", Value = "2020" });
            Year.Add(new SelectListItem { Text = DateTime.Now.Year.ToString(), Value = DateTime.Now.Year.ToString() });
            Year.Add(new SelectListItem { Text = (DateTime.Now.Year + 1).ToString(), Value = (DateTime.Now.Year + 1).ToString() });
            ViewData["ddlYear"] = Year;

            List<SelectListItem> month = new List<SelectListItem>();
            month.Add(new SelectListItem { Text = "January", Value = "January" });
            month.Add(new SelectListItem { Text = "February", Value = "February" });
            month.Add(new SelectListItem { Text = "March", Value = "March" });
            month.Add(new SelectListItem { Text = "April", Value = "April" });
            month.Add(new SelectListItem { Text = "May", Value = "May" });
            month.Add(new SelectListItem { Text = "June", Value = "June" });
            month.Add(new SelectListItem { Text = "July", Value = "July" });
            month.Add(new SelectListItem { Text = "August", Value = "August" });
            month.Add(new SelectListItem { Text = "September", Value = "September" });
            month.Add(new SelectListItem { Text = "October", Value = "October" });
            month.Add(new SelectListItem { Text = "November", Value = "November" });
            month.Add(new SelectListItem { Text = "December", Value = "December" });
            ViewData["ddlMonth"] = month;

            return View(planModel);
        }        



        [HttpPost, ActionName("UpdatePlan")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdatePlan(int id, TblMonthlyPlanning plan)
        {
            if (id != plan.Id)
            {
                return NotFound();
            }
            try
            {
                //eFTestContext.Update(emp);
                //await eFTestContext.SaveChangesAsync();

                var planToUpdate = await _context.TblMonthlyPlanning.FirstOrDefaultAsync(s => s.Id == id);
                planToUpdate.Edate = DateTime.Now;
                planToUpdate.Euser = User.Identity.Name;

                if (await TryUpdateModelAsync<TblMonthlyPlanning>(
                    planToUpdate,
                    "",
                    s => s.PlanningNo, s => s.Year, s => s.Month, s => s.Comments ))

                _context.TblMonthlyPlanningDetail.RemoveRange(_context.TblMonthlyPlanningDetail.Where(d => d.PlanningNo == plan.PlanningNo));

                if (plan.TblMonthlyPlanningDetail != null)
                {
                    foreach (var item in plan.TblMonthlyPlanningDetail.ToList())
                    {
                        TblMonthlyPlanningDetail itemDetail = new TblMonthlyPlanningDetail();
                        itemDetail.PlanningNo = plan.PlanningNo;
                        itemDetail.Fgcode = item.Fgcode;
                        itemDetail.ActualForecast = item.ActualForecast;
                        itemDetail.ReviewedForecast = item.ReviewedForecast;
                        itemDetail.OpeningStock = item.OpeningStock;
                        itemDetail.ProductionRequirement = item.ProductionRequirement;
                        itemDetail.PlanQty = item.PlanQty;
                        itemDetail.RevisedPlanQty = item.RevisedPlanQty;
                        itemDetail.Closing = item.Closing;
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
            return View(plan);
        }

        public IActionResult addProduct()
        {
            Models.TblMonthlyPlanningDetail planModel = new Models.TblMonthlyPlanningDetail();
            return PartialView("_ProductAreaPartial", planModel);
        }

        [HttpPost]
        public JsonResult SearchProduct(string ProductSearchKey)
        {
            //var result = from p in eFTestContext.View_Product
            //             from bom in eFTestContext.View_BOM
            //             where (p.ProductCode == bom.ProductCode || p.ProductCode.ToUpper().Contains(ProductSearchKey) || p.ProductName.ToUpper().Contains(ProductSearchKey))
            //             select new { bom.ProductCode, p.ProductName };

            //var result = eFTestContext.View_Product.Where(s => s.ProductCode.ToUpper().Contains(ProductSearchKey) || s.ProductName.ToUpper().Contains(ProductSearchKey)).ToList();
            //var sa = new JsonSerializerSettings();
            //return Json(result, sa);

            var model = new List<TblRequisition>(from b in _context.View_BOM
                                                 from p in _context.View_Product
                                                 where (b.ProductCode == p.ProductCode && (b.ProductCode.ToUpper().Contains(ProductSearchKey.ToUpper()) || p.ProductName.ToUpper().Contains(ProductSearchKey.ToUpper())))
                                                 select new TblRequisition
                                                 {
                                                     ProductCode = b.ProductCode,
                                                     ProductName = p.ProductName
                                                 });
            var sa = new JsonSerializerSettings();
            return Json(model, sa);
        }

        [HttpPost]
        public JsonResult SetProduct(string ProductCode)
        {
            var keyVal = _context.View_Product.Where(c => c.ProductCode == ProductCode).ToList();
            if (keyVal != null)
            {
                ProductCode = keyVal.FirstOrDefault().ProductCode;
            }

            if (ProductCode !="")
            {
                var sa = new JsonSerializerSettings();
                var expertiesInfo = from c in _context.View_Product.Where(c => c.ProductCode == ProductCode).ToList()
                                    select new
                                    {
                                        c.ProductCode,
                                        c.ProductName
                                    };
                return Json(expertiesInfo, sa);
            }
            else
            {
                return Json("");
            }
        }
    }
}