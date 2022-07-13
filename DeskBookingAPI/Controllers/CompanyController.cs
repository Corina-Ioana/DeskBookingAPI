using DeskBookingAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            if(company == null)
            {
                return BadRequest();    
            }
            _deskBookingContext.Companies.Add(company);
            _deskBookingContext.SaveChanges();
            return new JsonResult(company);
        }
    }
}
