using CarRentalSystem.Interfaces;
using CarRentalSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CarRentalSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public IEnumerable<Car> Get()
        {
            return _carService.GetAllCars();
        }

        [HttpGet("{id}")]
        public ActionResult<Car> Get(int id)
        {
            var car = _carService.GetCarById(id);
            if (car == null)
                return NotFound();

            return car;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Car car)
        {
            _carService.AddCar(car);
            return Ok();
        }

        [HttpPut]
        public ActionResult Put([FromBody] Car car)
        {
            _carService.UpdateCar(car);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _carService.DeleteCar(id);
            return Ok();
        }
    }
}
