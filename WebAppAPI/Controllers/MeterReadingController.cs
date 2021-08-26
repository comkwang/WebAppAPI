using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAPI.EF;
using WebAppAPI.Models;

namespace WebAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
    public class MeterReadingController : ControllerBase
    {
        private EnergyAccountDBContext _db;
        public MeterReadingController(EnergyAccountDBContext db)
        {
            _db = db;
        }

        [Route("GetAll_Meter")]
        [HttpGet]
        public IActionResult GetAll()
        {
           
            var makes = _db.MeterReadings.ToList();
            return Ok(makes);
        }

        [Route("GetMeter/{id}")]
        [HttpGet]
        public IActionResult GetMeter(string id)
        {
           
            var makes = _db.MeterReadings.Where(s => s.AccountId == id).ToList();
            return Ok(makes);
        }

        [Route("GetAll_Test")]
        [HttpGet]
        public IActionResult GetAll_Test()
        {
          
            var make = _db.TestAccounts.ToList();
            if (make is null)
                return BadRequest("No Found data");
            return Ok(make);
        }

        [Route("GetTest/{id}")]
        [HttpGet]
        public IActionResult GetTest(int id)
        {
          
            var make = _db.TestAccounts.Where(s=>s.AccountId == id).ToList();
            if (make is null)
                return BadRequest("No Found data");
            return Ok(make);
        }


        [Route("Create")]
        [HttpPost]
        public IActionResult Create(TestAccountModel model)
        {
            if (string.IsNullOrEmpty(model.FirstName))
                return BadRequest("no first name.");

            TestAccount make = new TestAccount();
            make.FirstName = model.FirstName;
            make.LastName = model.LastName;
            make.AccountId = 1111;
            _db.TestAccounts.Add(make);
            _db.SaveChanges();
            return Ok(make);
        }

        [Route("Update")]
        [HttpPut]
        public IActionResult Update(TestAccountModel model)
        {
            if (string.IsNullOrEmpty(model.FirstName))
                return BadRequest("no first name.");
            
            TestAccount make = new TestAccount();
            make.FirstName = model.FirstName;
            make.LastName = model.LastName;
            make.AccountId = 1111;
            _db.TestAccounts.Attach(make);
            _db.SaveChanges();
            return Ok(make);
        }



        [Route("Delete/{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {

       
       
            var make = _db.TestAccounts.Where(s => s.AccountId == id).ToList();
            if (make is null)
                return BadRequest("NO Data was found");

            //TestAccount make = new TestAccount();
            //_db.TestAccounts.Remove(make);
            //_db.SaveChanges();
            return Ok(make);
        }
       
    }
}
