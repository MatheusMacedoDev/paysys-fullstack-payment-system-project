using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Flunt.Notifications;
using Flunt.Validations;
using Microsoft.EntityFrameworkCore;
using paysys.webapi.Utils;

namespace paysys.webapi.Domain.Entities;

[Table("transfer_status")]
[Index(nameof(TransferStatusName), IsUnique = true)]
public class TransferStatus : Notifiable<Notification>
{
    [Key]
    [Column("transfer_status_id")]
    public Guid TransferStatusId { get; private set; }

    [Required]
    [Column("transfer_status_name")]
    public string? TransferStatusName { get; private set; }

    public TransferStatus(string transferStatusName)
    {
        TransferStatusId = Guid.NewGuid();

        ChangeTransferStatusName(transferStatusName);
    }

    private void ChangeTransferStatusName(string statusName)
    {
        statusName = StringFormatter.BasicClear(statusName);

        AddNotifications(new Contract<TransferStatus>()
            .IsNotNullOrEmpty(statusName, "TransferStatusName", "O nome do status da transferência não deve ser nulo ou vazio")
            .IsGreaterOrEqualsThan(statusName, 4, "TransferStatusName", "O nome do status da transferência deve conter mais de quatro caracteres")
            .Matches(statusName, @"^(\s?[A-Z][a-z]+\s?)+$", "TransferStatusName", "Nome do status da transferência inválido")
        );

        TransferStatusName = statusName;
    }
}
