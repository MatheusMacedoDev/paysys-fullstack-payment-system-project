using paysys.webapi.Domain.Entities;

namespace paysys.webapi.Application.Contracts.Responses;

public record GetAllTransferCategoriesResponse(
    List<TransferCategory> transferCategoriesList
);
