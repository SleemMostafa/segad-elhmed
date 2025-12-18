using Domain.Constants;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class CarpetConfiguration : IEntityTypeConfiguration<Carpet>
{
    public void Configure(EntityTypeBuilder<Carpet> builder)
    {
        // Primary Key
        builder.HasKey(e => e.Id);

        // Required String Properties with Max Length
        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(CarpetConstants.NameMaxLength);

        builder.Property(e => e.Description)
            .HasMaxLength(CarpetConstants.DescriptionMaxLength);

        builder.Property(e => e.Color)
            .IsRequired()
            .HasMaxLength(CarpetConstants.ColorMaxLength);

        builder.Property(e => e.Material)
            .IsRequired()
            .HasMaxLength(CarpetConstants.MaterialMaxLength);

        // Decimal Properties with Precision
        builder.Property(e => e.Width)
            .IsRequired()
            .HasColumnType($"decimal({CarpetConstants.DecimalPrecision},{CarpetConstants.DecimalScale})");

        builder.Property(e => e.Length)
            .IsRequired()
            .HasColumnType($"decimal({CarpetConstants.DecimalPrecision},{CarpetConstants.DecimalScale})");

        builder.Property(e => e.PricePerSquareMeter)
            .IsRequired()
            .HasColumnType($"decimal({CarpetConstants.DecimalPrecision},{CarpetConstants.DecimalScale})");

        // Integer Properties
        builder.Property(e => e.StockQuantity)
            .IsRequired();

        // DateTime Properties
        builder.Property(e => e.CreatedAt)
            .IsRequired();

        builder.Property(e => e.UpdatedAt)
            .IsRequired(false);

        // Ignore Computed Properties (not stored in database)
        builder.Ignore(e => e.Area);
        builder.Ignore(e => e.TotalPrice);

        // Foreign Key
        builder.Property(e => e.CategoryId)
            .IsRequired();

        // Indexes for common queries
        builder.HasIndex(e => e.Name);
        builder.HasIndex(e => e.Color);
        builder.HasIndex(e => e.Material);
        builder.HasIndex(e => e.StockQuantity);
        builder.HasIndex(e => e.CategoryId);
    }
}
