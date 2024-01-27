using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.RunningHour;
using SchoolManagement.Application.Features.RunningHours.Requests.Commands;
using SchoolManagement.Application.Features.RunningHours.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.RunningHour)]
[ApiController]
[Authorize]
public class RunningHourController : ControllerBase
{
    private readonly IMediator _mediator;

    public RunningHourController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-RunningHours")]
    public async Task<ActionResult<List<RunningHourDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var RunningHours = await _mediator.Send(new GetRunningHourListRequest { QueryParams = queryParams });
        return Ok(RunningHours);
    }

    [HttpGet]
    [Route("get-RunningHourDetail/{id}")]
    public async Task<ActionResult<RunningHourDto>> Get(int id)
    {
        var RunningHour = await _mediator.Send(new GetRunningHourDetailRequest { RunningHourId = id });
        return Ok(RunningHour);
    }

    

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-RunningHour")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateRunningHourDto RunningHour)
    {
        var command = new CreateRunningHourCommand { RunningHourDto = RunningHour };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-RunningHour/{id}")]
    public async Task<ActionResult> Put([FromBody] RunningHourDto RunningHour)
    {
        var command = new UpdateRunningHourCommand { RunningHourDto = RunningHour };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-RunningHour/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteRunningHourCommand { RunningHourId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedRunningHours")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedRunningHour()
    {
        var selectedRunningHour = await _mediator.Send(new GetSelectedRunningHourRequest { });
        return Ok(selectedRunningHour);
    }
    [HttpGet]
    [Route("get-RunningHourListByDepartmentAndAirCraftName")]

    public async Task<ActionResult> GetRunningHourListByDepartmentAndAirCraftName(int departmentNameId, int airCraftNameId)
    {
        var trainingCrew = await _mediator.Send(new GetRunningHourListByDepartmentAndAirCraftNameRequest
        {
            DepartmentNameId = departmentNameId,
            AirCraftNameId = airCraftNameId
        });
        return Ok(trainingCrew);
    }
}

