using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace RentACar.Backend.Models
{
    public class Rental
    {
        [Key]
        public int Id { get; set; }

        public Car? Car { get; set; }
        [ForeignKey("Car")]
        public int CarId { get; set; }

        public Customer? Customer { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        public int Mileage { get; set; }

        public int Duration { get; set; }

        public DateTime RentalDate { get; set; }

    }
}
