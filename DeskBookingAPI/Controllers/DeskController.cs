using DeskBookingAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace DeskBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeskController : ControllerBase
    {
        private readonly DeskBookingContext _deskBookingContext;
        public DeskController(DeskBookingContext deskBookingContext)
        {
            _deskBookingContext = deskBookingContext;
        }
        [HttpPost]

        public IActionResult Create([FromBody] Desk desk)
        {
            if (desk == null)
            {
                return BadRequest();
            }
            _deskBookingContext.Desks.Add(desk);
            _deskBookingContext.SaveChanges();
            return new JsonResult(desk);
        }

        [HttpGet]
        public IEnumerable GetAll()
        {

            return _deskBookingContext.Companies.ToList();

        }
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Desk desk)
        {
            if (desk == null || desk.Id!= id)
            {
                return BadRequest();
            }

            var originaldesk = _deskBookingContext.Desks.FirstOrDefault(t => t.Id == id);
            if (desk == null)
            {
                return NotFound();
            }

            
            originaldesk.Number = desk.Number;


            _deskBookingContext.Desks.Update(originaldesk);
            _deskBookingContext.SaveChanges();
            return new NoContentResult();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var desk= _deskBookingContext.Desks.FirstOrDefault(t => t.Id == id);
            if (desk == null)
            {
                return NotFound();
            }

            _deskBookingContext.Desks.Remove(desk);
            _deskBookingContext.SaveChanges();
            return new NoContentResult();
        }
    }
}
