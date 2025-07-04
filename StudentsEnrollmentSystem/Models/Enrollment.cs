using System.ComponentModel.DataAnnotations.Schema;

namespace StudentsEnrollmentSystem.Models
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }

        public int CourseId { get; set; }
        public int StudentId { get; set; }


        [ForeignKey("StudentId")]
        public Student Students { get; set; } = new();

        [ForeignKey("CourseId")]
        public Course Courses { get; set; } = new();

    }
}
