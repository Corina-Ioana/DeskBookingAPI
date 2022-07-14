using DeskBookingAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace DeskBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly DeskBookingContext _deskBookingContext;
        public EmployeeController(DeskBookingContext deskBookingContext)
        {
            _deskBookingContext = deskBookingContext;
        }
        [HttpPost]

        public IActionResult Create([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }
            _deskBookingContext.Employees.Add(employee);
            _deskBookingContext.SaveChanges();
            return new JsonResult(employee);
        }
        [HttpGet]
        public IEnumerable GetAll()
        {

            return _deskBookingContext.Employees.ToList();

        }
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Employee employee)
        {
            if (employee== null || employee.Id != id)
            {
                return BadRequest();
            }

            var originalemployee = _deskBookingContext.Employees.FirstOrDefault(t => t.Id == id);
            if (employee == null)
            {
                return NotFound();
            }


            originalemployee.Name = employee.Name;
            originalemployee.Email = employee.Email;
            originalemployee.Role = employee.Role;




            _deskBookingContext.Employees.Update(originalemployee);
            _deskBookingContext.SaveChanges();
            return new NoContentResult();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var employee = _deskBookingContext.Employees.FirstOrDefault(t => t.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            _deskBookingContext.Employees.Remove(employee);
            _deskBookingContext.SaveChanges();
            return new NoContentResult();
        }
    }
}
