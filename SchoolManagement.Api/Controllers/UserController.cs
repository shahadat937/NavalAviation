using SchoolManagement.Application.Contracts.Identity;
using SchoolManagement.Application.DTOs.User;

namespace SchoolManagement.Api.Controllers;

//[Route(SMSRoutePrefix.Users)]
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMediator _mediator;
    public UsersController(IUserService userService, IMediator mediator)
    {
        _userService = userService;
        _mediator = mediator;
    }



    [HttpGet]
    [Route("get-users")]
    public async Task<ActionResult> Get([FromQuery] QueryParams queryParams)
    {
        var Users = await _userService.GetUsers(queryParams);
        return Ok(Users);
    }

    [HttpGet]
    [Route("get-alluserinfo-for-usertransfer")]
    public async Task<ActionResult> GetAllUsersForUserTransfar()
    {
      var Users = await _userService.GetAllUsersInformation();
      return Ok(Users);
    }

  [HttpGet]
    [Route("get-userDetail/{id}")]
    public async Task<ActionResult<UserDto>> Get(string id)
    {
        var User = await _userService.GetUserById(id);
        return Ok(User);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-user")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateUserDto User)
    {

        return Ok(await _userService.Save("", User));
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    //[Route("update-user/{id}")]
    [Route("update-user")]
    public async Task<ActionResult> Put(string userId, [FromBody] CreateUserDto User)
    {
        await _userService.Save(userId, User);
        return NoContent();
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    // [ProducesDefaultResponseType]
    [Route("update-paswordfor-individualuser")]
    public async Task<ActionResult> UpdatePassword([FromBody] PasswordChangeDto User)
    {
      await _userService.UpdateUserPassword(User.UserId, User);
      return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-user/{id}")]
    public async Task<ActionResult<BaseCommandResponse>> Delete(string id)
    {
        await _userService.DeleteUser(id);
        return NoContent();
    }
    //[HttpPost]
    //[ProducesResponseType(StatusCodes.Status204NoContent)]
    //[ProducesResponseType(StatusCodes.Status404NotFound)]
    //[Route("update-paswordfor-individualuser")]
    //public async Task<ActionResult> UpdatePassword([FromBody] PasswordChangeDto User)
    //{
    //  await _userService.UpdateUserPassword(User.UserId, User);
    //  return NoContent();
    //}
}

