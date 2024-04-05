using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using paysys.webapi.Domain.Entities;

namespace paysys.webapi.Infra.Data.DbConfiguration;

public class TransferStatusConfiguration : IEntityTypeConfiguration<TransferStatus>
{
    public void Configure(EntityTypeBuilder<TransferStatus> builder)
    {
        builder.OwnsOne(status => status.TransferStatusName, ownedBuilder =>
        {
            ownedBuilder.Property(statusName => statusName.NameText)
                .HasColumnName("transfer_status_name")
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction)
                .IsRequired(true);

            ownedBuilder.HasIndex(statusName => statusName.NameText)
                .IsUnique();
        });
    }
}
