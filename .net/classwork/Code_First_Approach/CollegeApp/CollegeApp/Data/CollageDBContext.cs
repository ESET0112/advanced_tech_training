using CollegeApp.Data.Config;
using Microsoft.EntityFrameworkCore;

namespace CollegeApp.Data
{
    public class CollageDBContext: DbContext
    {
        public CollageDBContext(DbContextOptions<CollageDBContext>options):base(options)
        {

            
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //            modelBuilder.Entity<Student>().HasData(new List<Student>
            //{
            //    new Student{
            //Id=1, Name="Chaitra",Email="123@gmail.com",Age=28}
            //});

            //            modelBuilder.Entity<Student>(entity =>
            //            {
            //                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
            //                entity.Property(e => e.Email).IsRequired();
            //            });

            //OR
            modelBuilder.ApplyConfiguration(new StudentConfig());


        }
    }
}
