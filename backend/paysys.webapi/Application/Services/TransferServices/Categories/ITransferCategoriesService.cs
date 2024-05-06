using paysys.webapi.Application.Contracts.Requests;
using paysys.webapi.Application.Contracts.Responses;

namespace paysys.webapi.Application.Services.TransferServices.Categories;

public interface ITransferCategoriesService
{
    CreateTransferCategoryResponse CreateTransferCategory(CreateTransferCategoryRequest request);
    Task<GetAllTransferCategoriesResponse> GetAllTransferCategories();
}
