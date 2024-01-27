using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.GseMaintenanceScheduleName;
using SchoolManagement.Application.Features.GseMaintenanceScheduleNames.Requests.Commands;
using SchoolManagement.Application.Features.GseMaintenanceScheduleNames.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.GseMaintenanceScheduleName)]
[ApiController]
[Authorize]
public class GseMaintenanceScheduleNameController : ControllerBase
{
    private readonly IMediator _mediator;

    public GseMaintenanceScheduleNameController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-gseMaintenanceScheduleNames")]
    public async Task<ActionResult<List<GseMaintenanceScheduleNameDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var GseMaintenanceScheduleNames = await _mediator.Send(new GetGseMaintenanceScheduleNameListRequest { QueryParams = queryParams });
        return Ok(GseMaintenanceScheduleNames);
    }

    [HttpGet]
    [Route("get-gseMaintenanceScheduleNameDetail/{id}")]
    public async Task<ActionResult<GseMaintenanceScheduleNameDto>> Get(int id)
    {
        var GseMaintenanceScheduleName = await _mediator.Send(new GetGseMaintenanceScheduleNameDetailRequest { GseMaintenanceScheduleNameId = id });
        return Ok(GseMaintenanceScheduleName);
    }

    

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-gseMaintenanceScheduleName")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateGseMaintenanceScheduleNameDto GseMaintenanceScheduleName)
    {
        var command = new CreateGseMaintenanceScheduleNameCommand { GseMaintenanceScheduleNameDto = GseMaintenanceScheduleName };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-gseMaintenanceScheduleName/{id}")]
    public async Task<ActionResult> Put([FromBody] GseMaintenanceScheduleNameDto GseMaintenanceScheduleName)
    {
        var command = new UpdateGseMaintenanceScheduleNameCommand { GseMaintenanceScheduleNameDto = GseMaintenanceScheduleName };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-gseMaintenanceScheduleName/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteGseMaintenanceScheduleNameCommand { GseMaintenanceScheduleNameId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedGseMaintenanceScheduleNames")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedGseMaintenanceScheduleName()
    {
        var selectedGseMaintenanceScheduleName = await _mediator.Send(new GetSelectedGseMaintenanceScheduleNameRequest { });
        return Ok(selectedGseMaintenanceScheduleName);
    }
}

