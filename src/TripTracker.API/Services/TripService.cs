using Microsoft.EntityFrameworkCore;
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
            var trip = GetById(id).Result;
            _context.Trips.Remove(trip);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Trip>> Get()
        {
            var trips = await _context.Trips.ToListAsync();
            return trips;
        }

        public async Task<Trip> GetById(int id)
        {
            var trip = await _context.Trips.FindAsync(id);
            return trip;
        }

        public async Task Update(Trip trip)
        {
            _context.Trips.Update(trip);
            await _context.SaveChangesAsync();
        }

        public bool TripExists(int id)
        {
            return _context.Trips.Any(t => t.Id == id);
        }
    }
}
