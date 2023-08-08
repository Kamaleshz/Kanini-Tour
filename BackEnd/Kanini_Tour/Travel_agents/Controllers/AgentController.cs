using Microsoft.AspNetCore.Mvc;
using Tour_Package.Interface;
using Tour_Package.Models;
using Tour_Package.Models.DTO;

namespace Travel_agents.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private readonly ITravel_agentService agent;

        public AgentController(ITravel_agentService agent)
        {
            this.agent = agent;
        }

        [HttpGet]
        public async Task<IEnumerable<Travel_agent>> Get()
        {
            return await agent.Get();
        }

        [HttpGet("Travelagent_id")]
        public Task<Travel_agent> GetById(int Travelagent_id)
        {
            return agent.GetById(Travelagent_id);
        }

        [HttpPost]
        public async Task<ActionResult<Travel_agent>> Create([FromForm]Travel_agent travelagent)
        {
            try
            {
                var CreatedAgent = await agent.Post(travelagent);
                return Created("Get", CreatedAgent);
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPut("Travelagent_id")]

        public async Task<ActionResult<Travel_agent>> Put([FromForm] int Travelagent_id, Travel_agent travelagent)
        {
            try
            {
                var updatedAgent = await agent.Put(Travelagent_id,travelagent);
                if (updatedAgent == null)
                {
                    return NotFound();
                }

                return Ok(updatedAgent);
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("Travelagent_id")]

        public Task<Travel_agent> Delete(int Travelagent_id)
        {
            return agent.Delete(Travelagent_id);
        }

        [HttpPut("AcceptStatus")]
        public async Task<ActionResult<UpdateStatus>> UpdateStatus(int Id,UpdateStatus status)
        {
            var result = await agent.UpdateStatus(Id,status);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPut("DeclineStatus")]
        public async Task<ActionResult<UpdateStatus>> UpdateDeclineStatus(int Id,UpdateStatus status)
        {
            var result = await agent.DeclineAgentStatus(Id, status);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("RequestedStatus")]
        public async Task<ActionResult<UpdateStatus>> GetRequestedAgents()
        {
            var result = await agent.RequestedAgent();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("AcceptedStatus")]
        public async Task<ActionResult<UpdateStatus>> GetAcceptedDoctors()
        {
            var result = await agent.AcceptedAgent();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
