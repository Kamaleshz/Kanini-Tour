using System.Collections.Generic;
using System.Threading.Tasks;
using Tour_Package.Models;

namespace Tour_Package.Interface
{
    public interface IAgentToken
    {
        public IEnumerable<Travel_agent> GetTravelAgents();

        public Task<Travel_agent> GetTravelAgentByEmailAndPassword(string email, string password);

        string GenerateJwtToken(Travel_agent travelAgent);
    }
}
