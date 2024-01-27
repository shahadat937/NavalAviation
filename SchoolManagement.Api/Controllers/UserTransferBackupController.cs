using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.UserTransferBackups;
using SchoolManagement.Application.Features.UserTransferBackups.Requests.Commands;
using SchoolManagement.Application.Features.UserTransferBackups.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.UserTransferBackup)]
[ApiController]
[Authorize]
public class UserTransferBackupController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserTransferBackupController(IMediator mediator)   
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-UserTransferBackups")]
    public async Task<ActionResult<List<UserTransferBackupDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var UserTransferBackups = await _mediator.Send(new GetUserTransferBackupListRequest { QueryParams = queryParams });
        return Ok(UserTransferBackups);
    }


    [HttpGet]
    [Route("get-UserTransferBackupDetail/{id}")]
    public async Task<ActionResult<UserTransferBackupDto>> Get(int id)
    {
        var UserTransferBackup = await _mediator.Send(new GetUserTransferBackupDetailRequest { Id = id });
        return Ok(UserTransferBackup);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-UserTransferBackup")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] List<CreateUserTransferBackupDto> UserTransferBackup)
    {
      var command = new CreateUserTransferBackupCommand { UserTransferBackupDto = UserTransferBackup };
      var response = await _mediator.Send(command);
      return Ok(response);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-UserTransferBackup/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteUserTransferBackupCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedUserTransferBackup")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedUserTransferBackup()
    {
        var UserTransferBackup = await _mediator.Send(new GetSelectedUserTransferBackupRequest { });
        return Ok(UserTransferBackup);
    }
}

