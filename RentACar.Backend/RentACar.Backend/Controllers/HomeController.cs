using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Backend.Models.Context;

namespace RentACar.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly DatabaseContext _database;

        public HomeController(DatabaseContext database)
        {
            _database = database;
        }

        [HttpGet, Route("getRentedCarCount")]
        public int GetRentedCarCount() => _database.Cars.Count(c => c.RentalStatus);

        [HttpGet, Route("getCustomerCount")]
        public int GetCustomerCount() => _database.Customers.Count();

    }
}
