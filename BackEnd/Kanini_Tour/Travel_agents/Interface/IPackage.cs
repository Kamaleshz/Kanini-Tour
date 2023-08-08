using Microsoft.AspNetCore.Mvc;
using Tour_Package.Models;

namespace Tour_Package.Interface
{
    public interface IPackage
    {
        public Task<IEnumerable<Package>> GetPackage();

        public Task<List<Package>> GetPackageById(int Package_Id);

        public Task<Package> CreatePackage([FromForm] Package Package, IFormFile imageFile);

        public Task<Package> UpdatePackage(int Package_Id, Package Package, IFormFile imageFile);

        public Task<Package> DeletePackage(int Package_Id);
    }
}
