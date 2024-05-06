namespace paysys.webapi.Application.Contracts.Requests;

public record IncreaseCommonUserBalanceRequest
(
    Guid commonUserId,
    double increaseAmount
);
