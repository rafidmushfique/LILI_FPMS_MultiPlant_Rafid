using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LILI_IMS.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Microsoft.AspNetCore.Authorization;

namespace LILI_IMS.Controllers
{
    [Authorize]
    public class RmRateController : Controller
    {
        private readonly dbFormulationProductionSystemContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;

        public RmRateController(dbFormulationProductionSystemContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
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
            var query = from s in _context.tblRMRate select s;

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query
                    .Where(s => s.PlantCode.Contains(searchString) || s.ItemCode.Contains(searchString) || s.Period.Contains(searchString));
            }

            //switch (sortOrder)
            //{
            //    case "name_desc":
            //        Lines = Lines.OrderByDescending(s => s.LineName);
            //        break;

            //    default:
            //        Lines = Lines.OrderBy(s => s.LineName);
            //        break;
            //}
            int pageSize = 10;
            return View(await PaginatedList<tblRMRate>.CreateAsync(query.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost, ActionName("UploadRate")]
        [ValidateAntiForgeryToken]
        public IActionResult UploadRate()
        {
            try
            {
                IFormFile file = Request.Form.Files[0];
                string folderName = "RMUpload";
                string webRootPath = _hostingEnvironment.WebRootPath;
                string newPath = Path.Combine(webRootPath, folderName);
                if (!Directory.Exists(newPath))
                {
                    Directory.CreateDirectory(newPath);
                }

                var rmRates = new List<tblRMRate>();

                string fileExtension = Path.GetExtension(file.FileName).ToLower();
                ISheet sheet;
                string fullPath = Path.Combine(newPath, file.FileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                    stream.Position = 0;
                    if (fileExtension == ".xls")
                    {
                        HSSFWorkbook hssfwb = new HSSFWorkbook(stream); //This will read the Excel 97-2000 formats  
                        sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook  
                    }
                    else
                    {
                        XSSFWorkbook hssfwb = new XSSFWorkbook(stream); //This will read 2007 Excel format 
                        sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook   
                    }

                    IRow headerRow = sheet.GetRow(0); //Get Header Row
                    int cellCount = headerRow.LastCellNum;

                    for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++) //Read Excel File
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue;
                        if (row.Cells.All(d => d.CellType == CellType.Blank)) continue;

                        var plantCode = row.GetCell(0) != null ? row.GetCell(0).ToString() : "";
                        var ItemCode = row.GetCell(1) != null ? row.GetCell(1).ToString() : "";
                        var period = row.GetCell(2) != null ? row.GetCell(2).ToString() : "";
                        var closingCost = row.GetCell(3) != null ? decimal.Parse(row.GetCell(3).ToString()) : 0;

                        if (string.IsNullOrEmpty(ItemCode)) throw new Exception("ItemCode is required.");
                        if (string.IsNullOrEmpty(period)) throw new Exception("period is required.");

                        rmRates.Add(new tblRMRate
                        {
                            PlantCode = plantCode,
                            ItemCode = ItemCode,
                            Period = period,
                            ClosingCost = closingCost,
                            Idate = DateTime.Now,
                            Iuser = User.Identity.Name
                        });
                    }
                }

                if (rmRates.Count() > 0)
                {
                    _context.tblRMRate.AddRange(rmRates);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"{ex.Message}");
                return View("Upload");
            }

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public bool Delete(int id)
        {
            try
            {
                tblRMRate rmRate = _context.tblRMRate.Find(id);
                _context.tblRMRate.Remove(rmRate);
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
            var rmRate = _context.tblRMRate.FirstOrDefault(x => x.Id == id);
            if (rmRate == null) throw new Exception($"RM Rate not found with this id {id}");

            return View(rmRate);
        }

        [HttpPost, ActionName("UpdateRmRate")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateRmRate(int id, tblRMRate rmRate)
        {
            if (id != rmRate.Id)
            {
                return NotFound();
            }

            try
            {
                var model = await _context.tblRMRate.FirstOrDefaultAsync(s => s.Id == id);

                model.PlantCode = rmRate.PlantCode;
                model.ItemCode = rmRate.ItemCode;
                model.Period = rmRate.Period;
                model.ClosingCost = rmRate.ClosingCost;

                model.Edate = DateTime.Now;
                model.Euser = User.Identity.Name;
                
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists, " +
                    "see your system administrator.");
            }
            return View(rmRate);
        }


    }
}
