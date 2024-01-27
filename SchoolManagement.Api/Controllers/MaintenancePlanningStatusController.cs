using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.MaintenancePlanningStatus;
using SchoolManagement.Application.Features.MaintenancePlanningStatuses.Requests.Commands;
using SchoolManagement.Application.Features.MaintenancePlanningStatuses.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.MaintenancePlanningStatus)]
[ApiController]
[Authorize]
public class MaintenancePlanningStatusController : ControllerBase
{
    private readonly IMediator _mediator;

    public MaintenancePlanningStatusController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-MaintenancePlanningStatuses")]
    public async Task<ActionResult<List<MaintenancePlanningStatusDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var MaintenancePlanningStatuss = await _mediator.Send(new GetMaintenancePlanningStatusListRequest { QueryParams = queryParams });
        return Ok(MaintenancePlanningStatuss);
    }


    [HttpGet]
    [Route("get-MaintenancePlanningStatusDetail/{id}")]
    public async Task<ActionResult<MaintenancePlanningStatusDto>> Get(int id)
    {
        var MaintenancePlanningStatus = await _mediator.Send(new GetMaintenancePlanningStatusDetailRequest { MaintenancePlanningStatusId = id });
        return Ok(MaintenancePlanningStatus);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-MaintenancePlanningStatus")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateMaintenancePlanningStatusDto MaintenancePlanningStatus)
    {
        var command = new CreateMaintenancePlanningStatusCommand { MaintenancePlanningStatusDto = MaintenancePlanningStatus };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-MaintenancePlanningStatus/{id}")]
    public async Task<ActionResult> Put([FromBody] MaintenancePlanningStatusDto MaintenancePlanningStatus)
    {
        var command = new UpdateMaintenancePlanningStatusCommand { MaintenancePlanningStatusDto = MaintenancePlanningStatus };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-MaintenancePlanningStatus/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteMaintenancePlanningStatusCommand { MaintenancePlanningStatusId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedMaintenancePlanningStatus")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedMaintenancePlanningStatus()
    {
        var MaintenancePlanningStatus = await _mediator.Send(new GetSelectedMaintenancePlanningStatusRequest { });
        return Ok(MaintenancePlanningStatus);
    }
}

