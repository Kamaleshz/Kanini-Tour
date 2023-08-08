using Tour_Package.Models;
using Tour_Package.Models.DTO;

namespace Tour_Package.Interface
{
    public interface ITravel_agentService
    {
        public Task<IEnumerable<Travel_agent>> Get();

        public Task<Travel_agent> GetById(int Travelagent_id);

        public Task<Travel_agent> Post(Travel_agent travel_agent);

        public Task<Travel_agent> Put(int Travelagent_id, Travel_agent travel_agent);

        public Task<Travel_agent> Delete(int Travelagnet_id);

        public Task<UpdateStatus> UpdateStatus(int id,UpdateStatus status);

        public Task<UpdateStatus> DeclineAgentStatus(int id,UpdateStatus status);

        public Task<ICollection<Travel_agent>> RequestedAgent();

        public Task<ICollection<Travel_agent>> AcceptedAgent();
    }
}
