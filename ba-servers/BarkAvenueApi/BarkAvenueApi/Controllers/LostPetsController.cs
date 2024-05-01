using BarkAvenueApi.Models;
using BarkAvenueApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BarkAvenueApi.Controllers
{
    [ApiController]
    [Route("api/lostpets")]
    public class LostPetsController : ControllerBase
    {
        private readonly LostPetsService _lostPetsService;

        public LostPetsController(LostPetsService lostPetsService)
        {
            _lostPetsService = lostPetsService;
        }

        [HttpGet]
        public IEnumerable<LostPetDto> GetLostPets()
        {
            return _lostPetsService.GetLostPets();
        }

        [HttpPost]
        public IActionResult AddLostPet([FromBody] LostPetDto lostPet)
        {
            return Ok();
        }
    }
}
