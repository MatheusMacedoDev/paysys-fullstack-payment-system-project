using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using paysys.webapi.Domain.ValueObjects;

namespace paysys.webapi.Infra.Data.DbConfiguration;

public class TransferStatusConfiguration : IEntityTypeConfiguration<TransferStatus>
{
    public void Configure(EntityTypeBuilder<TransferStatus> transferStatusConfiguration)
    {
        transferStatusConfiguration.ToTable("transfer_status");

        transferStatusConfiguration.Property<Guid>("transfer_status_id")
            .IsRequired();
        transferStatusConfiguration.HasKey("transfer_status_id");
    }
}
