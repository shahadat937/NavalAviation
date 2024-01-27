using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.OfficersStatus;
using SchoolManagement.Application.Features.OfficersStatuses.Requests.Commands;
using SchoolManagement.Application.Features.OfficersStatuses.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.OfficersStatus)]
[ApiController]
[Authorize]
public class OfficersStatusController : ControllerBase
{
    private readonly IMediator _mediator;

    public OfficersStatusController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-OfficersStatuses")]
    public async Task<ActionResult<List<OfficersStatusDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var OfficersStatuss = await _mediator.Send(new GetOfficersStatusListRequest { QueryParams = queryParams });
        return Ok(OfficersStatuss);
    }

    [HttpGet]
    [Route("get-OfficersStatusDetail/{id}")]
    public async Task<ActionResult<OfficersStatusDto>> Get(int id)
    {
        var OfficersStatus = await _mediator.Send(new GetOfficersStatusDetailRequest { OfficersStatusId = id });
        return Ok(OfficersStatus);
    }

    

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-OfficersStatus")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateOfficersStatusDto OfficersStatus)
    {
        var command = new CreateOfficersStatusCommand { OfficersStatusDto = OfficersStatus };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-OfficersStatus/{id}")]
    public async Task<ActionResult> Put([FromBody] OfficersStatusDto OfficersStatus)
    {
        var command = new UpdateOfficersStatusCommand { OfficersStatusDto = OfficersStatus };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-OfficersStatus/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteOfficersStatusCommand { OfficersStatusId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedOfficersStatuses")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedOfficersStatus()
    {
        var selectedOfficersStatus = await _mediator.Send(new GetSelectedOfficersStatusRequest { });
        return Ok(selectedOfficersStatus);
    }
}

