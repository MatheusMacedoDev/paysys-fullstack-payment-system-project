using Microsoft.AspNetCore.Mvc;
using paysys.webapi.Application.Contracts.Requests;
using paysys.webapi.Application.Services.TransferServices.Categories;

namespace paysys.webapi.Application.Controllers;

[Route("api/transfer-categories")]
[ApiController]
[Produces("application/json")]
public class TransferCategoriesController : ControllerBase
{
    private readonly ITransferCategoriesService _transferCategoriesService;

    public TransferCategoriesController(ITransferCategoriesService transferCategoriesServices)
    {
        _transferCategoriesService = transferCategoriesServices;
    }

    [HttpPost("transfer-categories")]
    public IActionResult CreateTransferCategory([FromBody] CreateTransferCategoryRequest request)
    {
        try
        {
            var response = _transferCategoriesService.CreateTransferCategory(request);

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
            var response = await _transferCategoriesService.GetAllTransferCategories();

            return Ok(response);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

}
