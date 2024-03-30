using ChallengeAPI.BusinessObjects.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChallengeAPI.RepositoryEFCore.DataContext.Configurations
{
    internal class LogConfiguration : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.ToTable("Logs");

            builder.Property(p => p.OperationType)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.OperationRequest)
                .IsRequired()
                .HasMaxLength(1500);

            builder.Property(p => p.OperarionResponse)
             .IsRequired()
             .HasMaxLength(1500);

            builder.Property(p => p.OperationStatus)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(p => p.Client)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(150);

            builder.HasIndex(p => p.OperationType)
                .IsDescending();
            builder.HasIndex(p => p.OperationStatus)
                .IsDescending();

        }
    }
}
