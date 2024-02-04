using Microsoft.AspNetCore.Mvc;
using paysys.webapi.Domain.Entities;
using paysys.webapi.Domain.Interfaces.Repositories;

namespace paysys.webapi.Application.Controllers;

[Route("api/user-types]")]
[ApiController]
[Produces("application/json")]
public class UserTypesController : ControllerBase
{
    private readonly IUserTypesRepository _userTypesRepository;

    public UserTypesController(IUserTypesRepository userTypesRepository)
    {
        _userTypesRepository = userTypesRepository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        try
        {
            var userTypesList = _userTypesRepository.ListUserTypes();

            return Ok(userTypesList);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpGet("{userTypeId:Guid}")]
    public IActionResult GetById([FromQuery] Guid userTypeId)
    {
        try
        {
            var findedUserType = _userTypesRepository.GetUserType(userTypeId);

            return Ok(findedUserType);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpPost]
    public IActionResult Create([FromBody] UserType userType)
    {
        try
        {
            _userTypesRepository.CreateUserType(userType);

            return StatusCode(201, userType);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }
}
