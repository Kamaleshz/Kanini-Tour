using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using Tour_Package.Context;
using Tour_Package.Interface;
using Tour_Package.Models;

namespace Tour_Package.Repository
{
    public class LocationRepo : ILocation
    {
        private readonly AgentContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public LocationRepo(AgentContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<List<Location>> GetLocation()
        {
            return await _context.locations.ToListAsync();
        }

        public async Task<List<Location>> GetLocationById(int Location_Id)
        {
            try
            {
                return await _context.locations.Where(x => x.Location_Id == Location_Id).ToListAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Location> CreateLocation([FromForm] Location location, IFormFile imageFile)
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
            location.Location_Image = fileName;


            _context.locations.Add(location);
            await _context.SaveChangesAsync();

            return location;
        }
        public async Task<Location> UpdateLocation(int Location_Id, Location location, IFormFile imageFile)
        {
            var existingLocation = await _context.locations.FindAsync(Location_Id);
            if (existingLocation == null)
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

                var oldFilePath = Path.Combine(uploadsFolder, existingLocation.Location_Image);
                if (File.Exists(oldFilePath))
                {
                    File.Delete(oldFilePath);
                }

                existingLocation.Location_Image = fileName;
            }

            existingLocation.Location_Name = location.Location_Name;

            await _context.SaveChangesAsync();

            return existingLocation;
        }
        public async Task<Location> DeleteLocation(int Location_Id)
        {
            try
            {
                Location location = await _context.locations.FirstOrDefaultAsync(x => x.Location_Id == Location_Id);
                if (location != null)
                {
                    _context.locations.Remove(location);
                    _context.SaveChangesAsync();
                    return location;
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
