using Tour_Package.Models;
using UpdateStatus = Tour_Package.Models.DTO.UpdateStatus;

namespace Tour_Package.Interface
{
    public interface ITravel_agent
    {
        public Task<IEnumerable<Travel_agent>> GetAgents();

        public Task<Travel_agent> GetAgentById(int Travelagent_id);

        public Task<Travel_agent> CreateAgent(Travel_agent travel_agent);

        public Task<Travel_agent> UpdateAgent(int Travelagent_id, Travel_agent travel_agent);

        public Task<Travel_agent> DeleteAgent(int Travelagnet_id);


    }
}
