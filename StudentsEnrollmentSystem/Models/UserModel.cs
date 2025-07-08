using System.ComponentModel.DataAnnotations;

namespace StudentsEnrollmentSystem.Models
{
    public class UserModel
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string? Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string? Password { get; set; }

        // Add more props if needed later like Email, Role, etc
    }
}
