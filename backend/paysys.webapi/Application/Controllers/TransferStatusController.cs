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

    [HttpPost("transfer-status")]
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

    [HttpGet("transfer-status")]
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
