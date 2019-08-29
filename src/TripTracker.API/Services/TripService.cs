using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripTracker.API.Data;
using TripTracker.API.Models;

namespace TripTracker.API.Services
{
    public class TripService : ITripService
    {
        private readonly TripContext _context;

        public TripService(TripContext context)
        {
            _context = context;
        }

        public async Task Add(Trip trip)
        {
            _context.Trips.Add(trip);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var trip = GetById(id);
            _context.Trips.Remove(trip);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Trip> Get()
        {
            return _context.Trips.ToList();
        }

        public Trip GetById(int id)
        {
            return _context.Trips.Find(id);
        }

        public async Task Update(Trip trip)
        {
            _context.Trips.Update(trip);
            await _context.SaveChangesAsync();
        }
    }
}
