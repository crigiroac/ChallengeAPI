using ChallengeAPI.BusinessObjects.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChallengeAPI.RepositoryEFCore.DataContext.Configurations
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.PhoneNumber)
                .IsRequired()
                .HasMaxLength(50);


            builder.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(150);                
            builder.HasIndex(p => p.Email)
                .IsUnique();

            //relations 
            builder.HasMany(p => p.Permissions)
                .WithOne(p => p.Employee)
                .HasForeignKey(p => p.EmployeeId)
                .IsRequired();
        }
    }
}
