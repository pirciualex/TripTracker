using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripTracker.API.Models;

namespace TripTracker.API.Services
{
    public class TripRepository : ITripService
    {
        private List<Trip> _trips = new List<Trip>()
        {
            new Trip
            {
                Id = 1,
                Name = "Arad Trip",
                StartDateTime = new DateTime(2019, 06, 20),
                EndDateTime = new DateTime(2019, 06, 23)
            },
            new Trip
            {
                Id = 2,
                Name = "Nadas Camp",
                StartDateTime = new DateTime(2019, 08, 13),
                EndDateTime = new DateTime(2019, 08, 18)
            },
            new Trip
            {
                Id = 3,
                Name = "BACStud2019",
                StartDateTime = new DateTime(2019, 10, 17),
                EndDateTime = new DateTime(2019, 10, 19)
            }
        };

        public Task Add(Trip trip)
        {
            _trips.Add(trip);
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var tripToRemove = _trips.First(t => t.Id == id);
            _trips.Remove(tripToRemove);
            return Task.CompletedTask;
        }

        public IEnumerable<Trip> Get()
        {
            return _trips;
        }

        public Trip GetById(int id)
        {
            var trip = _trips.First(t => t.Id == id);
            return trip;
        }

        public Task Update(Trip trip)
        {
            var tripToUpdate = _trips.First(t => t.Id == trip.Id);
            tripToUpdate.Name = trip.Name;
            tripToUpdate.StartDateTime = trip.StartDateTime;
            tripToUpdate.EndDateTime = trip.EndDateTime;
            return Task.CompletedTask;
        }
    }
}
