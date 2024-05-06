using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using paysys.webapi.Domain.Entities;

namespace paysys.webapi.Infra.Data.DbConfiguration;

public class ShopkeeperConfiguration : IEntityTypeConfiguration<Shopkeeper>
{
    public void Configure(EntityTypeBuilder<Shopkeeper> builder)
    {
        builder.OwnsOne(shopkeeper => shopkeeper.FancyName)
            .Property(fancyName => fancyName.NameText)
            .HasColumnName("fancy_name")
            .IsRequired(true);

        builder.OwnsOne(shopkeeper => shopkeeper.CompanyName, ownedBuilder =>
        {
            ownedBuilder.Property(companyName => companyName.NameText)
                .HasColumnName("company_name")
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction)
                .IsRequired(true);

            ownedBuilder.HasIndex(companyName => companyName.NameText)
                .IsUnique();
        });

        builder.OwnsOne(shopkeeper => shopkeeper.ShopkeeperCNJP)
            .Property(cnpj => cnpj.CNPJText)
            .HasColumnName("shopkeeper_cnpj")
            .HasColumnType("CHAR(14)")
            .IsRequired(true);
    }
}
