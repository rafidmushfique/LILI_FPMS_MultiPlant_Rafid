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
    public class LineController : Controller
    {
        private readonly dbFormulationProductionSystemContext _context;

        private readonly IHttpContextAccessor _httpContextAccessor;
        private static long GlobalPlantId;
        public LineController(dbFormulationProductionSystemContext context, IHttpContextAccessor httpContextAccessor)
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
            var Lines = from s in _context.TblLineSetup.Where(s => s.PlantId == GlobalPlantId) select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                Lines = Lines.Where(s => s.LineName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    Lines = Lines.OrderByDescending(s => s.LineName);
                    break;
                
                default:
                    Lines = Lines.OrderBy(s => s.LineName);
                    break;
            }
            int pageSize = 10;
            return View(await PaginatedList<TblLineSetup>.CreateAsync(Lines.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        public ActionResult Create()
        {
            TblLineSetup entities = new TblLineSetup();
            return View(entities);
        }

        [HttpPost, ActionName("CreateLine")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateLine(TblLineSetup line)
          {
            try
            {
                if (ModelState.IsValid)
                {
                    line.Iuser = User.Identity.Name;
                    line.Idate = DateTime.Now;
                    line.PlantId = GlobalPlantId;
                    _context.Add(line);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    ViewData["Error"] = "Error message text.";
                    return View(line);
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
                TblLineSetup line = _context.TblLineSetup.Where(s => s.Id == id).First();
                _context.TblLineSetup.Remove(line);
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
            Models.TblLineSetup lineModel = new Models.TblLineSetup();
            var dt = _context.TblLineSetup.Where(s => s.Id == id).First();
            lineModel.Id = dt.Id;
            lineModel.LineCode = dt.LineCode;
            lineModel.LineName = dt.LineName;
            lineModel.Comments = dt.Comments;
            return View(lineModel);
        }

        [HttpPost, ActionName("UpdateLine")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateLine(int id, TblLineSetup line)
        {
            if (id != line.Id)
            {
                return NotFound();
            }
            try
            {
                var lineToUpdate = await _context.TblLineSetup.FirstOrDefaultAsync(s => s.Id == id);
                lineToUpdate.Edate = DateTime.Now;
                lineToUpdate.Euser = User.Identity.Name;
                if (await TryUpdateModelAsync<TblLineSetup>(
                    lineToUpdate,
                    "",
                    s => s.LineCode, s => s.LineName, s => s.Comments))

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists, " +
                    "see your system administrator.");
            }
            return View(line);
        }



    }
}
