namespace paysys.webapi.Application.Contracts.Responses;

public record CreateTransferCategoryResponse
(
    Guid transferCategoryId,
    string transferCategoryName
);
