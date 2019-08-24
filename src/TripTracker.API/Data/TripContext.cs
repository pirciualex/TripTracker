using Microsoft.EntityFrameworkCore;
using TripTracker.API.Models;

namespace TripTracker.API.Data
{
    public class TripContext : DbContext
    {
        public TripContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Trip> Trips { get; set; }
    }
}
