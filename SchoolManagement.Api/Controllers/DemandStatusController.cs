using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.DemandStatus;
using SchoolManagement.Application.Features.DemandStatuses.Requests.Commands;
using SchoolManagement.Application.Features.DemandStatuses.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.DemandStatus)]
[ApiController]
[Authorize]
public class DemandStatusController : ControllerBase
{
    private readonly IMediator _mediator;

    public DemandStatusController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-DemandStatuses")]
    public async Task<ActionResult<List<DemandStatusDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var DemandStatuss = await _mediator.Send(new GetDemandStatusListRequest { QueryParams = queryParams });
        return Ok(DemandStatuss);
    }

    [HttpGet]
    [Route("get-DemandStatusDetail/{id}")]
    public async Task<ActionResult<DemandStatusDto>> Get(int id)
    {
        var DemandStatus = await _mediator.Send(new GetDemandStatusDetailRequest { DemandStatusId = id });
        return Ok(DemandStatus);
    }

    

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-DemandStatus")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateDemandStatusDto DemandStatus)
    {
        var command = new CreateDemandStatusCommand { DemandStatusDto = DemandStatus };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-DemandStatus/{id}")]
    public async Task<ActionResult> Put([FromBody] DemandStatusDto DemandStatus)
    {
        var command = new UpdateDemandStatusCommand { DemandStatusDto = DemandStatus };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-DemandStatus/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteDemandStatusCommand { DemandStatusId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedDemandStatuses")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedDemandStatus()
    {
        var selectedDemandStatus = await _mediator.Send(new GetSelectedDemandStatusRequest { });
        return Ok(selectedDemandStatus);
    }
}

