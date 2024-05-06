namespace paysys.webapi.Infra.Data.DAOs.TransferObjects;

public record UserTransferHistoryItemTO(
    Guid transferId,
    string? transferDescription,
    string? transferCategoryName,
    DateTime transferDateTime,
    decimal transferAmount,
    bool isSenderTransferUser
);
