
using LILI_FPMS.Models;
using LILI_IMS;
using LILI_IMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace LILI_FPMS.Controllers
{
    [Authorize]
    public class ProductWiseSectionSetupController : Controller
    {
        private readonly dbFormulationProductionSystemContext _context;

        public ProductWiseSectionSetupController(dbFormulationProductionSystemContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
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

            var pross = from s in _context.TblProductWiseSectionSetup
                        select new Models.TblProductWiseSectionSetup
                        {
                            Id = s.Id,
                            ProductCode= s.ProductCode=="0"?"All": s.ProductCode,
                            ProductName= s.ProductName=="0"?"All": s.ProductName,
                            PlantId=s.PlantId,
                        };

            if (!String.IsNullOrEmpty(searchString))
            {
                pross = pross.Where(s => s.ProductCode.Contains(searchString)
                                    || s.ProductName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "productCode_desc":
                    pross = pross.OrderByDescending(s => s.ProductCode);
                    break;
                case "productName_desc":
                    pross = pross.OrderByDescending(s => s.ProductName);
                    break;
            }
            int pageSize = 10;
            return View(await PaginatedList<TblProductWiseSectionSetup>.CreateAsync(pross.AsNoTracking(), pageNumber ?? 1, pageSize));
            //return View();
        }
        public ActionResult Create()
        {
            var model = new TblProductWiseSectionSetup();
               var list = new List<SelectListItem> {
               new SelectListItem{ Text="1", Value = "1", Selected = true },
               new SelectListItem{ Text="2", Value = "2" },
               new SelectListItem{ Text="3", Value = "3" },
               new SelectListItem{ Text="4", Value = "4"},
               new SelectListItem{ Text="5", Value = "5"},
            };
            var sectionList = from c in _context.TblSection.Where(c => c.PlantId == GlobalVariable.PlantId).OrderBy(c => c.Id)
                              select
                              new TblSection
                              {
                                  SectionCode = c.SectionCode,
                                  SectionName = c.SectionName,
                              };
            ViewBag.SectionList = sectionList.ToList();
            ViewBag.SelectionList=list;
            model.PlantId = GlobalVariable.PlantId;
            return View(model);
        }
        [HttpPost,ActionName("CreateProductWiseSection")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProductWiseSection(TblProductWiseSectionSetup prodwisesetup) {
            try {
                if (ModelState.IsValid)
                {
                    prodwisesetup.Iuser = User.Identity.Name;
                    prodwisesetup.Idate = DateTime.Now;
                    prodwisesetup.PlantId= GlobalVariable.PlantId; 
                    _context.Add(prodwisesetup);
                    await _context.SaveChangesAsync();
                    TempData["msg"] =  "Data Save Successful!";
                }
                else {
                    var errors = ModelState
                        .Where(x => x.Value.Errors.Count > 0)
                        .Select(x => new { x.Key, x.Value.Errors })
                        .ToArray();
                    TempData["msg"] = "Error Model Data!";
                    return View(nameof(Index));
                }
            }
            catch (Exception ex) {
              
                TempData["msg"] = "Unsuccessful To Save Data";
                
            }
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Update(int id)
        {
            TblProductWiseSectionSetup model = new TblProductWiseSectionSetup();
            var data = _context.TblProductWiseSectionSetup.Where(x => x.Id == id).First();
            var detalTbl= from c in _context.TblProductWiseSectionSetupDetail
                          where c.ProductSectionSetupId== id
                          select new TblProductWiseSectionSetupDetail { 
                            Id = c.Id,
                            ProductSectionSetupId = c.ProductSectionSetupId,
                            Section=c.Section,
                            Sequence=c.Sequence,
                            Comments=c.Comments,
                            IsQcrequired=c.IsQcrequired,
                            IsSetupCompleted=c.IsSetupCompleted,

                          };
            model.Id = data.Id;
            model.ProductCode = data.ProductCode;
            model.ProductName = data.ProductName;
            model.PlantId= data.PlantId;
            model.tblProductWiseSectionSetupDetails=detalTbl.ToList();
            var list = new List<SelectListItem> {
               new SelectListItem{ Text="1", Value = "1", Selected = true },
               new SelectListItem{ Text="2", Value = "2" },
               new SelectListItem{ Text="3", Value = "3" },
               new SelectListItem{ Text="4", Value = "4"},
               new SelectListItem{ Text="5", Value = "5"},
            };
            var sectionList = from c in _context.TblSection.Where(c => c.PlantId == GlobalVariable.PlantId).OrderBy(c => c.Id)
                              select
                              new TblSection
                              {
                                  SectionCode = c.SectionCode,
                                  SectionName = c.SectionName,
                              };
            ViewBag.SectionList = sectionList.ToList();
            ViewBag.SelectionList = list;

          
            return View(model);
        }
        [HttpPost, ActionName("UpdateProductWiseSection")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProductWiseSection(int id, TblProductWiseSectionSetup prodwisesetup) {
                if (id != prodwisesetup.Id)
                {
                    return NotFound();
                }
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {

                try
                {
                    var productwisesetuptoupdate = await _context.TblProductWiseSectionSetup.FirstOrDefaultAsync(p => p.Id == id);
                    productwisesetuptoupdate.Euser = User.Identity.Name;
                    productwisesetuptoupdate.Edate = DateTime.Now;
                    if (
                        await TryUpdateModelAsync<TblProductWiseSectionSetup>(
                        productwisesetuptoupdate,
                        "",
                        s => s.Euser,
                        s => s.Edate
                        )) ;
                    var productwisedetailtoRemove = _context.TblProductWiseSectionSetupDetail.Where(p => p.ProductSectionSetupId == id);
                    if (productwisedetailtoRemove != null)
                    {
                        _context.TblProductWiseSectionSetupDetail.RemoveRange(productwisedetailtoRemove);
                    }

                    if (prodwisesetup.tblProductWiseSectionSetupDetails != null)
                    {
                        foreach (var item in prodwisesetup.tblProductWiseSectionSetupDetails)
                        {
                            TblProductWiseSectionSetupDetail prodwisedetail = new TblProductWiseSectionSetupDetail();
                            prodwisedetail.ProductSectionSetupId = prodwisesetup.Id;
                            prodwisedetail.Section = item.Section;
                            prodwisedetail.Sequence = item.Sequence;
                            prodwisedetail.Comments = item.Comments;
                            prodwisedetail.IsQcrequired = item.IsQcrequired;
                            prodwisedetail.IsSetupCompleted = item.IsSetupCompleted;
                            await _context.AddAsync(prodwisedetail);
                        }
                        await _context.SaveChangesAsync();
                    }

                    return RedirectToAction("Update", new { id = id });
                }
                catch (Exception ex)
                {
                     transaction.Rollback();
                    //TempData["msg"] = "Update Failed!";

                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");

                }
                finally
                {
                     transaction.Commit();
                }
            }

            return View(prodwisesetup);
        }
        public bool Delete(int id)
        {
            try
            {
                TblProductWiseSectionSetup prod = _context.TblProductWiseSectionSetup.Where(s => s.Id == id).First();
                var removableDetails = _context.TblProductWiseSectionSetupDetail.Where(x => x.ProductSectionSetupId == id);
                _context.TblProductWiseSectionSetupDetail.RemoveRange(removableDetails);
                _context.TblProductWiseSectionSetup.Remove(prod);

                _context.TblManufacturingLine.RemoveRange(_context.TblManufacturingLine.Where(d => d.ProductionId == prod.Id));

                _context.SaveChanges();
                return true;
                //return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return false;
                //return RedirectToAction(nameof(Index));
            }
        }
        public bool DeleteDetail(int id)
        {
            try
            {
                var removableDetails = _context.TblProductWiseSectionSetupDetail.Where(x => x.Id == id).First();
                _context.TblProductWiseSectionSetupDetail.Remove(removableDetails);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
     
        }
        public IActionResult addProduct()
        {
            TblMonthlyPlanningDetail planModel = new TblMonthlyPlanningDetail();

           
            return PartialView("_ProductAreaPartial", planModel);
        }
        

    }
}
