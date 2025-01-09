using Microsoft.AspNetCore.Mvc;
using paysys.webapi.Application.Contracts.Requests;
using paysys.webapi.Application.Services.TransferServices.Statuses;

namespace paysys.webapi.Application.Controllers;

[Route("api/transfer-status")]
[ApiController]
[Produces("application/json")]
public class TransferStatusController : ControllerBase
{
    private readonly ITransferStatusesService _transferStatusesService;

    public TransferStatusController(ITransferStatusesService transferStatusesService)
    {
        _transferStatusesService = transferStatusesService;
    }

    /// <summary>
    /// Registra um novo status de transferência
    /// </summary>
    [HttpPost]
    public IActionResult CreateTransferStatus([FromBody] CreateTransferStatusRequest request)
    {
        try
        {
            var response = _transferStatusesService.CreateTransferStatus(request);

            return Ok(response);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    /// <summary>
    /// Retorna uma lista de todas os status de transferência
    /// </summary>
    /// <returns>Uma lista de todas os status de tranferência</returns>
    [HttpGet]
    public async Task<IActionResult> GetAllTransferStatus()
    {
        try
        {
            var response = await _transferStatusesService.GetAllTransferStatus();

            return Ok(response);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }
}
