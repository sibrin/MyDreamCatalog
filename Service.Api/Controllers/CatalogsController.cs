using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Service.Api.Controllers
{
    [Route("[controller]")]
    public class CatalogsController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return this.Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return this.Ok();
        }
    }
}