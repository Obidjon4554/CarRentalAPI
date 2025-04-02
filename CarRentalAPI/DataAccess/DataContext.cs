using CarRentalAPI.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarRentalAPI.DataAccess
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }

    }
}
