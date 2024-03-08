using paysys.webapi.Infra.Data.DAOs.TransferObjects;

namespace paysys.webapi.Application.Contracts.Responses;

public record GetFullShopkeeperResponse
(
    FullShopkeeperTO shopkeeper
);
