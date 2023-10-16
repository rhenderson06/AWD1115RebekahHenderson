using Microsoft.EntityFrameworkCore;
using TripLog8_1.Controllers;

namespace TripLog8_1.Models
{
    public class TripLogContext : DbContext
    {
        //constructor
        public TripLogContext(DbContextOptions<TripLogContext> options) : base(options) { }

        public DbSet<Trip> Trips { get; set; }

        public static implicit operator TripLogContext(TripController v)
        {
            throw new NotImplementedException();
        }
    }
}
