using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shop.Data;
using shop.Model;

namespace shop.Controllers
{
    [ApiController]
    [Route("v1/products")]
    public class ProductController:ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Product>>> Get ([FromServices] DataContext context){
            var products = await context.Products.Include(x => x.category).ToListAsync();
            return products;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Product>> GetById ([FromServices] DataContext context, int id){
            var products = await context.Products.Include(x => x.category).FirstOrDefaultAsync( v =>v.Id == id);
            return products;
        }


       
        [HttpGet]
        [Route("categories/{id:int}")]
        public async Task<ActionResult<List<Product>>> GetByCategory ([FromServices] DataContext context, int id){
            var products = await context.Products
            .Include(x => x.category)
            .AsNoTracking()
            .Where(x => x.CategoryId == id)
            .ToListAsync();
            return products;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Product>> Post([FromServices] DataContext context, [FromBody] Product model){

            if(ModelState.IsValid){
                context.Products.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else{
                return BadRequest(model);
            }
        }

    }
}