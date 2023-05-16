using Geopharm_testttt.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Geopharm_testttt.Models;
using Microsoft.IdentityModel.Tokens;
using Geopharm_testttt.Services;

namespace Geopharm_testttt.Controllers
{
    [Route("api/titles")] 
    [ApiController]
    public class BoxController : ControllerBase
    {
        private readonly BoxService service = new BoxService();

        [HttpGet("{from}/{to}")]
        public IActionResult GetTitles(int from, int to)
        {
            var rows = service.GetRows(from, to);
            return Ok(rows);
        }
    }
}
