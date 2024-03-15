using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using paysys.webapi.Domain.ValueObjects;

namespace paysys.webapi.Infra.Data.DbConfiguration;

public class TransferCategoryConfiguration : IEntityTypeConfiguration<TransferCategory>
{
    public void Configure(EntityTypeBuilder<TransferCategory> categoryConfiguration)
    {
        categoryConfiguration.ToTable("transfer_category");

        categoryConfiguration.Property<Guid>("transfer_category_id")
            .IsRequired();
        categoryConfiguration.HasKey("transfer_category_id");
    }
}
