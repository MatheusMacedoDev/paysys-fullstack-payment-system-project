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

    /// <summary>
    /// Cria uma categoria de transferência
    /// </summary>
    [HttpPost]
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

    /// <summary>
    /// Retorna uma lista de todas as categorias de tranferência
    /// </summary>
    /// <returns>Uma lista de todas as categorias de tranferência</returns>
    [HttpGet]
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
