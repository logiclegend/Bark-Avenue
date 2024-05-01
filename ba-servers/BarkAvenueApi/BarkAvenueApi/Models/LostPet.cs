using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarkAvenueApi.Models
{
    public class LostPet
    {
        [Column("lost_pet_id")]
        public int LostPetId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("breed")]
        public string Breed { get; set; }

        [Column("gender")]
        public string Gender { get; set; }

        [Column("location")]
        public string Location { get; set; }

        [Column("user_id")]
        public string UserId { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("photo")]
        public string Photo { get; set; }

        [Column("lost_date")]
        public DateTimeOffset LostDate { get; set; }
    }
}
