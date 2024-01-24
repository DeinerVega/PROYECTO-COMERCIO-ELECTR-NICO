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
    public class StoreController : Controller
    {
        private IStoreCollection db = new StoreCollection();

        [HttpGet]
        public async Task<IActionResult> GetAllStores()
        {
            return Ok(await db.GetAllStores());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStoresDetails(string id)
        {
            return Ok(await db.GetStoreById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateStore([FromBody] Store store)
        {
            if (store == null)
                return BadRequest();

            if (store.Name == string.Empty)
            {
                ModelState.AddModelError("Name", "No puede estar vacio");
            }

            await db.InsertStore(store);

            return Created("Created", true);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStore([FromBody] Store store, string id)
        {
            if (store == null)
                return BadRequest();

            if (store.Name == string.Empty)
            {
                ModelState.AddModelError("Name", "No puede estar vacio");
            }

            store.Id = new MongoDB.Bson.ObjectId(id);
            await db.UpdateStore(store);

            return Created("Created", true);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStore(string id)
        {

            await db.DeleteStore(id);

            return NoContent();

        }


    }
}
