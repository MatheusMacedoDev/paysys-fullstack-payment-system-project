using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using paysys.webapi.Domain.Entities;

namespace paysys.webapi.Infra.Data.DbConfiguration;

public class TransferCategoryConfiguration : IEntityTypeConfiguration<TransferCategory>
{
    public void Configure(EntityTypeBuilder<TransferCategory> builder)
    {
        builder.OwnsOne(category => category.TransferCategoryName, ownedBuilder =>
        {
            ownedBuilder.Property(categoryName => categoryName.NameText)
                .HasColumnName("transfer_category_name")
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction)
                .IsRequired(true);

            ownedBuilder.HasIndex(categoryName => categoryName.NameText)
                .IsUnique();
        });
    }
}
