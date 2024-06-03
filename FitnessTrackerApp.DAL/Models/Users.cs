using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WAD_BACKEND_13851.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [StringLength(20)]
        public string Gender { get; set; }

        public float Height { get; set; }

        public float Weight { get; set; }
        public int? WorkoutId { get; set; }

        [ForeignKey("WorkoutId")]
        public Workout? Workout { get; set; }

    }
}
