using Microsoft.AspNetCore.Mvc;
using Travellers.Models;

namespace Travellers.Interface
{
    public interface ITravellerService
    {
        public Task<Traveller> Post([FromForm]Traveller traveller);
    }
}
