namespace paysys.webapi.Application.Contracts.Requests;

public record CreateShopkeeperRequest(
    string fancyName,
    string companyName,
    string cnpj,
    string userName,
    string email,
    string phoneNumber,
    string password,
    Guid userTypeId
);

