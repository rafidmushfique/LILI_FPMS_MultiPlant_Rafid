using LILI_IMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LILI_FPMS.Controllers
{

    public class BaseController : Controller
    {
        public readonly dbFormulationProductionSystemContext _context;
        public readonly IHttpContextAccessor _httpContextAccessor;
        public static long GloablPlantId;
        public BaseController(dbFormulationProductionSystemContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            var plntid = _httpContextAccessor.HttpContext.Session.GetString("PlantId");
            if (!string.IsNullOrEmpty(plntid))
            {

                GloablPlantId = long.Parse(plntid);
            }
        }
    }
}
