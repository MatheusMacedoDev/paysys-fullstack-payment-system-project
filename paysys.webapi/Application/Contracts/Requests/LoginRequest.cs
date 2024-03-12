namespace paysys.webapi.Application.Contracts.Requests;

public record LoginRequest
(
    string userEmail,
    string userPassword
);
