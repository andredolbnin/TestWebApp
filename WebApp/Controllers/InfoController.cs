using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLib;
using MongoDB.Bson;
using WebApp.Model;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InfoController : ControllerBase
    {
        private RecordsRepo _recordsRepo;

        public InfoController(RecordsRepo recordsRepo)
        {
            _recordsRepo = recordsRepo;
        }

        [HttpGet("Records")]
        public async Task<JsonResult> Records()
        {
            var l = await _recordsRepo.List();

            return new JsonResult(l);
        }

        [HttpPost("AddRecord")]
        public async Task AddRecord([FromBody] AddRecordRequest request)
        {
            await _recordsRepo.AddRecord(new Record()
            {
                Word = request.Word,
                Translation = request.Translation,
                User = "default",
                CreateDateTime = DateTime.Now
            });
        }

        [HttpPost("DeleteRecords")]
        public async Task DeleteRecords([FromBody] string[] ids)
        {
            await _recordsRepo.DeleteRecords(ids);
        }
    }
}

