using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

    // Transfer Category Reference

    [Required]
    [Column("transfer_category_id")]
    public Guid TransferCategoryId { get; private set; }

    [ForeignKey(nameof(TransferCategoryId))]
    public TransferCategory? TransferCategory { get; private set; }

    // Transfer Status Reference

    [Required]
    [Column("transfer_status_id")]
    public Guid TransferStatusId { get; private set; }

    [ForeignKey(nameof(TransferStatusId))]
    public TransferStatus? TransferStatus { get; private set; }

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

    public static Transfer Create(string transferDescription, double transferAmount, Guid transferStatusId, Guid transferCategoryId, Guid senderUserId, Guid receiverUserId)
    {
        var transfer = new Transfer();

        transfer.TransferId = Guid.NewGuid();
        transfer.TransferDescription = transferDescription;
        transfer.TransferAmount = transferAmount;
        transfer.TransferDateTime = DateTime.UtcNow;
        transfer.TransferStatusId = transferStatusId;
        transfer.TransferCategoryId = transferCategoryId;

        transfer.SenderUserId = senderUserId;
        transfer.ReceiverUserId = receiverUserId;

        return transfer;
    }
}
