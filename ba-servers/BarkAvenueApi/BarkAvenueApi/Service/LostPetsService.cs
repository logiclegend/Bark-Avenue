using System.Collections.Generic;
using System.Linq;
using BarkAvenueApi.Models;

namespace BarkAvenueApi.Services
{
    public class LostPetsService
    {
        private readonly ApplicationDbContext _dbContext;

        public LostPetsService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<LostPetDto> GetLostPets()
        {
            return _dbContext.LostPets.Select(p => new LostPetDto
            {
                Name = p.Name,
                Breed = p.Breed,
                Gender = p.Gender,
                Location = p.Location,
                UserId = p.UserId,
                Description = p.Description,
                Photo = p.Photo
            }).ToList();
        }
    }
}
