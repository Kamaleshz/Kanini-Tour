using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tour_Package.Context;
using Tour_Package.Interface;
using Tour_Package.Models;
using Tour_Package.Models.DTO;

namespace Travel_agents.Repository
{
    public class AgentRepo : ITravel_agent
    {
        private readonly AgentContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AgentRepo(AgentContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IEnumerable<Travel_agent>> GetAgents()
        {
            return await _context.travel_agents.ToListAsync();
        }

        public async Task<Travel_agent> GetAgentById(int Travelagent_id)
        {
            try
            {
                return await _context.travel_agents.FirstOrDefaultAsync(x=>x.Travelagent_Id==Travelagent_id);
            }
            catch(Exception)
            {
                return null;
            }
        }

        public async Task<Travel_agent> CreateAgent([FromForm] Travel_agent travel_agent)
        {
            travel_agent.Travelagent_Status = "Requested";

            _context.travel_agents.Add(travel_agent);
            await _context.SaveChangesAsync();

            return travel_agent;
        }

        public async Task<Travel_agent> UpdateAgent(int Travelagent_id, Travel_agent travelagent)
        {
            var existingAgent = await _context.travel_agents.FindAsync(Travelagent_id);
            if (existingAgent == null)
            {
                return null;
            }

            existingAgent.Travelagent_Name = travelagent.Travelagent_Name;
            existingAgent.Travelagency_Name= travelagent.Travelagency_Name;
            existingAgent.Travelagent_Description= travelagent.Travelagent_Description;
            existingAgent.Travelagent_Contact = travelagent.Travelagent_Contact;
            existingAgent.Travelagent_Email = travelagent.Travelagent_Email;
            existingAgent.Travelagent_Password = travelagent.Travelagent_Password;
            await _context.SaveChangesAsync();

            return existingAgent;
        }

        public async Task<Travel_agent> DeleteAgent(int Travelagent_id)
        {
            try
            {
                Travel_agent agent = await _context.travel_agents.FirstOrDefaultAsync(x => x.Travelagent_Id == Travelagent_id);
                if (agent != null)
                {
                    _context.travel_agents.Remove(agent);
                    _context.SaveChanges();
                    return agent;
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
