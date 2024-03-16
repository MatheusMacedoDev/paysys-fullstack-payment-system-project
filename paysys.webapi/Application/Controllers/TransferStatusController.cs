using Microsoft.AspNetCore.Mvc;
using paysys.webapi.Application.Contracts.Requests;
using paysys.webapi.Application.Services.TransfersService;

namespace paysys.webapi.Application.Controllers;

[Route("api/transfer-status")]
[ApiController]
[Produces("application/json")]
public class TransferStatusController : ControllerBase
{
    private readonly ITransfersService _transfersService;

    public TransferStatusController(ITransfersService transfersService)
    {
        _transfersService = transfersService;
    }

    [HttpPost("transfer-status")]
    public IActionResult CreateTransferStatus([FromBody] CreateTransferStatusRequest request)
    {
        try
        {
            var response = _transfersService.CreateTransferStatus(request);

            return Ok(response);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpGet("transfer-status")]
    public async Task<IActionResult> GetAllTransferStatus()
    {
        try
        {
            var response = await _transfersService.GetAllTransferStatus();

            return Ok(response);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }
}
