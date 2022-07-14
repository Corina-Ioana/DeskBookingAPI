using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DeskBookingAPI.Data;
using System.Collections;


namespace DeskBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyRoomsController : ControllerBase
    {
        private readonly DeskBookingContext _deskBookingContext;
        public CompanyRoomsController(DeskBookingContext deskBookingContext)
        {
            _deskBookingContext = deskBookingContext;
        }
        [HttpPost]

        public IActionResult Create([FromBody] CompanyRooms companyRoom)
        {
            if (companyRoom == null)
            {
                return BadRequest();
            }
            _deskBookingContext.CompanyRooms.Add(companyRoom);
            _deskBookingContext.SaveChanges();
            return new JsonResult(companyRoom);
        }
        [HttpGet]
        public IEnumerable GetAll()
        {

            return _deskBookingContext.CompanyRooms.ToList();

        }
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] CompanyRooms companyRoom)
        {
            if (companyRoom == null || companyRoom.ID != id)
            {
                return BadRequest();
            }

            var originalcompanyRoom = _deskBookingContext.CompanyRooms.FirstOrDefault(t => t.ID == id);
            if (companyRoom == null)
            {
                return NotFound();
            }


            originalcompanyRoom.Name = companyRoom.Name;
            originalcompanyRoom.Floor = companyRoom.Floor;
            originalcompanyRoom.Number= companyRoom.Number;

            _deskBookingContext.CompanyRooms.Update(originalcompanyRoom);
            _deskBookingContext.SaveChanges();
            return new NoContentResult();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var companyRoom = _deskBookingContext.CompanyRooms.FirstOrDefault(t => t.ID == id);
            if (companyRoom == null)
            {
             return NotFound();
            }
            _deskBookingContext.CompanyRooms.Remove(companyRoom);
            _deskBookingContext.SaveChanges();
            return new NoContentResult();
        }
    }
}
