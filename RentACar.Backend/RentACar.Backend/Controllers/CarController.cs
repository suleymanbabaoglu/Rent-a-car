using Microsoft.AspNetCore.Mvc;
using RentACar.Backend.Models;
using RentACar.Backend.Models.Context;

namespace RentACar.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly DatabaseContext _database;

        public CarController(DatabaseContext database)
        {
            _database = database;
        }

        [HttpGet]
        public List<Car> GetCarList() => _database.Cars.ToList();

        [HttpGet, Route("count")]
        public int GetCount() => _database.Cars.Count();

        [HttpGet, Route("not-rented")]
        public List<Car> GetNotRentedCarList() => _database.Cars.Where(c => c.RentalStatus == false).ToList();

        [HttpGet, Route("rented")]
        public int GetRentedCount() => _database.Cars.Count(c => c.RentalStatus == true);

        [HttpGet, Route("{id}")]
        public Car GetById(int id) => _database.Cars.FirstOrDefault(c => c.Id == id);

        [HttpPost]
        public int CreateCar(Car car)
        {
            _database.Cars.Add(car);
            return _database.SaveChanges();
        }

        [HttpPut]
        public int UpdateCar(Car car)
        {
            _database.Cars.Update(car);
            return _database.SaveChanges();
        }

        [HttpDelete]
        public int DeleteCar(int id)
        {
            _database.Cars.Remove(GetById(id));
            return _database.SaveChanges();
        }
    }
}
