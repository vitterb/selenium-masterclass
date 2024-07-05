using MasterClassProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MasterClassProject.Infrastructure.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .ToTable("tblUsers", "MasterClass")
                .HasKey(u => u.Id);
            builder
                .Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("UserName");
            builder
                .Property(u => u.CompanyId)
                .IsRequired();
            builder
               .HasOne(u => u.Company)
               .WithMany(u => u.Users)
               .HasForeignKey(u => u.CompanyId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}