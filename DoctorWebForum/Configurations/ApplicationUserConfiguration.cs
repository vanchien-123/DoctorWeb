using DoctorWebForum.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoctorWebForum.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(x => x.Name).IsRequired();

            builder.HasOne(x => x.Qualification)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.QualificationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Experience)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.ExperienceId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
