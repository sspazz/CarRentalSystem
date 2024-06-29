using CarRentalSystem.Interfaces;
using CarRentalSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CarRentalSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RentalsController : ControllerBase
    {
        private readonly IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet]
        public IEnumerable<Rental> Get()
        {
            return _rentalService.GetAllRentals();
        }

        [HttpGet("{id}")]
        public ActionResult<Rental> Get(int id)
        {
            var rental = _rentalService.GetRentalById(id);
            if (rental == null)
                return NotFound();

            return rental;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Rental rental)
        {
            _rentalService.RentCar(rental);
            return Ok();
        }

        [HttpPost("{id}/return")]
        public ActionResult Return(int id, [FromQuery] int extraDays)
        {
            _rentalService.ReturnCar(id, extraDays);
            return Ok();
        }
    }
}
