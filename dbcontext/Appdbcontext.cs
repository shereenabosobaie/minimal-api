using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.EntityFrameworkCore;
using WebApplication1.models;

namespace WebApplication1.dbcontext
{
    public class Appdbcontext : DbContext
    {
        public Appdbcontext(DbContextOptions<Appdbcontext> options) : base(options) { }

        public DbSet<School> schools { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<Subject> subjects { get; set; }
        public DbSet<whichschoolcs> StudentSchools { get; set; }
        public DbSet<whichsubject> StudentSubjects { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<whichschoolcs>().HasKey(ss => new { ss.studentID, ss.shoolID });
            modelBuilder.Entity<whichschoolcs>().HasOne(ss => ss.student).WithMany(s => s.whichschoolcs).HasForeignKey(ss => ss.studentID);
            modelBuilder.Entity<whichschoolcs>().HasOne(ss => ss.school).WithMany(s => s.whichschoolcs).HasForeignKey(ss => ss.shoolID);

            modelBuilder.Entity<whichsubject>().HasKey(ss => new { ss.studentID, ss.subjectID });
            modelBuilder.Entity<whichsubject>().HasOne(ss => ss.student).WithMany(s => s.whichsubject).HasForeignKey(ss => ss.studentID);
            modelBuilder.Entity<whichsubject>().HasOne(ss => ss.Subject).WithMany(s => s.whichsubject).HasForeignKey(ss => ss.subjectID);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
