using Microsoft.AspNetCore.Mvc;
using Tour_Package.Interface;
using Tour_Package.Models;

namespace Tour_Package.Service
{
    public class PackageService : IPackageService
    {
        private readonly IPackage _package;
        private readonly IWebHostEnvironment _environment;

        public PackageService(IPackage package, IWebHostEnvironment environment)
        {
            _package = package;
            _environment = environment;
        }

        public async Task<IEnumerable<Package>> Get()
        {
            return await _package.GetPackage();
        }

        public async Task<List<Package>> GetById(int Package_Id)
        {
            return await _package.GetPackageById(Package_Id);
        }

        public async Task<Package>Post([FromForm]Package Package, IFormFile imageFile)
        {
            return await _package.CreatePackage(Package,imageFile);
        }

        public async Task<Package> Put(int Package_Id,Package Package, IFormFile imageFile)
        {
            return await _package.UpdatePackage(Package_Id,Package, imageFile);
        }

        public async Task<Package> Delete(int Package_Id)
        {
            return await _package.DeletePackage(Package_Id);
        }
    }
}
