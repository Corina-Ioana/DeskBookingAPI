﻿using DeskBookingAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace DeskBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly DeskBookingContext _deskBookingContext;

        public CompanyController(DeskBookingContext deskBookingContext)
        {
            _deskBookingContext = deskBookingContext;
        }
        [HttpPost]

        public IActionResult Create([FromBody] Company company)
        {
            if (company == null)
            {
                return BadRequest();
            }
            _deskBookingContext.Companies.Add(company);
            _deskBookingContext.SaveChanges();
            return new JsonResult(company);
        }

        [HttpGet]
        public IEnumerable GetAll()
        {

            return _deskBookingContext.Companies.ToList();

        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Company company)
        {
            if (company == null || company.ID != id)
            {
                return BadRequest();
            }

            var originalcompany = _deskBookingContext.Companies.FirstOrDefault(t => t.ID == id);
            if (company == null)
            {
                return NotFound();
            }

            originalcompany.Name = company.Name;
            originalcompany.Address = company.Address;


            _deskBookingContext.Companies.Update(originalcompany);
            _deskBookingContext.SaveChanges();
            return new NoContentResult();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var company = _deskBookingContext.Companies.FirstOrDefault(t => t.ID == id);
            if (company == null)
            {
                return NotFound();
            }

            _deskBookingContext.Companies.Remove(company);
            _deskBookingContext.SaveChanges();
            return new NoContentResult();
        }

    }
}
