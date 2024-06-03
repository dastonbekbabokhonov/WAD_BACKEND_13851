using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WAD_BACKEND_13851.Models
{
    public class Workout
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string ActivityType { get; set; }

        [Required]
        public int Duration { get; set; }

        public float? Distance { get; set; }

        public int CaloriesBurned { get; set; }
    }
}

