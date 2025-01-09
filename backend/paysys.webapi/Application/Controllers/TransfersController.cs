using Microsoft.AspNetCore.Mvc;
using paysys.webapi.Application.Contracts.Requests;
using paysys.webapi.Application.Services.TransferServices.Transfers;

namespace paysys.webapi.Application.Controllers;

[Route("api/transfers")]
[ApiController]
[Produces("application/json")]
public class TransfersController : ControllerBase
{
    private readonly ITransfersService _transfersService;

    public TransfersController(ITransfersService transfersService)
    {
        _transfersService = transfersService;
    }

    /// <summary>
    /// Registra uma nova transferência
    /// </summary>
    [HttpPost]
    public IActionResult CreateTransfer([FromBody] CreateTransferRequest request)
    {
        try
        {
            var response = _transfersService.CreateTransfer(request);

            return Ok(response);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    /// <summary>
    /// Lista o histórico de transferência de um usuário
    /// </summary>
    /// <returns>Uma lista de transferências</returns>
    [HttpGet("getUserTransferHistory")]
    public IActionResult GetUserTransferHistory([FromRoute] Guid userId)
    {
        try
        {
            var request = new GetUserTransferHistoryRequest(userId);
            var response = _transfersService.GetUserTransferHistory(request);

            return Ok(response);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    /// <summary>
    /// Exibe os dados completos de uma única transferência de um usuário
    /// </summary>
    /// <returns>Dados de uma transferências</returns>
    [HttpGet("{transferId:Guid}/users/{userId:Guid}")]
    public IActionResult GetFullTransfer(
        Guid transferId,
        Guid userId)
    {
        try
        {
            var request = new GetFullTransferRequest(transferId, userId);
            var response = _transfersService.GetFullTransfer(request);

            return Ok(response);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }
}
