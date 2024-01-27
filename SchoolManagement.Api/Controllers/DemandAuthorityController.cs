using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.DemandAuthority;
using SchoolManagement.Application.Features.DemandAuthorities.Requests.Commands;
using SchoolManagement.Application.Features.DemandAuthorities.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.DemandAuthority)]
[ApiController]
[Authorize]
public class DemandAuthorityController : ControllerBase
{
    private readonly IMediator _mediator;

    public DemandAuthorityController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-demandAuthoritys")]
    public async Task<ActionResult<List<DemandAuthorityDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var DemandAuthoritys = await _mediator.Send(new GetDemandAuthorityListRequest { QueryParams = queryParams });
        return Ok(DemandAuthoritys);
    }


    [HttpGet]
    [Route("get-demandAuthorityDetail/{id}")]
    public async Task<ActionResult<DemandAuthorityDto>> Get(int id)
    {
        var DemandAuthority = await _mediator.Send(new GetDemandAuthorityDetailRequest { DemandAuthorityId = id });
        return Ok(DemandAuthority);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-demandAuthority")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateDemandAuthorityDto DemandAuthority)
    {
        var command = new CreateDemandAuthorityCommand { DemandAuthorityDto = DemandAuthority };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-demandAuthority/{id}")]
    public async Task<ActionResult> Put([FromBody] DemandAuthorityDto DemandAuthority)
    {
        var command = new UpdateDemandAuthorityCommand { DemandAuthorityDto = DemandAuthority };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-demandAuthority/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteDemandAuthorityCommand { DemandAuthorityId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedDemandAuthority")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedDemandAuthority()
    {
        var DemandAuthority = await _mediator.Send(new GetSelectedDemandAuthorityRequest { });
        return Ok(DemandAuthority);
    }
}

