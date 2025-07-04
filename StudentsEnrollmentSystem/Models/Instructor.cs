using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentsEnrollmentSystem.Models
{
    public class Instructor
    {

        public int Id { get; set; }

        [Required] 
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

       
        public int? DepartmentId { get; set; }



        [ForeignKey("DepartmentId")]
        public Department? Department { get; set; }

        
        public ICollection<Course>? Courses { get; set; } = new List<Course>();

    }


}
