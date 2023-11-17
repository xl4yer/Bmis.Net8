using Bmis.Models;
using Bmis.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bmis.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClearanceController : Controller
    {
        ClearanceServices xservices;

        public ClearanceController(ClearanceServices xservices)
        {
            this.xservices = xservices;
        }

        [HttpGet]
        public async Task<List<clearance>> Clearance()
        {
            var ret = await xservices.Clearance();
            return ret;
        }

        [HttpPost]
        public async Task<int> AddClearance([FromBody] clearance xclearance)
        {
            var ret = await xservices.AddClearance(xclearance);
            return ret;
        }
    }
}
