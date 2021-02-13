using Microsoft.EntityFrameworkCore;
using RideShare.Entity;

namespace RideShare.DataAccess
{
    public class DatabaseContext : DbContext
    {
        public DbSet<RideDataModel> Ride { get; set; }
        public DbSet<ReservationDataModel> Reservations { get; set; }
        //public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        //{
        //    Database.EnsureCreated();
        //}



   
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
    }
}