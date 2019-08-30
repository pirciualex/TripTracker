using System.Collections.Generic;
using System.Threading.Tasks;
using TripTracker.API.Models;

namespace TripTracker.API.Services
{
    public interface ITripService
    {
        Task<IEnumerable<Trip>> GetAsync();
        Task<Trip> GetByIdAsync(int id);
        Task AddAsync(Trip trip);
        Task UpdateAsync(Trip trip);
        Task DeleteAsync(int id);
        bool TripExists(int id);
    }
}
