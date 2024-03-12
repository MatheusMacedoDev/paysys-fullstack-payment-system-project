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

    [HttpGet("administrator/listShort")]
    public async Task<IActionResult> GetShortAdministrators()
    {
        try
        {
            var response = await _usersService.GetShortAdministrators();

            return Ok(response);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpGet("administrator/{administratorId}")]
    public async Task<IActionResult> GetFullAdministrator([FromRoute] Guid administratorId)
    {
        try
        {
            var request = new GetFullAdministratorRequest(administratorId);
            var response = await _usersService.GetFullAdministrator(request);

            if (response.administrator == null)
                return NotFound("Administrator not found.");

            return Ok(response);
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

    [HttpGet("common/listShort")]
    public async Task<IActionResult> GetShortCommonUsers()
    {
        try
        {
            var response = await _usersService.GetShortCommonUsers();

            return Ok(response);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpGet("common/{commonUserId}")]
    public async Task<IActionResult> GetFullCommonUser([FromRoute] Guid commonUserId)
    {
        try
        {
            var request = new GetFullCommonUserRequest(commonUserId);
            var response = await _usersService.GetFullCommonUser(request);

            if (response.commonUser == null)
                return NotFound("O usuário comum não foi encontrado.");

            return Ok(response);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
            throw;
        }
    }

    [HttpPost("shopkeeper")]
    public async Task<IActionResult> CreateShopkeeper([FromBody] CreateShopkeeperRequest request)
    {
        try
        {
            var response = await _usersService.CreateShopkeeper(request);

            return StatusCode(201, response);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpGet("shopkeeper/listShort")]
    public async Task<IActionResult> GetShortShopkeepers()
    {
        try
        {
            var response = await _usersService.GetShortShopkeepers();

            return Ok(response);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpGet("shopkeeper/{shopkeeperId}")]
    public async Task<IActionResult> GetFullShopkeeper([FromRoute] Guid shopkeeperId)
    {
        try
        {
            var request = new GetFullShopkeeperRequest(shopkeeperId);
            var response = await _usersService.GetFullShopkeeper(request);

            if (response.shopkeeper == null)
                return NotFound("O lojista não foi encontrado.");

            return Ok(response);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> MakeLogin([FromBody] LoginRequest request)
    {
        try
        {
            var response = await _usersService.Login(request);

            return Ok(response);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }
}
