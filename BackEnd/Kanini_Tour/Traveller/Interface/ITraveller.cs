using Microsoft.AspNetCore.Mvc;
using Travellers.Models;

namespace Travellers.Interface
{
    public interface ITraveller
    {
        public Task<Traveller> CreateTraveller([FromForm]Traveller traveller);
    }
}
