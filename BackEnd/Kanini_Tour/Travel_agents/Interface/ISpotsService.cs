using Microsoft.AspNetCore.Mvc;
using Tour_Package.Models;

namespace Tour_Package.Interface
{
    public interface ISpotsService
    {
        public Task<IEnumerable<Spots>> Get();

        public Task<List<Spots>> GetById(int Spot_Id);

        public Task<Spots> Post([FromForm] Spots spot, IFormFile imageFile);

        public Task<Spots> Put(int Spot_Id, Spots spot, IFormFile imageFile);

        public Task<Spots> Delete(int Location_Id);

    }
}
