using Travellers.Models;

namespace Travellers.Interface
{
    public interface ITravellerToken
    {
        IEnumerable<Traveller> GetTravellers();
        Task<Traveller> GetTravellerByEmailAndPassword(string email, string password);
        public string GenerateJwtToken(Traveller traveller);
    }
}
