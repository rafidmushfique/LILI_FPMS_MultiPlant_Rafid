using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LILI_FPMS;
using LILI_IMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LILI_IMS.Controllers
{
    [Authorize]
    public class QCParameterController : Controller
    {
        private readonly dbFormulationProductionSystemContext _context;

        private readonly IHttpContextAccessor _httpContextAccessor;
        private static long GlobalPlantId;

        public QCParameterController(dbFormulationProductionSystemContext context, IHttpContextAccessor httpContextAccessor)
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

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            //var parameters = from s in _context.TblQcparameter select s;

            var parameters = from s in _context.TblQcparameter.Where(s=>s.PlantId == GlobalPlantId)
                      from p in _context.View_Product
                      where s.ProductCode == p.ProductCode
                      select new TblQcparameter
                      {
                          Id = s.Id,
                          ProductCode = s.ProductCode,
                          ProductName = p.ProductName,
                          QcparameterCode = s.QcparameterCode,
                          QcparameterName = s.QcparameterName,
                          QcparameterStandardValue = s.QcparameterStandardValue,
                          Comments = s.Comments
                      };


            if (!String.IsNullOrEmpty(searchString))
            {
                parameters = parameters.Where(s => s.QcparameterName.Contains(searchString)|| s.ProductCode.Contains(searchString) || s.ProductName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    parameters = parameters.OrderByDescending(s => s.QcparameterName);
                    break;
                
                default:
                    parameters = parameters.OrderBy(s => s.QcparameterName);
                    break;
            }
            int pageSize = 7;
            return View(await PaginatedList<TblQcparameter>.CreateAsync(parameters.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        public ActionResult Create()
        {
            TblQcparameter entities = new TblQcparameter();

            List<TblQcparameterType> typeList = new List<TblQcparameterType>();
            typeList = (from c in _context.TblQcparameterType
                        select c).ToList();
            typeList.Insert(0, new TblQcparameterType { TypeCode = "0", TypeName = "Select Type" });
            ViewBag.ListOfType = typeList;

            entities.ProductCode = Convert.ToString(TempData["ProductCode"]);
            entities.ProductName = (entities.ProductCode =="" || entities.ProductCode == null) ?"":_context.View_Product.Where(x => x.ProductCode == entities.ProductCode).FirstOrDefault().ProductName;

            return View(entities);
        }

        [HttpPost, ActionName("CreateQCParameter")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateQCParameter(TblQcparameter parameter)
          {
            try
            {
                if (ModelState.IsValid)
                {
                    parameter.PlantId = GlobalPlantId;
                    _context.Add(parameter);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    ViewData["Error"] = "Error message text.";
                    return View(parameter);
                }
                TempData["ProductCode"] = parameter.ProductCode;

                //return RedirectToAction(nameof(Index));
                return RedirectToAction(nameof(Create));
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            //return RedirectToAction(nameof(Index));
            return RedirectToAction(nameof(Create));
        }

        [HttpPost]
        public bool Delete(int id)
        {
            try
            {
                TblQcparameter parameter = _context.TblQcparameter.Where(s => s.Id == id).First();
                _context.TblQcparameter.Remove(parameter);
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
            Models.TblQcparameter parameterModel = new Models.TblQcparameter();
            var dt = _context.TblQcparameter.Where(s => s.Id == id).First();
            parameterModel.Id = dt.Id;
            parameterModel.TypeCode = dt.TypeCode;
            parameterModel.ProductCode = dt.ProductCode;
            parameterModel.ProductName = dt.ProductCode==null?"": _context.View_Product.Where(x => x.ProductCode == dt.ProductCode).FirstOrDefault().ProductName;
            parameterModel.QcparameterCode = dt.QcparameterCode;
            parameterModel.QcparameterName = dt.QcparameterName;
            parameterModel.QcparameterStandardValue = dt.QcparameterStandardValue;
            parameterModel.Comments = dt.Comments;

            List<TblQcparameterType> typeList = new List<TblQcparameterType>();
            typeList = (from c in _context.TblQcparameterType
                        select c).ToList();
            typeList.Insert(0, new TblQcparameterType { TypeCode = "0", TypeName = "Select Type" });
            ViewBag.ListOfType = typeList; 

            return View(parameterModel);
        }

        [HttpPost, ActionName("UpdateQCParameter")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateQCParameter(int id, TblQcparameter shift)
        {
            if (id != shift.Id)
            {
                return NotFound();
            }
            try
            {
                var parameterToUpdate = await _context.TblQcparameter.FirstOrDefaultAsync(s => s.Id == id);                
                if (await TryUpdateModelAsync<TblQcparameter>(
                    parameterToUpdate,
                    "",
                    s => s.QcparameterCode, s => s.QcparameterName, s => s.QcparameterStandardValue, s => s.Comments, s => s.ProductCode))

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists, " +
                    "see your system administrator.");
            }
            return View(shift);
        }

        public IActionResult addProduct()
        {
            Models.TblMonthlyPlanningDetail planModel = new Models.TblMonthlyPlanningDetail();
            return PartialView("_ProductAreaPartial", planModel);
        }

    }
}
