using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LILI_FPMS.Models;
using LILI_IMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace LILI_IMS.Controllers
{
    public class MaintenanceInformationController : Controller
    {
        private readonly dbFormulationProductionSystemContext _context;

        public MaintenanceInformationController(dbFormulationProductionSystemContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {

            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "date_desc" : "";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var maintenanceinfo = from mi in _context.TblMaintenanceInformation
                                  from m in _context.TblMachineName
                                  where mi.MachineCode == m.MachineCode
                                  select new TblMaintenanceInformation
                                  {
                                      Id=mi.Id,
                                      MachineCode=mi.MachineCode,
                                      MaintenanceName=mi.MaintenanceName,
                                      MaintenanceDate=mi.MaintenanceDate,
                                      MaintenanceHour=mi.MaintenanceHour,
                                      Description=mi.Description,
                                      MaintenanceType=mi.MaintenanceType,
                                      MaintenanceCode=mi.MaintenanceCode,
                                      MachineName= m.MachineName
                                  };
            if (!String.IsNullOrEmpty(searchString))
            {
                maintenanceinfo = maintenanceinfo.Where(s => s.MaintenanceName.Contains(searchString) || s.MachineCode.Contains(searchString) || s.MachineName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "date_desc":
                    maintenanceinfo = maintenanceinfo.OrderByDescending(s => s.MaintenanceDate);
                    break;

                default:
                    maintenanceinfo = maintenanceinfo.OrderBy(s => s.Id);
                    break;
            }
            int pageSize = 7;
           
            return View(await PaginatedList<TblMaintenanceInformation>.CreateAsync(maintenanceinfo.AsNoTracking(), pageNumber ?? 1, pageSize));

        }
        public ActionResult Create()
        {
            String sDate = DateTime.Now.ToString();
            DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));
            //String dy = datevalue.Day.ToString("00");
            String mn = datevalue.Month.ToString("00");
            String yy = datevalue.Year.ToString().Substring(2, 2);
            var logNo = "MI-" + yy + mn;
            String maxId = "";
            String maxNo = (from c in _context.TblMaintenanceInformation.Where(c => c.MaintenanceCode.Substring(0, 7) == logNo).OrderByDescending(t => t.Id) select c.MaintenanceCode.Substring(8, 3)).FirstOrDefault();
            if (maxNo == null)
            {
                maxId = "001";
            }
            else
            {
                maxId = (Convert.ToInt16(maxNo) + 1).ToString("000");
            }
            logNo = "MI-" + yy + mn + maxId;

            TblMaintenanceInformation entities = new TblMaintenanceInformation();
            entities.MaintenanceCode = logNo;
            List<TblMachineName> machineList = new List<TblMachineName>();

            machineList = (from m in _context.TblMachineName
                           select m).ToList();
            machineList.Insert(0, new TblMachineName { MachineCode = "", MachineName = "Select Machine" });


            ViewBag.ListofMachine = machineList;
            //ViewBag.ListofTypes
            return View(entities);
        }
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMaintenanceInfo(TblMaintenanceInformation maintenanceinfo) 
        {
            try
            {
                if (ModelState.IsValid)
                {
                    maintenanceinfo.Iuser = User.Identity.Name;
                    maintenanceinfo.Idate = DateTime.Now;
                    _context.Add(maintenanceinfo);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    ViewData["Error"] = "Error message text.";
                   // return View(machine);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
                return RedirectToAction(nameof(Index));
            }
            
        }
        [HttpPost]
        public bool Delete(int id)
        {
            try
            {
                TblMaintenanceInformation maintenanceinfo = _context.TblMaintenanceInformation.Where(s => s.Id == id).First();
                _context.TblMaintenanceInformation.Remove(maintenanceinfo);
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

            Models.TblMaintenanceInformation maintenanceinfo = new Models.TblMaintenanceInformation();
            var dt = _context.TblMaintenanceInformation.Where(s => s.Id == id).First();
            maintenanceinfo.Id = dt.Id;
            maintenanceinfo.MaintenanceCode = dt.MaintenanceCode;
            maintenanceinfo.MachineCode     = dt.MachineCode;
            maintenanceinfo.MaintenanceName = dt.MaintenanceName;
            maintenanceinfo.MaintenanceDate = dt.MaintenanceDate;
            maintenanceinfo.MaintenanceHour = dt.MaintenanceHour;
            maintenanceinfo.MaintenanceType = dt.MaintenanceType;
            maintenanceinfo.Description     = dt.Description;

            List<TblMachineName> machineList = new List<TblMachineName>();
            machineList = (from c in _context.TblMachineName
                           select c).ToList();
            machineList.Insert(0, new TblMachineName { MachineCode = "", MachineName = "Select Machine" });
            ViewBag.ListofMachine = machineList;

            return View(maintenanceinfo);

            
        }

        [HttpPost, ActionName("UpdateMaintenanceInfo")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateMaintenanceInfo(int id, TblMaintenanceInformation maintenanceinfo)
        {
            if (id != maintenanceinfo.Id)
            {
                return NotFound();
            }
            try
            {
                var maintenanceinfoToUpdate = await _context.TblMaintenanceInformation.FirstOrDefaultAsync(s => s.Id == id);
                maintenanceinfoToUpdate.Edate = DateTime.Now;
                maintenanceinfoToUpdate.Euser = User.Identity.Name;
                if (await TryUpdateModelAsync<TblMaintenanceInformation>(
                    maintenanceinfoToUpdate,
                    "",
                  
                       s => s.MaintenanceName,
                       s => s.MachineCode,
                       s => s.MaintenanceDate,
                       s => s.MaintenanceHour,
                       s => s.MaintenanceType,
                       s => s.Description
                    ))

                    await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists, " +
                    "see your system administrator.");
            }
            return View(maintenanceinfo);
        }
    }
}
