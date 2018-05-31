using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service.Api.Models;

namespace Service.Api.Controllers
{
    [Route("catalogs/{catalog}/products")]
    public class ProductsController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get(int catalog, int page = 1)
        {
            return this.Ok(new {catalog, page});
        }

        [HttpPost]
        public async Task<IActionResult> Post(int catalog, [FromBody] ProductCreatingModel product)
        {
            return this.Ok(new {catalog, product});
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int catalog, int id, [FromBody] ProductCreatingModel product)
        {
            return this.Ok(new {catalog, id, product});
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int catalog, int id)
        {
            return this.Ok(new {catalog, id});
        }
    }
}