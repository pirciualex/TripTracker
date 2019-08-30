using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        public async Task<ActionResult<IEnumerable<Trip>>> GetTrips()
        {
            var trips = await _tripService.GetAsync();
            return Ok(trips);
        }

        // GET: api/Trip/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trip>> GetTrip(int id)
        {
            var trip = await _tripService.GetByIdAsync(id);
            if (trip == null)
            {
                return NotFound();
            }
            return Ok(trip);
        }

        // POST: api/Trip
        [HttpPost]
        public async Task<ActionResult<Trip>> PostTrip([FromBody] Trip trip)
        {
            await _tripService.AddAsync(trip);
            return CreatedAtAction("GetTrip", new { id = trip.Id }, trip);
        }

        // PUT: api/Trip/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrip(int id, [FromBody] Trip trip)
        {
            if (!_tripService.TripExists(id))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _tripService.UpdateAsync(trip);
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrip(int id)
        {
            if (!_tripService.TripExists(id))
            {
                return NotFound();
            }

            await _tripService.DeleteAsync(id);

            return NoContent();
        }
    }
}