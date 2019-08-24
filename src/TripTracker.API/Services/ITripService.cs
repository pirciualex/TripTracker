using System.Collections.Generic;
using System.Threading.Tasks;
using TripTracker.API.Models;

namespace TripTracker.API.Services
{
    public interface ITripService
    {
        IEnumerable<Trip> Get();
        Trip GetById(int id);
        Task Add(Trip trip);
        Task Update(Trip trip);
        Task Delete(int id);
    }
}
