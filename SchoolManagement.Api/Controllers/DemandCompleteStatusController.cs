using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.DemandCompleteStatuses;
using SchoolManagement.Application.Features.DemandCompleteStatuses.Requests.Commands;
using SchoolManagement.Application.Features.DemandCompleteStatuses.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.DemandCompleteStatus)]
[ApiController]
[Authorize]
public class DemandCompleteStatusController : ControllerBase
{
    private readonly IMediator _mediator;

    public DemandCompleteStatusController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-demandCompleteStatuss")]
    public async Task<ActionResult<List<DemandCompleteStatusDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var DemandCompleteStatuss = await _mediator.Send(new GetDemandCompleteStatusListRequest { QueryParams = queryParams });
        return Ok(DemandCompleteStatuss);
    }


    [HttpGet]
    [Route("get-demandCompleteStatusDetail/{id}")]
    public async Task<ActionResult<DemandCompleteStatusDto>> Get(int id)
    {
        var DemandCompleteStatus = await _mediator.Send(new GetDemandCompleteStatusDetailRequest { DemandCompleteStatusId = id });
        return Ok(DemandCompleteStatus);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-demandCompleteStatus")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateDemandCompleteStatusDto DemandCompleteStatus)
    {
        var command = new CreateDemandCompleteStatusCommand { DemandCompleteStatusDto = DemandCompleteStatus };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-demandCompleteStatus/{id}")]
    public async Task<ActionResult> Put([FromBody] DemandCompleteStatusDto DemandCompleteStatus)
    {
        var command = new UpdateDemandCompleteStatusCommand { DemandCompleteStatusDto = DemandCompleteStatus };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-demandCompleteStatus/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteDemandCompleteStatusCommand { DemandCompleteStatusId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedDemandCompleteStatus")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedDemandCompleteStatus()
    {
        var DemandCompleteStatus = await _mediator.Send(new GetSelectedDemandCompleteStatusRequest { });
        return Ok(DemandCompleteStatus);
    }
}

