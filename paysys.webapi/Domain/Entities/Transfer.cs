using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using paysys.webapi.Domain.ValueObjects;

namespace paysys.webapi.Domain.Entities;

[Table("transfer")]
public class Transfer
{
    [Key]
    [Column("tranfer_id")]
    public Guid TransferId { get; private set; }

    [Required]
    [Column("transfer_description")]
    public string? TransferDescription { get; private set; }

    [Required]
    [Column("transfer_amount", TypeName = "MONEY")]
    public double TransferAmount { get; private set; }

    [Required]
    [Column("transfer_datetime")]
    public DateTime TransferDateTime { get; private set; }

    [Required]
    public TransferStatus? TransferStatus { get; private set; }

    [Required]
    public TransferCategory? TransferCategory { get; private set; }

    // Sender User Reference

    [Required]
    [Column("sender_user_id")]
    public Guid SenderUserId { get; private set; }

    [ForeignKey(nameof(SenderUserId))]
    public User? SenderUser { get; private set; }

    // Receiver User Reference

    [Required]
    [Column("receiver_user_id")]
    public Guid ReceiverUserId { get; private set; }

    [ForeignKey(nameof(ReceiverUserId))]
    public User? ReceiverUser { get; private set; }

    private Transfer()
    {
    }

    public static Transfer Create(string transferDescription, double transferAmount, string transferStatus, string transferCategory, Guid senderUserId, Guid receiverUserId)
    {
        var transfer = new Transfer();

        transfer.TransferId = Guid.NewGuid();
        transfer.TransferDescription = transferDescription;
        transfer.TransferAmount = transferAmount;
        transfer.TransferDateTime = DateTime.UtcNow;
        transfer.TransferStatus = new TransferStatus(transferStatus);
        transfer.TransferCategory = new TransferCategory(transferCategory);

        transfer.SenderUserId = senderUserId;
        transfer.ReceiverUserId = receiverUserId;

        return transfer;
    }
}
