using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CollegeApp.Data.Config
{
    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");
            builder.HasKey(e => e.studentID);
            builder.Property(e => e.studentID).UseIdentityColumn();

            builder.Property(e => e.name).IsRequired().HasMaxLength(250);
            builder.Property(e => e.email).IsRequired();

            builder.HasData(new List<Student>
                        {
                            new Student {
                                studentID = 1,
                                name = "Chaitra",
                                 age = 28,
                                email = "123@gmail.com",
                               

                            }
                        });

        }
    }
}
