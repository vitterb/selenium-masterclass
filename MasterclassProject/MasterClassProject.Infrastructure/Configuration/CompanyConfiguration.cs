using MasterClassProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MasterClassProject.Infrastructure.Configuration
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder
                .ToTable("tblCompany", "Masterclass")
                .HasKey(c => c.Id);
            builder
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("CompanyName");
        }
    }
}