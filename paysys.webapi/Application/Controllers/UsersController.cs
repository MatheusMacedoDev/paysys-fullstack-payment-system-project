using Microsoft.AspNetCore.Mvc;
using paysys.webapi.Application.Contracts.Requests;
using paysys.webapi.Application.Services.UsersService;

namespace paysys.webapi.Application.Controllers;

[Route("api/users")]
[ApiController]
[Produces("application/json")]
public class UsersController : ControllerBase
{
    private readonly IUsersService _usersService;

    public UsersController(IUsersService usersService)
    {
        _usersService = usersService;
    }

    [HttpPost("administrator")]
    public async Task<IActionResult> CreateAdministrator([FromBody] CreateAdministratorRequest request)
    {
        try
        {
            var response = await _usersService.CreateAdministrator(request);

            return StatusCode(201, response);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpPost("common")]
    public async Task<IActionResult> CreateCommonUser([FromBody] CreateCommonUserRequest request)
    {
        try
        {
            var response = await _usersService.CreateCommonUser(request);

            return StatusCode(201, response);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }
}
