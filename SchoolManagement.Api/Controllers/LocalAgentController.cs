using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.LocalAgent;
using SchoolManagement.Application.Features.LocalAgents.Requests.Commands;
using SchoolManagement.Application.Features.LocalAgents.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.LocalAgent)]
[ApiController]
[Authorize]
public class LocalAgentController : ControllerBase
{
    private readonly IMediator _mediator;

    public LocalAgentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-LocalAgents")]
    public async Task<ActionResult<List<LocalAgentDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var LocalAgents = await _mediator.Send(new GetLocalAgentListRequest { QueryParams = queryParams });
        return Ok(LocalAgents);
    }

    [HttpGet]
    [Route("get-LocalAgentDetail/{id}")]
    public async Task<ActionResult<LocalAgentDto>> Get(int id)
    {
        var LocalAgent = await _mediator.Send(new GetLocalAgentDetailRequest { LocalAgentId = id });
        return Ok(LocalAgent);
    }

    

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-LocalAgent")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateLocalAgentDto LocalAgent)
    {
        var command = new CreateLocalAgentCommand { LocalAgentDto = LocalAgent };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-LocalAgent/{id}")]
    public async Task<ActionResult> Put([FromBody] LocalAgentDto LocalAgent)
    {
        var command = new UpdateLocalAgentCommand { LocalAgentDto = LocalAgent };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-LocalAgent/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteLocalAgentCommand { LocalAgentId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedLocalAgents")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedLocalAgent()
    {
        var selectedLocalAgent = await _mediator.Send(new GetSelectedLocalAgentRequest { });
        return Ok(selectedLocalAgent);
    }
}

