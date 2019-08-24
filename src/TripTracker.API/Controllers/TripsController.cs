using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TripTracker.API.Models;
using TripTracker.API.Services;

namespace TripTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly ITripService _tripService;

        public TripsController(ITripService tripService)
        {
            _tripService = tripService;
        }

        // GET: api/Trip
        [HttpGet]
        public IEnumerable<Trip> Get()
        {
            return _tripService.Get();
        }

        // GET: api/Trip/5
        [HttpGet("{id}", Name = "Get")]
        public Trip Get(int id)
        {
            return _tripService.GetById(id);
        }

        // POST: api/Trip
        [HttpPost]
        public void Post([FromBody] Trip trip)
        {
            _tripService.Add(trip);
        }

        // PUT: api/Trip/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Trip trip)
        {
            _tripService.Update(trip);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _tripService.Delete(id);
        }
    }
}
