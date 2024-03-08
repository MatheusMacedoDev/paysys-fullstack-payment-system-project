using paysys.webapi.Infra.Data.DAOs.TransferObjects;

namespace paysys.webapi.Application.Contracts.Responses;

public record GetShortAdministratorsResponse
(
    int administratorsQuantity,
    IEnumerable<ShortAdministratorTO> shortAdministratosList
);
