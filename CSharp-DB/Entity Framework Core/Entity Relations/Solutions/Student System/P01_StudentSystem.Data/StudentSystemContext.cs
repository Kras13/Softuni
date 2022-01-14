using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;
using System.Diagnostics.CodeAnalysis;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {
        }

        public StudentSystemContext([NotNull] DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Homework> HomeworkSubmissions { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer("Server = DESKTOP-6SUDEUL\\SQLEXPRESS;Database = StudentSystem1;Trusted_Connection = True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StudentCourse>()
                .HasKey(c => new
                {
                    c.CourseId,
                    c.StudentId
                });
        }
    }
}
