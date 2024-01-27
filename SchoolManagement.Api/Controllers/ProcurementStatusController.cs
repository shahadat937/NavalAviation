using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.ProcurementStatus;
using SchoolManagement.Application.Features.ProcurementStatuses.Requests.Commands;
using SchoolManagement.Application.Features.ProcurementStatuses.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.ProcurementStatus)]
[ApiController]
[Authorize]
public class ProcurementStatusController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProcurementStatusController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-ProcurementStatuses")]
    public async Task<ActionResult<List<ProcurementStatusDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var ProcurementStatuss = await _mediator.Send(new GetProcurementStatusListRequest { QueryParams = queryParams });
        return Ok(ProcurementStatuss);
    }

    [HttpGet]
    [Route("get-ProcurementStatusDetail/{id}")]
    public async Task<ActionResult<ProcurementStatusDto>> Get(int id)
    {
        var ProcurementStatus = await _mediator.Send(new GetProcurementStatusDetailRequest { ProcurementStatusId = id });
        return Ok(ProcurementStatus);
    }

    

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-ProcurementStatus")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateProcurementStatusDto ProcurementStatus)
    {
        var command = new CreateProcurementStatusCommand { ProcurementStatusDto = ProcurementStatus };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-ProcurementStatus/{id}")]
    public async Task<ActionResult> Put([FromBody] ProcurementStatusDto ProcurementStatus)
    {
        var command = new UpdateProcurementStatusCommand { ProcurementStatusDto = ProcurementStatus };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-ProcurementStatus/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteProcurementStatusCommand { ProcurementStatusId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedProcurementStatuses")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedProcurementStatus()
    {
        var selectedProcurementStatus = await _mediator.Send(new GetSelectedProcurementStatusRequest { });
        return Ok(selectedProcurementStatus);
    }
}

