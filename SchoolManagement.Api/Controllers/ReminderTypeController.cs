using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.ReminderType;
using SchoolManagement.Application.Features.ReminderTypes.Requests.Commands;
using SchoolManagement.Application.Features.ReminderTypes.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.ReminderType)]
[ApiController]
[Authorize]
public class ReminderTypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReminderTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-reminderTypes")]
    public async Task<ActionResult<List<ReminderTypeDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var ReminderTypes = await _mediator.Send(new GetReminderTypeListRequest { QueryParams = queryParams });
        return Ok(ReminderTypes);
    }

    [HttpGet]
    [Route("get-reminderTypeDetail/{id}")]
    public async Task<ActionResult<ReminderTypeDto>> Get(int id)
    {
        var ReminderType = await _mediator.Send(new GetReminderTypeDetailRequest { ReminderTypeId = id });
        return Ok(ReminderType);
    }

    

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-reminderType")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateReminderTypeDto ReminderType)
    {
        var command = new CreateReminderTypeCommand { ReminderTypeDto = ReminderType };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-reminderType/{id}")]
    public async Task<ActionResult> Put([FromBody] ReminderTypeDto ReminderType)
    {
        var command = new UpdateReminderTypeCommand { ReminderTypeDto = ReminderType };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-reminderType/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteReminderTypeCommand { ReminderTypeId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedReminderTypes")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedReminderType()
    {
        var selectedReminderType = await _mediator.Send(new GetSelectedReminderTypeRequest { });
        return Ok(selectedReminderType);
    }
}

