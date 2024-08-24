using HotelReservation.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace HotelReservation.Infrastructure
{
    public class HotelReservationDbContextFactory : IDesignTimeDbContextFactory<HotelReservationDbContext>
    {
        public HotelReservationDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var optionsBuilder = new DbContextOptionsBuilder<HotelReservationDbContext>();
            var connectionString = configuration.GetConnectionString("HotelReservationConnection");

            optionsBuilder.UseSqlServer(connectionString);

            return new HotelReservationDbContext(optionsBuilder.Options);
        }
    }
}
