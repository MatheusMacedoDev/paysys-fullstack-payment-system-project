using paysys.webapi.Application.Contracts.Requests;
using paysys.webapi.Application.Contracts.Responses;
using paysys.webapi.Domain.Entities;
using paysys.webapi.Domain.Interfaces.Repositories;
using paysys.webapi.Infra.Data.UnityOfWork;

namespace paysys.webapi.Application.Services.TransferServices.Categories;

public class TransferCategoriesService : ITransferCategoriesService
{
    // Repository
    private readonly ITransfersRepository _transfersRepository;

    // Unity of Work
    private readonly IUnityOfWork _unityOfWork;

    public TransferCategoriesService(ITransfersRepository transfersRepository, IUnityOfWork unityOfWork)
    {
        _transfersRepository = transfersRepository;

        _unityOfWork = unityOfWork;
    }

    public CreateTransferCategoryResponse CreateTransferCategory(CreateTransferCategoryRequest request)
    {
        try
        {
            var transferCategory = new TransferCategory(
                request.transferCategoryName
            );

            _transfersRepository.CreateTransferCategory(transferCategory);
            _unityOfWork.Commit();

            var response = new CreateTransferCategoryResponse(
                transferCategory.TransferCategoryId,
                transferCategory.TransferCategoryName!.NameText!
            );

            return response;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<GetAllTransferCategoriesResponse> GetAllTransferCategories()
    {
        try
        {
            var transferCategoriesList = await _transfersRepository.GetAllTransferCategories();
            var response = new GetAllTransferCategoriesResponse(transferCategoriesList);

            return response;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
