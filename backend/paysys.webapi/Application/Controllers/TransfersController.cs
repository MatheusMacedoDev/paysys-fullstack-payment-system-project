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

    [HttpPost("transfers")]
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

    [HttpGet("transfers/getUserTransferHistory/{userId:Guid}")]
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

    [HttpGet("transfers/getUserTransferHistory/{transferId:Guid}/{userId:Guid}")]
    public IActionResult GetFullTransfer(
        [FromRoute] Guid transferId,
        [FromRoute] Guid userId)
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
