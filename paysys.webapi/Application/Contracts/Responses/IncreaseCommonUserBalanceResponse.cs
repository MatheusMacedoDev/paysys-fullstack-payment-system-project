namespace paysys.webapi.Application.Contracts.Responses;

public record IncreaseCommonUserBalanceResponse
(
    Guid commonUserId,
    double increasedAmount,
    double newBalance
);
