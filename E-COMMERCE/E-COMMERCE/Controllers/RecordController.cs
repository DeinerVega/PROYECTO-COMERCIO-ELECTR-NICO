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
    public class RecordController : Controller
    {
        private IRecordCollection db = new RecordCollection();

        [HttpGet]
        public async Task<IActionResult> GetAllRecords()
        {
            return Ok(await db.GetAllRecords());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecordsDetails(string id)
        {
            return Ok(await db.GetRecordById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateRecord([FromBody] Record record)
        {
            if (record == null)
                return BadRequest();

            if (record.BusinessName == string.Empty)
            {
                ModelState.AddModelError("Name", "No puede estar vacio");
            }

            await db.InsertRecord(record);

            return Created("Created", true);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRecord([FromBody] Record record, string id)
        {
            if (record == null)
                return BadRequest();

            if (record.BusinessName == string.Empty)
            {
                ModelState.AddModelError("BusinessName", "No puede estar vacio");
            }

            record.Id = new MongoDB.Bson.ObjectId(id);
            await db.UpdateRecord(record);

            return Created("Created", true);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecord(string id)
        {

            await db.DeleteRecord(id);

            return NoContent();

        }


    }
}
