using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

using shop.Data;
using shop.Model;
using shop.Repository;
using shop.Services;
using System;

namespace shop.Controllers
{
    
    [ApiController]
    [Route("v1/categories")]
    public class CategoryController:ControllerBase
    {

       [HttpGet]
       [Route("")]
       public async Task<ActionResult<List<Category>>> Get([FromServices] DataContext context){

          var categories = await context.Categories.ToListAsync();
          return categories;
       }

        [HttpPost]
        [Route("")]
        [Authorize(Roles = "employee,manager")]
        public async Task<ActionResult<Category>> Post([FromServices] DataContext context, [FromBody] Category model){
          if(ModelState.IsValid){
            context.Categories.Add(model);
             await context.SaveChangesAsync();
            return model;
          }
          else{
              return BadRequest(ModelState);
          }
        }



        
    }
}