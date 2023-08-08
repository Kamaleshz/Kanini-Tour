using Microsoft.EntityFrameworkCore;
using Tour_Package.Interface;
using Tour_Package.Models;
using Tour_Package.Models.DTO;

namespace Tour_Package.Service
{
    public class AgentService : ITravel_agentService
    {
        private readonly ITravel_agent _repo;
        private readonly IWebHostEnvironment _environment;

        public AgentService(ITravel_agent repo, IWebHostEnvironment environment)
        {
            _repo = repo;
            _environment = environment;
        }

        public async Task<IEnumerable<Travel_agent>> Get()
        {
            return await _repo.GetAgents();
        }

        public async Task<Travel_agent> GetById(int Agent_Id)
        {
            return await _repo.GetAgentById(Agent_Id);
        }

        public async Task<Travel_agent>Post(Travel_agent agent)
        {
            return await _repo.CreateAgent(agent);
        }

        public async Task<Travel_agent>Put(int Agent_Id, Travel_agent agent)
        {
            return await _repo.UpdateAgent(Agent_Id, agent);
        }

        public async Task<Travel_agent>Delete(int Agent_Id)
        {
            return await _repo.DeleteAgent(Agent_Id);
        }

        public async Task<UpdateStatus> UpdateStatus(int id,UpdateStatus status)
        {
            Travel_agent agent = await _repo.GetAgentById(id);
            if (agent != null)
            {
                agent.Travelagent_Status = "Accepted";
                await _repo.UpdateAgent(id, agent);

                UpdateStatus statusDto = new UpdateStatus
                {
                    status = "Accepted"
                };

                return statusDto;
            }
            else
            {
                return null;
            }  
        }
        public async Task<UpdateStatus> DeclineAgentStatus(int id,UpdateStatus status)
        {
            Travel_agent agent = await _repo.GetAgentById(id);
            if (agent != null)
            {
                agent.Travelagent_Status = status.status = "Declined";
                await _repo.UpdateAgent(id, agent);
                return status;
            }
            else
            {
                return null;
            }
            
        }
        public async Task<ICollection<Travel_agent>> RequestedAgent()
        {
            var agent = await _repo.GetAgents();
            var ag = agent.Where(s => s.Travelagent_Status == "Requested").ToList();
            if (ag != null)
            {
                return ag;
            }
            return null;
        }

        public async Task<ICollection<Travel_agent>> AcceptedAgent()
        {
            var agent = await _repo.GetAgents();
            var ag = agent.Where(s => s.Travelagent_Status == "Accepted").ToList();
            if (ag != null)
            {
                return ag;
            }
            return null;
        }

    }
}
