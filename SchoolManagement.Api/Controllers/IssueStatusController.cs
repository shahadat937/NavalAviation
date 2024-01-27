using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.IssueStatus;
using SchoolManagement.Application.Features.IssueStatuses.Requests.Commands;
using SchoolManagement.Application.Features.IssueStatuses.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.IssueStatus)]
[ApiController]
[Authorize]
public class IssueStatusController : ControllerBase
{
    private readonly IMediator _mediator;

    public IssueStatusController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-IssueStatuses")]
    public async Task<ActionResult<List<IssueStatusDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var IssueStatuss = await _mediator.Send(new GetIssueStatusListRequest { QueryParams = queryParams });
        return Ok(IssueStatuss);
    }

    [HttpGet]
    [Route("get-IssueStatusDetail/{id}")]
    public async Task<ActionResult<IssueStatusDto>> Get(int id)
    {
        var IssueStatus = await _mediator.Send(new GetIssueStatusDetailRequest { IssueStatusId = id });
        return Ok(IssueStatus);
    }

    

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-IssueStatus")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateIssueStatusDto IssueStatus)
    {
        var command = new CreateIssueStatusCommand { IssueStatusDto = IssueStatus };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-IssueStatus/{id}")]
    public async Task<ActionResult> Put([FromBody] IssueStatusDto IssueStatus)
    {
        var command = new UpdateIssueStatusCommand { IssueStatusDto = IssueStatus };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-IssueStatus/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteIssueStatusCommand { IssueStatusId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedIssueStatuses")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedIssueStatus()
    {
        var selectedIssueStatus = await _mediator.Send(new GetSelectedIssueStatusRequest { });
        return Ok(selectedIssueStatus);
    }
}

