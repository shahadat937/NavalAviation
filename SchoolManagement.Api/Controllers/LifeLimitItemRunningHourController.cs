using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.LifeLimitItemRunningHour;
using SchoolManagement.Application.Features.LifeLimitItemRunningHours.Requests.Commands;
using SchoolManagement.Application.Features.LifeLimitItemRunningHours.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.LifeLimitItemRunningHour)]
[ApiController]
[Authorize]
public class LifeLimitItemRunningHourController : ControllerBase
{
    private readonly IMediator _mediator;

    public LifeLimitItemRunningHourController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-lifeLimitItemRunningHours")]
    public async Task<ActionResult<List<LifeLimitItemRunningHourDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var LifeLimitItemRunningHours = await _mediator.Send(new GetLifeLimitItemRunningHourListRequest { QueryParams = queryParams });
        return Ok(LifeLimitItemRunningHours);
    }

    [HttpGet]
    [Route("get-lifeLimitItemRunningHourDetail/{id}")]
    public async Task<ActionResult<LifeLimitItemRunningHourDto>> Get(int id)
    {
        var LifeLimitItemRunningHour = await _mediator.Send(new GetLifeLimitItemRunningHourDetailRequest { LifeLimitItemRunningHourId = id });
        return Ok(LifeLimitItemRunningHour);
    }

    

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-lifeLimitItemRunningHour")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateLifeLimitItemRunningHourDto LifeLimitItemRunningHour)
    {
        var command = new CreateLifeLimitItemRunningHourCommand { LifeLimitItemRunningHourDto = LifeLimitItemRunningHour };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-lifeLimitItemRunningHour/{id}")]
    public async Task<ActionResult> Put([FromBody] LifeLimitItemRunningHourDto LifeLimitItemRunningHour)
    {
        var command = new UpdateLifeLimitItemRunningHourCommand { LifeLimitItemRunningHourDto = LifeLimitItemRunningHour };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-lifeLimitItemRunningHour/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteLifeLimitItemRunningHourCommand { LifeLimitItemRunningHourId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedLifeLimitItemRunningHours")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedLifeLimitItemRunningHour()
    {
        var selectedLifeLimitItemRunningHour = await _mediator.Send(new GetSelectedLifeLimitItemRunningHourRequest { });
        return Ok(selectedLifeLimitItemRunningHour);
    }
}

