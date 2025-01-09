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

    /// <summary>
    /// Registra um novo usuário administrador
    /// </summary>
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

    /// <summary>
    /// Retorna uma lista de todos os administradores
    /// </summary>
    /// <returns>Uma lista de todos os administradores</returns>
    [HttpGet("administrator")]
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

    /// <summary>
    /// Retorna os dados de um administrador específico
    /// </summary>
    /// <returns>Os dados de um administrador específico</returns>
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

    /// <summary>
    /// Registra um novo usuário comum
    /// </summary>
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

    /// <summary>
    /// Retorna uma lista de todos os usuários comuns
    /// </summary>
    /// <returns>Uma lista de todos os usuários comuns</returns>
    [HttpGet("common")]
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

    /// <summary>
    /// Retorna os dados de um usuário comum específico
    /// </summary>
    /// <returns>Os dados de um usuário comum específico</returns>
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
        }
    }

    /// <summary>
    /// Registra um novo usuário lojista
    /// </summary>
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

    /// <summary>
    /// Retorna uma lista de todos os lojistas
    /// </summary>
    /// <returns>Uma lista de todos os lojistas</returns>
    [HttpGet("shopkeeper")]
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

    /// <summary>
    /// Retorna os dados de um lojista específico
    /// </summary>
    /// <returns>Os dados de um lojista específico</returns>
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

    /// <summary>
    /// Realiza login no sistema
    /// </summary>
    /// <returns>Retorna o token JWT do usuário</returns>
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
