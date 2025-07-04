using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using StudentsEnrollmentSystem.Models;

namespace StudentsEnrollmentSystem.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) 
        {
                
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor > Instructors { get; set; }
        public DbSet  <Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Course>()
                .HasOne(c => c.Instructor)
                .WithMany(i => i.Courses)
                .HasForeignKey(c => c.InstructorId)
                .OnDelete(DeleteBehavior.Restrict); // أو .NoAction

            modelBuilder.Entity<Course>()
                .HasOne(c => c.Department)
                .WithMany(d => d.Courses)
                .HasForeignKey(c => c.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Department>()
            .Property(d => d.Budget)
           .HasColumnType("decimal(18,2)");

        }

    }
}
