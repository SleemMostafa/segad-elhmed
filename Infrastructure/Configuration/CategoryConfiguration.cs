using Domain.Constants;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        // Primary Key
        builder.HasKey(e => e.Id);

        // Required String Properties with Max Length
        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(CategoryConstants.NameMaxLength);

        builder.Property(e => e.Description)
            .HasMaxLength(CategoryConstants.DescriptionMaxLength);

        // DateTime Properties
        builder.Property(e => e.CreatedAt)
            .IsRequired();

        builder.Property(e => e.UpdatedAt)
            .IsRequired(false);

        // Relationships
        builder.HasMany(e => e.Carpets)
            .WithOne(e => e.Category)
            .HasForeignKey(e => e.CategoryId)
            .OnDelete(DeleteBehavior.Restrict); // Prevent deleting category if it has carpets

        // Indexes
        builder.HasIndex(e => e.Name);
    }
}
