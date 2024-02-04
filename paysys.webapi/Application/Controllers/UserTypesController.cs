using Microsoft.AspNetCore.Mvc;
using paysys.webapi.Application.Contracts.Requests;
using paysys.webapi.Domain.Entities;
using paysys.webapi.Domain.Interfaces.Repositories;
using paysys.webapi.Infra.Data.UnityOfWork;

namespace paysys.webapi.Application.Controllers;

[Route("api/user-types")]
[ApiController]
[Produces("application/json")]
public class UserTypesController : ControllerBase
{
    private readonly IUserTypesRepository _userTypesRepository;
    private readonly IUnityOfWork _unityOfWork;

    public UserTypesController(IUserTypesRepository userTypesRepository, IUnityOfWork unityOfWork)
    {
        _userTypesRepository = userTypesRepository;
        _unityOfWork = unityOfWork;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var userTypesList = await _userTypesRepository.ListUserTypes()!;

            return Ok(userTypesList);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpGet("{userTypeId:Guid}")]
    public async Task<IActionResult> GetById(Guid userTypeId)
    {
        try
        {
            var findedUserType = await _userTypesRepository.GetUserType(userTypeId)!;

            return Ok(findedUserType);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserTypeRequest request)
    {
        try
        {
            var userType = UserType.Create(request.userTypeName);

            await _userTypesRepository.CreateUserType(userType);
            await _unityOfWork.Commit();

            return StatusCode(201, userType);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpDelete("{userTypeId:Guid}")]
    public async Task<IActionResult> Delete(Guid userTypeId)
    {
        try
        {
            await _userTypesRepository.DeleteUserType(userTypeId);
            await _unityOfWork.Commit();

            return NoContent();
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }
}
