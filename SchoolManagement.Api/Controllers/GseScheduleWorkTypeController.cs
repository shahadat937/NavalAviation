using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.GseScheduleWorkType;
using SchoolManagement.Application.Features.GseScheduleWorkTypes.Requests.Commands;
using SchoolManagement.Application.Features.GseScheduleWorkTypes.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.GseScheduleWorkType)]
[ApiController]
[Authorize]
public class GseScheduleWorkTypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public GseScheduleWorkTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-gseScheduleWorkTypes")]
    public async Task<ActionResult<List<GseScheduleWorkTypeDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var GseScheduleWorkTypes = await _mediator.Send(new GetGseScheduleWorkTypeListRequest { QueryParams = queryParams });
        return Ok(GseScheduleWorkTypes);
    }

    [HttpGet]
    [Route("get-gseScheduleWorkTypeDetail/{id}")]
    public async Task<ActionResult<GseScheduleWorkTypeDto>> Get(int id)
    {
        var GseScheduleWorkType = await _mediator.Send(new GetGseScheduleWorkTypeDetailRequest { GseScheduleWorkTypeId = id });
        return Ok(GseScheduleWorkType);
    }

    

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-gseScheduleWorkType")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateGseScheduleWorkTypeDto GseScheduleWorkType)
    {
        var command = new CreateGseScheduleWorkTypeCommand { GseScheduleWorkTypeDto = GseScheduleWorkType };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-gseScheduleWorkType/{id}")]
    public async Task<ActionResult> Put([FromBody] GseScheduleWorkTypeDto GseScheduleWorkType)
    {
        var command = new UpdateGseScheduleWorkTypeCommand { GseScheduleWorkTypeDto = GseScheduleWorkType };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-gseScheduleWorkType/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteGseScheduleWorkTypeCommand { GseScheduleWorkTypeId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedGseScheduleWorkTypes")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedGseScheduleWorkType()
    {
        var selectedGseScheduleWorkType = await _mediator.Send(new GetSelectedGseScheduleWorkTypeRequest { });
        return Ok(selectedGseScheduleWorkType);
    }
}

