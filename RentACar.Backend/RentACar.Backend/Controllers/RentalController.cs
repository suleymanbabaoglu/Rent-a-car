using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Backend.Models.Context;
using RentACar.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace RentACar.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        private readonly DatabaseContext _database;

        public RentalController(DatabaseContext database)
        {
            _database = database;
        }

        [HttpGet]
        public List<Rental> GetList() => _database.Rentals.Include(r => r.Car).Include(r => r.Customer).ToList();


        [HttpPost]
        public int RentCar(Rental rental)
        {
             _database.Rentals.Add(rental);
            var car = _database.Cars.FirstOrDefault(c => c.Id == rental.CarId);
            car.RentalStatus=true;
            return _database.SaveChanges();
        }
    }
}
