using SotsRestApi.Models;
using System.Data.Entity;

namespace SotsRestApi.DAL
{
    public class SotsContext : DbContext
    {
        public SotsContext() : base("SOTSDB")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Student> Student { get; set; }
        public DbSet<Class> Class { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Grade> Grade { get; set; }
        public DbSet<Semester> Semester { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
    }
}