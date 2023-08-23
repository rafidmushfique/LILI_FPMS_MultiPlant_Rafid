using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LILI_FPMS;
using LILI_IMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LILI_IMS.Controllers
{
    [Authorize]
    public class ShiftController : Controller
    {
        private readonly dbFormulationProductionSystemContext _context;

        private readonly IHttpContextAccessor _httpContextAccessor;
        private static long GlobalPlantId;
        public ShiftController(dbFormulationProductionSystemContext context, IHttpContextAccessor httpContextAccessor)
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

            var shifts = from s in _context.TblShiftSetup
                            select s;
            shifts = shifts.Where(s => s.PlantId == GlobalPlantId);
            if (!String.IsNullOrEmpty(searchString))
            {
                shifts = shifts.Where(s => s.ShiftName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    shifts = shifts.OrderByDescending(s => s.ShiftName);
                    break;
                
                default:
                    shifts = shifts.OrderBy(s => s.ShiftName);
                    break;
            }
            int pageSize = 7;
            return View(await PaginatedList<TblShiftSetup>.CreateAsync(shifts.AsNoTracking(), pageNumber ?? 1, pageSize));

            //return View(await employees.AsNoTracking().ToListAsync());
        }

        public ActionResult Create()
        {
            TblShiftSetup entities = new TblShiftSetup();
            return View(entities);
            //return View();
        }

        [HttpPost, ActionName("CreateShift")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateShift(TblShiftSetup shift)
          {
            try
            {
                if (ModelState.IsValid)
                {
                    shift.Iuser = User.Identity.Name;
                    shift.Idate = DateTime.Now;
                    shift.PlantId = GlobalPlantId;
                    _context.Add(shift);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    ViewData["Error"] = "Error message text.";
                    return View(shift);
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
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public bool Delete(int id)
        {
            try
            {
                TblShiftSetup shift = _context.TblShiftSetup.Where(s => s.Id == id).First();
                _context.TblShiftSetup.Remove(shift);
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

        public ActionResult Update(int id)
        {
            Models.TblShiftSetup shiftModel = new Models.TblShiftSetup();
            var dt = _context.TblShiftSetup.Where(s => s.Id == id).First();
            shiftModel.Id = dt.Id;
            shiftModel.ShiftCode = dt.ShiftCode;
            shiftModel.ShiftName = dt.ShiftName;
            shiftModel.StandardShiftHour = dt.StandardShiftHour;
            shiftModel.PlannedDownChangeTime = dt.PlannedDownChangeTime;
            shiftModel.ProductiveShiftHour = dt.ProductiveShiftHour;
            shiftModel.Comments = dt.Comments;
            shiftModel.ShiftStartTime= dt.ShiftStartTime;
            shiftModel.ShiftEndTime= dt.ShiftEndTime;
            return View(shiftModel);
        }

        [HttpPost, ActionName("UpdateShift")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateShift(int id, TblShiftSetup shift)
        {
            if (id != shift.Id)
            {
                return NotFound();
            }
            try
            {
                //eFTestContext.Update(shift);
                //await eFTestContext.SaveChangesAsync();

                var shiftToUpdate = await _context.TblShiftSetup.FirstOrDefaultAsync(s => s.Id == id);
                shiftToUpdate.Edate = DateTime.Now;
                shiftToUpdate.Euser = User.Identity.Name;
                if (await TryUpdateModelAsync<TblShiftSetup>(
                    shiftToUpdate,
                    "",
                    s => s.ShiftCode, s => s.ShiftName, s => s.StandardShiftHour, s => s.PlannedDownChangeTime, s => s.ProductiveShiftHour, s => s.Comments, s => s.Euser, s => s.Edate
                    , s => s.ShiftStartTime, s => s.ShiftEndTime))

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException ex)
            {
                //Log the error (uncomment ex variable name and write a log.)
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists, " +
                    "see your system administrator.");
            }
            return View(shift);
        }



    }
}
