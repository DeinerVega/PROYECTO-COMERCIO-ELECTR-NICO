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
    public class UserController : Controller
    {
        private IUserCollection db = new UserCollection();

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await db.GetAllUsers());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsersDetails(string id)
        {
            return Ok(await db.GetUserById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            if (user == null)
                return BadRequest();

            if (user.Name == string.Empty)
            {
                ModelState.AddModelError("Name", "No puede estar vacio");
            }

            await db.InsertUser(user);

            return Created("Created", true);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser([FromBody] User user, string id)
        {
            if (user == null)
                return BadRequest();

            if (user.Name == string.Empty)
            {
                ModelState.AddModelError("Name", "No puede estar vacio");
            }

            user.Id = new MongoDB.Bson.ObjectId(id);
            await db.UpdateUser(user);

            return Created("Created", true);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {

            await db.DeleteUser(id);

            return NoContent();

        }


    }
}
