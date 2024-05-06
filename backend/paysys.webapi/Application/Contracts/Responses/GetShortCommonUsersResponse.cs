using paysys.webapi.Infra.Data.DAOs.TransferObjects;

namespace paysys.webapi;

public record GetShortCommonUsersResponse(
    int commonUsersQuantity,
    IEnumerable<ShortCommonUserTO> commonUserList
);
