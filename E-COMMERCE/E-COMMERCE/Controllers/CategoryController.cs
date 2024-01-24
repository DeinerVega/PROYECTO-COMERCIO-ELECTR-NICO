using E_COMMERCE.Models;
using E_COMMERCE.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_COMMERCE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private ICategoryCollection db = new CategoryCollection();

        [HttpGet]
        public async Task<IActionResult> GetAllCategorys()
        {
            return Ok(await db.GetAllCategorys());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategorysDetails(string id)
        {
            return Ok(await db.GetCategoryById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] Category category)
        {
            if (category == null)
                return BadRequest();

            if (category.Name == string.Empty)
            {
                ModelState.AddModelError("Name", "No puede estar vacio");
            }

            await db.InsertCategory(category);

            return Created("Created", true);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory([FromBody] Category category, string id)
        {
            if (category == null)
                return BadRequest();

            if (category.Name == string.Empty)
            {
                ModelState.AddModelError("Name", "No puede estar vacio");
            }

            category.Id = new MongoDB.Bson.ObjectId(id);
            await db.UpdateCategory(category);

            return Created("Created", true);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(string id)
        {

            await db.DeleteCategory(id);

            return NoContent();

        }


    }
}
