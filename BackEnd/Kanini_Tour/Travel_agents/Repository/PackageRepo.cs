using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tour_Package.Context;
using Tour_Package.Interface;
using Tour_Package.Models;

namespace Tour_Package.Repository
{
    public class PackageRepo : IPackage
    {
        private readonly AgentContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PackageRepo(AgentContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IEnumerable<Package>> GetPackage()
        {
            return await _context.packages.ToListAsync();
        }

        public async Task<List<Package>> GetPackageById(int Package_Id)
        {
            try
            {
                return await _context.packages.Where(x => x.Package_Id == Package_Id).Include(x => x.Locations).Include(x => x.Travel_agents).Include(x => x.spots).ToListAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Package> CreatePackage([FromForm] Package package, IFormFile imageFile)
        {
            if (imageFile == null || imageFile.Length == 0)
            {
                throw new ArgumentException("Invalid file");
            }

            var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }
            package.Package_Image = fileName;


            _context.packages.Add(package);
            await _context.SaveChangesAsync();

            return package;

        }
        public async Task<Package> UpdatePackage(int Package_Id, Package package, IFormFile imageFile)
        {
            var existingPackage = await _context.packages.FindAsync(Package_Id);
            if (existingPackage == null)
            {
                return null;
            }

            if (imageFile != null && imageFile.Length > 0)
            {
                var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                var oldFilePath = Path.Combine(uploadsFolder, existingPackage.Package_Image);
                if (File.Exists(oldFilePath))
                {
                    File.Delete(oldFilePath);
                }

                existingPackage.Package_Image = fileName;
            }

            existingPackage.Package_Name = package.Package_Name;
            existingPackage.Package_Type = package.Package_Type;
            existingPackage.Package_Rate = package.Package_Rate;
            existingPackage.Duration = package.Duration;
            existingPackage.Package_Itenary = package.Package_Itenary;
            existingPackage.Package_Food = package.Package_Food;
            existingPackage.Package_Hotel = package.Package_Hotel;

            await _context.SaveChangesAsync();

            return existingPackage;
        }
        public async Task<Package> DeletePackage(int Package_Id)
        {
            try
            {
                Package package = await _context.packages.FirstOrDefaultAsync(x => x.Package_Id == Package_Id);
                if (package != null)
                {
                    _context.packages.Remove(package);
                    await _context.SaveChangesAsync();
                    return package;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

