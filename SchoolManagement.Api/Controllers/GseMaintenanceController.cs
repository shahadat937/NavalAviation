using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.GseMaintenance;
using SchoolManagement.Application.Features.GseMaintenances.Requests.Commands;
using SchoolManagement.Application.Features.GseMaintenances.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.GseMaintenance)]
[ApiController]
[Authorize]
public class GseMaintenanceController : ControllerBase
{
    private readonly IMediator _mediator;

    public GseMaintenanceController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-gseMaintenances")]
    public async Task<ActionResult<List<GseMaintenanceDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var GseMaintenances = await _mediator.Send(new GetGseMaintenanceListRequest { QueryParams = queryParams });
        return Ok(GseMaintenances);
    }

    [HttpGet]
    [Route("get-gseMaintenanceDetail/{id}")]
    public async Task<ActionResult<GseMaintenanceDto>> Get(int id)
    {
        var GseMaintenance = await _mediator.Send(new GetGseMaintenanceDetailRequest { GseMaintenanceId = id });
        return Ok(GseMaintenance);
    }

    

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-gseMaintenance")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateGseMaintenanceDto GseMaintenance)
    {
        var command = new CreateGseMaintenanceCommand { GseMaintenanceDto = GseMaintenance };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-gseMaintenance/{id}")]
    public async Task<ActionResult> Put([FromBody] GseMaintenanceDto GseMaintenance)
    {
        var command = new UpdateGseMaintenanceCommand { GseMaintenanceDto = GseMaintenance };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-gseMaintenance/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteGseMaintenanceCommand { GseMaintenanceId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    
}

