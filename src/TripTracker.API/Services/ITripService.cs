using System.Collections.Generic;
using System.Threading.Tasks;
using TripTracker.API.Models;

namespace TripTracker.API.Services
{
    public interface ITripService
    {
        Task<IEnumerable<Trip>> Get();
        Task<Trip> GetById(int id);
        Task Add(Trip trip);
        Task Update(Trip trip);
        Task Delete(int id);
        bool TripExists(int id);
    }
}
