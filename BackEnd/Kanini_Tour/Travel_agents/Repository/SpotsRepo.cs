using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tour_Package.Context;
using Tour_Package.Interface;
using Tour_Package.Models;

namespace Tour_Package.Repository
{
    public class SpotsRepo : ISpots
    {
        private readonly AgentContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SpotsRepo(AgentContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _webHostEnvironment = environment;
        }
        public async Task<IEnumerable<Spots>> GetSpots()
        {
            return await _context.spots.ToListAsync();
        }

        public async Task<List<Spots>> GetSpotsById(int Spot_Id)
        {
            try
            {
                return await _context.spots.Where(x => x.Spot_Id == Spot_Id).Include(x => x.packages).ToListAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Spots> CreateSpot([FromForm] Spots Spot, IFormFile imageFile)
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
            Spot.Spot_Image = fileName;


            _context.spots.Add(Spot);
            await _context.SaveChangesAsync();

            return Spot;
        }
        public async Task<Spots> UpdateSpot(int Spot_Id, Spots Spot, IFormFile imageFile)
        {
            var existingSpot = await _context.spots.FindAsync(Spot_Id);
            if (existingSpot == null)
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

                var oldFilePath = Path.Combine(uploadsFolder, existingSpot.Spot_Image);
                if (File.Exists(oldFilePath))
                {
                    File.Delete(oldFilePath);
                }

                existingSpot.Spot_Image = fileName;
            }

            existingSpot.Spot_Name = Spot.Spot_Name;
            existingSpot.Spot_Description = Spot.Spot_Description;

            await _context.SaveChangesAsync();

            return existingSpot;
        }
        public async Task<Spots> DeleteSpot(int Spot_Id)
        {
            try
            {
                Spots Spot = await _context.spots.FirstOrDefaultAsync(x => x.Spot_Id == Spot_Id);
                if (Spot != null)
                {
                    _context.spots.Remove(Spot);
                    _context.SaveChanges();
                    return Spot;
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
