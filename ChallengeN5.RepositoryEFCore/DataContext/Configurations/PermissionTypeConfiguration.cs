using ChallengeAPI.BusinessObjects.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace ChallengeAPI.RepositoryEFCore.DataContext.Configurations
{
    internal class PermissionTypeConfiguration : IEntityTypeConfiguration<PermissionType>
    {
        public void Configure(EntityTypeBuilder<PermissionType> builder)
        {
            builder.ToTable("PermissionTypes");

            builder.Property(p => p.PermissionTypeName)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasIndex(p => p.PermissionTypeName)
                .IsUnique();

            //relations 
            builder.HasMany(p => p.Permissions)
                .WithOne(p => p.PermissionType)
                .HasForeignKey(p => p.PermissionTypeId)
                .IsRequired();
        }
    }
}
