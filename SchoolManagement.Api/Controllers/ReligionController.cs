using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.Religion;
using SchoolManagement.Application.Features.Religions.Requests.Commands;
using SchoolManagement.Application.Features.Religions.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.Religion)]
[ApiController]
[Authorize]
public class ReligionController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReligionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-Religions")]
    public async Task<ActionResult<List<ReligionDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var leaveTypes = await _mediator.Send(new GetReligionListRequest { QueryParams = queryParams });
        return Ok(leaveTypes);
    }


    [HttpGet]
    [Route("get-ReligionDetail/{id}")]
    public async Task<ActionResult<ReligionDto>> Get(int id)
    {
        var leaveType = await _mediator.Send(new GetReligionDetailRequest { ReligionId = id });
        return Ok(leaveType);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-Religion")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateReligionDto uTOfficerCategory)
    {
        var command = new CreateReligionCommand { ReligionDto = uTOfficerCategory };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-Religion/{id}")]
    public async Task<ActionResult> Put([FromBody] ReligionDto uTOfficerCategory)
    {
        var command = new UpdateReligionCommand { ReligionDto = uTOfficerCategory };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-Religion/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteReligionCommand { ReligionId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedReligions")]
    public async Task<ActionResult<List<SelectedModel>>> getselectedReligion()
    {
        var CasteByReligion = await _mediator.Send(new GetSelectedReligionRequest { });
        return Ok(CasteByReligion);
    }
}

