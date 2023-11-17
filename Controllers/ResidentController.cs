using Bmis.Models;
using Bmis.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bmis.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ResidentController : Controller
    {
        ResidentServices xservices;

        public ResidentController(ResidentServices xservices)
        {
            this.xservices = xservices;
        }

        [HttpGet]
        public async Task<List<residents>> Residents()
        {
            var ret = await xservices.Residents();
            return ret;
        }

        [HttpPost]
        public async Task<int> AddResident([FromBody] residents xres)
        {
            var ret = await xservices.AddResident(xres);
            return ret;
        }

        [HttpPut]
        public async Task<int> UpdateResident([FromBody] residents xres)
        {
            var ret = await xservices.UpdateResident(xres);
            return ret;
        }

        [HttpGet]
        public async Task<List<residents>> SearchResident(string search)
        {
            var ret = await xservices.SearchResident(search);
            return ret;
        }


    }
}

