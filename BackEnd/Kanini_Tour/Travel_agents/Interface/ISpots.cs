using Microsoft.AspNetCore.Mvc;
using Tour_Package.Models;

namespace Tour_Package.Interface
{
    public interface ISpots
    {
        public Task<IEnumerable<Spots>> GetSpots();

        public Task<List<Spots>> GetSpotsById(int Spot_Id);

        public Task<Spots> CreateSpot([FromForm] Spots spot, IFormFile imageFile);

        public Task<Spots> UpdateSpot(int Spot_Id, Spots spot, IFormFile imageFile);

        public Task<Spots> DeleteSpot(int Location_Id);
    }
}
