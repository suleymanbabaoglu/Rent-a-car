using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RentACar.Backend.Models
{
    [Table("cars")]
    public class Car
    {
        [Key]
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Segment { get; set; }
        public string Fuel { get; set; }
        public int DoorCount { get; set; }
        public int Mileage { get; set; }
        public bool RentalStatus { get; set; }
        public int MinAgeRule { get; set; }

        [JsonIgnore]
        public List<Rental>? RentalList = new();
    }
}
