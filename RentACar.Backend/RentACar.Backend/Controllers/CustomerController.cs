using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentACar.Backend.Models;
using RentACar.Backend.Models.Context;

namespace RentACar.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly DatabaseContext _database;

        public CustomerController(DatabaseContext database)
        {
            _database = database;
        }

        [HttpGet, Route("count")]
        public int GetCustomerCount() => _database.Customers.Count();

        [HttpGet]
        public List<Customer> GetCustomerList() => _database.Customers.ToList();

        public Customer GetById(int id) => _database.Customers.FirstOrDefault(c => c.Id == id);

        [HttpPost]
        public int CreateCustomer(Customer customer)
        {
            _database.Customers.Add(customer);
            return _database.SaveChanges();
        }

        [HttpPut]
        public int UpdateCustomer(Customer customer)
        {
            _database.Customers.Update(customer);
            return _database.SaveChanges();
        }

        [HttpDelete]
        public int DeleteCustomers(int id)
        {
            _database.Customers.Remove(GetById(id));
            return _database.SaveChanges();
        }

        [HttpGet, Route("getRentals")]
        public List<Rental> GetRentals(int customerId) => _database.Rentals.Where(c => c.CustomerId == customerId).Include(c => c.Car).ToList();
    }
}
