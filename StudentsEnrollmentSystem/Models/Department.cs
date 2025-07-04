namespace StudentsEnrollmentSystem.Models
{
    public class Department
    {
       public int Id { get; set; }
        public string? Name { get; set; }
        public Decimal? Budget { get; set; }

        public ICollection<Student> Students { get; set; } = new List<Student>();
        public ICollection<Instructor> Instructors { get; set; }
        = new List<Instructor>();

        public  ICollection<Course> Courses { get; set; }=
        new List<Course>();

    }
}
