using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScrappingController : ControllerBase
    {
        public readonly AppDbContext appDbContext;
        public ScrappingController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> csvParing(AppDbContext appDbContext)
        {
            var yes = ScrappingCSV.CsvHelper(appDbContext);

            return Ok(yes);
        }



    }
}
