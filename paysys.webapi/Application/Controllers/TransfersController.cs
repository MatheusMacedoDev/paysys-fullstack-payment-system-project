using Microsoft.AspNetCore.Mvc;
using paysys.webapi.Application.Contracts.Requests;
using paysys.webapi.Application.Services.TransfersService;

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
}
