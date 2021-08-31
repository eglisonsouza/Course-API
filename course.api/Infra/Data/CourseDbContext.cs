using course.api.Business.Entities;
using course.api.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace course.api.Infra.Data
{
    public class CourseDbContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public CourseDbContext(DbContextOptions<CourseDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CourseMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());
            base.OnModelCreating(modelBuilder);
        }


    }
}