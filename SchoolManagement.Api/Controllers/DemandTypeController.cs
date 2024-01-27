using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.DemandType;
using SchoolManagement.Application.Features.DemandTypes.Requests.Commands;
using SchoolManagement.Application.Features.DemandTypes.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.DemandType)]
[ApiController]
[Authorize]
public class DemandTypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public DemandTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-DemandTypes")]
    public async Task<ActionResult<List<DemandTypeDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var DemandTypes = await _mediator.Send(new GetDemandTypeListRequest { QueryParams = queryParams });
        return Ok(DemandTypes);
    }

    [HttpGet]
    [Route("get-DemandTypeDetail/{id}")]
    public async Task<ActionResult<DemandTypeDto>> Get(int id)
    {
        var DemandType = await _mediator.Send(new GetDemandTypeDetailRequest { DemandTypeId = id });
        return Ok(DemandType);
    }

    

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-DemandType")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateDemandTypeDto DemandType)
    {
        var command = new CreateDemandTypeCommand { DemandTypeDto = DemandType };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-DemandType/{id}")]
    public async Task<ActionResult> Put([FromBody] DemandTypeDto DemandType)
    {
        var command = new UpdateDemandTypeCommand { DemandTypeDto = DemandType };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-DemandType/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteDemandTypeCommand { DemandTypeId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedDemandTypes")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedDemandType()
    {
        var selectedDemandType = await _mediator.Send(new GetSelectedDemandTypeRequest { });
        return Ok(selectedDemandType);
    }
}

