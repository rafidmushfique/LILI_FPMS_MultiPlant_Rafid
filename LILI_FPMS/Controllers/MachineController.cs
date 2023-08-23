using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LILI_FPMS;
using LILI_FPMS.Models;
using LILI_IMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace LILI_IMS.Controllers
{
    [Authorize]
    public class MachineController : Controller
    {
        private readonly dbFormulationProductionSystemContext _context;

        private readonly IHttpContextAccessor _httpContextAccessor;
        private static long GlobalPlantId;

        public MachineController(dbFormulationProductionSystemContext context, IHttpContextAccessor httpContextAccessor)
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
            var machines = from s in _context.TblMachineSetup
                           from m in _context.TblMachineName
                           from p in _context.View_Product
                           where s.ProductCode == p.ProductCode && s.MachineCode == m.MachineCode && s.PlantId == GlobalPlantId
                           select new TblMachineSetup
                           { 
                            Id= s.Id,   
                            ProductCode= p.ProductCode,
                            ProductName= p.ProductName,
                            MachineCode = s.MachineCode,
                            MachineName = m.MachineName,
                            Capacity = s.Capacity,
                            Speed = s.Speed,
                            Comments = s.Comments

                           };

            if (!String.IsNullOrEmpty(searchString))
            {
                machines = machines.Where(s => s.ProductName.Contains(searchString) || s.MachineCode.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    machines = machines.OrderByDescending(s => s.ProductName);
                    break;
                
                default:
                    machines = machines.OrderBy(s => s.ProductName);
                    break;
            }
            int pageSize = 7;
            return View(await PaginatedList<TblMachineSetup>.CreateAsync(machines.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        public ActionResult Create()
        {
            TblMachineSetup entities = new TblMachineSetup();
            List<TblMachineName> machineList = new List<TblMachineName>();
            machineList = (from c in _context.TblMachineName.Where(c=>c.PlantId == GlobalPlantId)
                           select c).ToList();
            machineList.Insert(0, new TblMachineName { MachineCode = "", MachineName = "Select Machine" });
            ViewBag.ListofMachine = machineList;
            return View(entities);
        }

        [HttpPost, ActionName("CreateMachine")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMachine(TblMachineSetup machine)
          {
            try
            {
                if (ModelState.IsValid)
                {
                    machine.Iuser = User.Identity.Name;
                    machine.Idate = DateTime.Now;
                    machine.PlantId = GlobalPlantId;
                    _context.Add(machine);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    ViewData["Error"] = "Error message text.";
                    return View(machine);
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
                TblMachineSetup machine = _context.TblMachineSetup.Where(s => s.Id == id).First();
                _context.TblMachineSetup.Remove(machine);
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
            Models.TblMachineSetup machineModel = new Models.TblMachineSetup();
            var dt = _context.TblMachineSetup.Where(s => s.Id == id).First();
            machineModel.Id = dt.Id;
            machineModel.ProductCode = dt.ProductCode;
            machineModel.ProductName = _context.View_Product.Where(s => s.ProductCode == dt.ProductCode).FirstOrDefault().ProductName;
            machineModel.MachineCode = dt.MachineCode;
            //machineModel.MachineName = dt.MachineName;
            machineModel.Capacity = dt.Capacity;
            machineModel.Speed = dt.Speed;
            machineModel.Comments = dt.Comments;
            machineModel.CapacityPacking = dt.CapacityPacking;
            machineModel.SpeedPacking = dt.SpeedPacking;

            List<TblMachineName> machineList = new List<TblMachineName>();
            machineList = (from c in _context.TblMachineName
                           select c).ToList();
            machineList.Insert(0, new TblMachineName { MachineCode = "", MachineName = "Select Machine" });
            ViewBag.ListofMachine = machineList;
            return View(machineModel);
        }

        [HttpPost, ActionName("UpdateMachine")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateMachine(int id, TblMachineSetup machine)
        {
            if (id != machine.Id)
            {
                return NotFound();
            }
            try
            {               
                var machineToUpdate = await _context.TblMachineSetup.FirstOrDefaultAsync(s => s.Id == id);
                machineToUpdate.Edate = DateTime.Now;
                machineToUpdate.Euser = User.Identity.Name;
                if (await TryUpdateModelAsync<TblMachineSetup>(
                    machineToUpdate,
                    "",
                    s => s.MachineCode, s => s.Capacity, s => s.Speed, s => s.Comments, s => s.ProductCode, s => s.CapacityPacking, s => s.SpeedPacking))

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists, " +
                    "see your system administrator.");
            }
            return View(machine);
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

            if (ProductCode != "")
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
