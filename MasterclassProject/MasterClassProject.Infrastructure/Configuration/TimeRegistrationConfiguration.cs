using MasterClassProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MasterClassProject.Infrastructure.Configuration
{
    public class TimeRegistrationConfiguration : IEntityTypeConfiguration<TimeRegistration>
    {
        public void Configure(EntityTypeBuilder<TimeRegistration> builder)
        {
            builder
                .ToTable("tblTimeRegistration", "MasterClass")
                .HasKey(t => t.Id);
            builder
                .Property(t => t.Id)
                .IsRequired();
            builder
                .Property(t => t.UserId)
                .IsRequired();
            builder
                .Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("description");
            builder
                .Property(t => t.Start)
                .IsRequired()
                .HasColumnName("startTime");
            builder
                .Property(t => t.Stop)
                .IsRequired()
                .HasColumnName("endTime");
            builder
                .HasOne(t => t.User)
                .WithMany(u => u.TimeRegistrations)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}