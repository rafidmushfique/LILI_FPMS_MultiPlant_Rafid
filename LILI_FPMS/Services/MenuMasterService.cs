using LILI_IMS.Data;
using LILI_IMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LILI_IMS.Services
{
    public class MenuMasterService:IMenuMasterService
    {
        private readonly dbFormulationProductionSystemContext _dbContext;
        //dbEFTestContext _dbContext = new dbEFTestContext();

        public MenuMasterService(dbFormulationProductionSystemContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<MenuMaster> GetMenuMaster()
        {
            return _dbContext.MenuMaster.AsEnumerable();
        }

        public IEnumerable<MenuMaster> GetMenuMaster(string UserRole)
        {
            //var result = _dbContext.MenuMaster.Where(m => m.UserRoll == UserRole).ToList();
            var result = _dbContext.MenuMaster.Where(m => m.UserRoll == UserRole).OrderBy(m=>m.CreatedDate).ToList();
            return result;
        }
    }
}
