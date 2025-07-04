using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentsEnrollmentSystem.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }

        public int Credit { get; set; }

        public int InstructorId { get; set; }

        
        public int DepartmentId { get; set; }


        [ForeignKey("InstructorId")]
        public Instructor? Instructor { get; set; } = new();

        [ForeignKey("DepartmentId")]
        public Department? Department { get; set; } = new();

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();


    }
}
 