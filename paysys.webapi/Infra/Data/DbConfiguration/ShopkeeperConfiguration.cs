using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using paysys.webapi.Domain.Entities;

namespace paysys.webapi.Infra.Data.DbConfiguration;

public class ShopkeeperConfiguration : IEntityTypeConfiguration<Shopkeeper>
{
    public void Configure(EntityTypeBuilder<Shopkeeper> builder)
    {
        builder.OwnsOne(e => e.ShopkeeperCNJP)
            .Property(p => p.CNPJText)
            .HasColumnName("shopkeeper_cnpj")
            .HasColumnType("CHAR(14)")
            .IsRequired(true);
    }
}
