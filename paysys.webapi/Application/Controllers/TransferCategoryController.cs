using Microsoft.AspNetCore.Mvc;
using paysys.webapi.Application.Contracts.Requests;
using paysys.webapi.Application.Services.TransfersService;

namespace paysys.webapi.Application.Controllers;

[Route("api/transfer-categories")]
[ApiController]
[Produces("application/json")]
public class TransferCategoriesController : ControllerBase
{
    private readonly ITransfersService _transfersService;

    public TransferCategoriesController(ITransfersService transfersService)
    {
        _transfersService = transfersService;
    }

    [HttpPost("transfer-categories")]
    public IActionResult CreateTransferCategory([FromBody] CreateTransferCategoryRequest request)
    {
        try
        {
            var response = _transfersService.CreateTransferCategory(request);

            return Ok(response);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpGet("transfer-categories")]
    public async Task<IActionResult> GetAllTransferCategories()
    {
        try
        {
            var response = await _transfersService.GetAllTransferCategories();

            return Ok(response);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

}
