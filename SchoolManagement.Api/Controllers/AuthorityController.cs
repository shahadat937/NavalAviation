using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.Authority;
using SchoolManagement.Application.Features.Authoritys.Requests.Commands;
using SchoolManagement.Application.Features.Authoritys.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.Authority)]
[ApiController]
[Authorize]
public class AuthorityController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthorityController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-Authoritys")]
    public async Task<ActionResult<List<AuthorityDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var Authoritys = await _mediator.Send(new GetAuthorityListRequest { QueryParams = queryParams });
        return Ok(Authoritys);
    }

    [HttpGet]
    [Route("get-AuthorityDetail/{id}")]
    public async Task<ActionResult<AuthorityDto>> Get(int id)
    {
        var Authority = await _mediator.Send(new GetAuthorityDetailRequest { AuthorityId = id });
        return Ok(Authority);
    }

    

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-Authority")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateAuthorityDto Authority)
    {
        var command = new CreateAuthorityCommand { AuthorityDto = Authority };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-Authority/{id}")]
    public async Task<ActionResult> Put([FromBody] AuthorityDto Authority)
    {
        var command = new UpdateAuthorityCommand { AuthorityDto = Authority };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-Authority/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteAuthorityCommand { AuthorityId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedAuthoritys")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedAuthority()
    {
        var selectedAuthority = await _mediator.Send(new GetSelectedAuthorityRequest { });
        return Ok(selectedAuthority);
    }
}

