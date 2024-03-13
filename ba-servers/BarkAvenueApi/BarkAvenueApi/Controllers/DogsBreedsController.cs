using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BarkAvenueApi.Controllers
{
    [ApiController]
    [Route("api/dogsbreeds")]
    public class DogsBreeds : ControllerBase
    {
        private static List<string> DogBreeds = new List<string>
        {
            "Labrador",
            "German Shepherd",
            "Golden Retriever",
            "Bulldog",
            "Poodle",
            "Beagle",
            "Boxer",
            "Dachshund",
            "Shih Tzu",
            "Siberian Husky",
            "Doberman",
            "Rottweiler",
            "Great Dane",
            "Pug",
            "Australian Shepherd",
            "Chihuahua",
            "Cocker Spaniel",
            "Dalmatian",
            "Basset Hound",
            "Shetland Sheepdog"
        };

        [HttpGet(Name = "GetDogBreeds")]
        public IEnumerable<string> GetDogBreeds()
        {
            return DogBreeds;
        }

        [HttpPost(Name = "AddDogBreed")]
        public IActionResult AddDogBreed([FromBody] string newDogBreed)
        {
            if (string.IsNullOrWhiteSpace(newDogBreed))
            {
                return BadRequest("Dog breed cannot be empty");
            }

            if (!Regex.IsMatch(newDogBreed, @"^[a-zA-Z\s]+$"))
            {
                return BadRequest("Invalid characters in dog breed");
            }

            if (DogBreeds.Contains(newDogBreed))
            {
                return Conflict($"Dog breed '{newDogBreed}' already exists");
            }

            DogBreeds.Add(newDogBreed);

            return Ok($"Dog breed '{newDogBreed}' added successfully");
        }
    }
}

//але останній раз все процювало добре, чи може бути така що це сталось через додавання гітігнор?