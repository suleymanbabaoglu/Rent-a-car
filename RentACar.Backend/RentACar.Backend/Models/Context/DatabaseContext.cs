using Microsoft.EntityFrameworkCore;

namespace RentACar.Backend.Models.Context
{
    public class DatabaseContext : DbContext
    {
        private readonly IConfiguration configuration;

        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        public DatabaseContext(IConfiguration configuration) : base()
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();

            optionsBuilder.UseMySql(configuration.GetSection("DbSettings:SqlConnection").Value, new MySqlServerVersion(new Version(10, 1, 33)));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            RelationSettings(modelBuilder);
        }

        private void RelationSettings(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rental>()
              .HasKey(s => new { s.CarId, s.CustomerId });
            modelBuilder.Entity<Rental>()
                .HasOne(s => s.Car)
                .WithMany(s => s.RentalList)
                .HasForeignKey(s => s.CarId);
            modelBuilder.Entity<Rental>()
                .HasOne(s => s.Customer)
                .WithMany(s => s.RentalList)
                .HasForeignKey(s => s.CustomerId);
        }
    }
}
