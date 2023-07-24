using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LILI_FPMS.Models;
using LILI_IMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Org.BouncyCastle.Ocsp;

namespace LILI_IMS.Controllers
{

    [Authorize]
    public class StandardManHourController : Controller
    {
        private readonly dbFormulationProductionSystemContext _context;

        public StandardManHourController(dbFormulationProductionSystemContext context)
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

            var standardSetup = from s in _context.TblStandardManHourSetup
                        from p in _context.View_Product
                        where (s.ProductCode == p.ProductCode)
                        select new TblStandardManHourSetup
                        {
                            Id = s.Id,
                            ProductCode = s.ProductCode, 
                            ProductName = p.ProductName, 
                            StdHrPerBatchRM = s.StdHrPerBatchRM, 
                            StdManPowerPerBatchRM = s.StdManPowerPerBatchRM,
                            StdHrPerBatchPM = s.StdHrPerBatchPM,
                            StdManPowerPerBatchPM = s.StdManPowerPerBatchPM,
                            Comments = s.Comments
                        };

            //var plans = from s in _context.TblMonthlyPlanning select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                standardSetup = standardSetup.Where(s => s.ProductCode.Contains(searchString)
                                      || s.ProductName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    standardSetup = standardSetup.OrderByDescending(s => s.ProductCode);
                    break;
                case "empId_desc":
                    standardSetup = standardSetup.OrderByDescending(s => s.ProductName);
                    break;
                default:
                    standardSetup = standardSetup.OrderByDescending(s => s.ProductCode);
                    break;
            }
            int pageSize = 10;
            return View(await PaginatedList<TblStandardManHourSetup>.CreateAsync(standardSetup.AsNoTracking(), pageNumber ?? 1, pageSize));

        }

        public ActionResult Create()
        {
            TblStandardManHourSetup entities = new TblStandardManHourSetup();
            
            entities.Idate = DateTime.Now;
            entities.StdManPowerPerUnitRm = 0;
            entities.StdManPowerPerUnitPm = 0;
            return View(entities);
        }


        [HttpPost, ActionName("CreateStandardSetup")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateStandardSetup(TblStandardManHourSetup stdSetup)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    stdSetup.Iuser = User.Identity.Name;
                    stdSetup.Idate = DateTime.Now;
                    _context.Add(stdSetup);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    ViewData["Error"] = "Error message text.";
                    return View(stdSetup);
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
        //public ActionResult Delete(int id)
        {
            try
            {
                TblStandardManHourSetup stdSetup = _context.TblStandardManHourSetup.Where(s => s.Id == id).First();
                _context.TblStandardManHourSetup.Remove(stdSetup);
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
            Models.TblStandardManHourSetup stdModel = new Models.TblStandardManHourSetup();
            var dt = _context.TblStandardManHourSetup.Where(s => s.Id == id).First();
            stdModel.Id = dt.Id;
            stdModel.ProductCode = dt.ProductCode;
            stdModel.ProductName = _context.View_Product.Where(x=>x.ProductCode == dt.ProductCode).FirstOrDefault().ProductName;
            stdModel.StdHrPerBatchRM = dt.StdHrPerBatchRM;
            stdModel.StdManPowerPerBatchRM = dt.StdManPowerPerBatchRM;
            stdModel.StdManPowerPerUnitPm = dt.StdManPowerPerUnitPm;
            stdModel.StdManPowerPerUnitRm = dt.StdManPowerPerUnitRm;
            stdModel.StdHrPerBatchPM = dt.StdHrPerBatchPM;
            stdModel.StdManPowerPerBatchPM = dt.StdManPowerPerBatchPM;
            stdModel.Comments = dt.Comments;

            return View(stdModel);
        }        



        [HttpPost, ActionName("UpdateStandardSetup")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStandardSetup(int id, TblStandardManHourSetup stdSetup)
        {
            if (id != stdSetup.Id)
            {
                return NotFound();
            }
            try
            {
               
                var stdSetupToUpdate = await _context.TblStandardManHourSetup.FirstOrDefaultAsync(s => s.Id == id);
                stdSetupToUpdate.Edate = DateTime.Now;
                stdSetupToUpdate.Euser = User.Identity.Name;

                if (await TryUpdateModelAsync<TblStandardManHourSetup>(
                    stdSetupToUpdate,
                    "",
                    s => s.ProductCode, s => s.StdHrPerBatchRM, s => s.StdManPowerPerBatchRM, s => s.StdHrPerBatchPM, s => s.StdManPowerPerBatchPM, s => s.Comments ))

                 await _context.SaveChangesAsync();
            
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists, " +
                    "see your system administrator.");
            }
            return View(stdSetup);
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