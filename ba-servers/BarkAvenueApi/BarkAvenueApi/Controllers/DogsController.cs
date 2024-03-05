using BarkAvenueApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarkAvenueApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogsController : ControllerBase
    {
        [HttpGet(Name = "GetDogs")]
        public List<DogModel> Get()
        {
            var dogs = new List<DogModel>
            {
                new DogModel
                {
                    Breed = "Labrador",
                    Color = "Beige",
                    Name = "Sharik"
                },
                new DogModel
                {
                    Breed = "Doberman",
                    Color = "Black",
                    Name = "Tuzik"
                },
                new DogModel
                {
                    Breed = "Chihuahua",
                    Color = "White",
                    Name = "Larysa"
                }
            };

            return dogs;
        }
    }
}
