using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStudentManagementSystem.Models
{
    public class StudentDBContext:DbContext
    {
       public StudentDBContext(DbContextOptions<StudentDBContext>options):base(options)
        { }
           



        public DbSet<AddressCode> AddressCodes { get; set; }
            public DbSet<Subject> Subjects { get; set; }
            public DbSet<Course> Courses { get; set; }
            public DbSet<Admin> Admins { get; set; }
            public DbSet<Student> Students { get; set; }
            public DbSet<SubjectReportCard> SubjectReportCards { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AddressCode>()
                .HasIndex(c=>c.ZipCode)
                .IsUnique();
            modelBuilder.Entity<Course>()
                .HasIndex(c => c.CourseName)
                .IsUnique();
            modelBuilder.Entity<Subject>()
                .HasIndex(c => c.SubjectName)
                .IsUnique();
        }
        
    }
}

