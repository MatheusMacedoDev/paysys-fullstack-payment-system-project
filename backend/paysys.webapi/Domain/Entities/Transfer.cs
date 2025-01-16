using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using paysys.webapi.Domain.ValueObjects;

namespace paysys.webapi.Domain.Entities;

[Table("transfers")]
public class Transfer
{
    [Key]
    [Column("transfer_id")]
    public Guid TransferId { get; private set; }

    public Description? TransferDescription { get; private set; }

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

    protected Transfer()
    {
    }

    public Transfer(Guid transferId, double transferAmount, DateTime transferDateTime, Guid transferStatusId, Guid transferCategoryId, Guid senderUserId, Guid receiverUserId)
    {
        TransferId = transferId;
        TransferAmount = transferAmount;
        TransferDateTime = transferDateTime;

        TransferStatusId = transferStatusId;
        TransferCategoryId = transferCategoryId;
        SenderUserId = senderUserId;
        ReceiverUserId = receiverUserId;
    }

    public Transfer(string transferDescription, double transferAmount, Guid transferStatusId, Guid transferCategoryId, Guid senderUserId, Guid receiverUserId)
    {
        TransferId = Guid.NewGuid();
        TransferDescription = new Description(transferDescription);
        TransferAmount = transferAmount;
        TransferDateTime = DateTime.UtcNow;

        TransferStatusId = transferStatusId;
        TransferCategoryId = transferCategoryId;
        SenderUserId = senderUserId;
        ReceiverUserId = receiverUserId;
    }
}
