using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.Status;
using SchoolManagement.Application.Features.Statuses.Requests.Commands;
using SchoolManagement.Application.Features.Statuses.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.Status)]
[ApiController]
[Authorize]
public class StatusController : ControllerBase
{
    private readonly IMediator _mediator;

    public StatusController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-Statuses")]
    public async Task<ActionResult<List<StatusDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var Statuss = await _mediator.Send(new GetStatusListRequest { QueryParams = queryParams });
        return Ok(Statuss);
    }


    [HttpGet]
    [Route("get-StatusDetail/{id}")]
    public async Task<ActionResult<StatusDto>> Get(int id)
    {
        var Status = await _mediator.Send(new GetStatusDetailRequest { StatusId = id });
        return Ok(Status);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-Status")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateStatusDto Status)
    {
        var command = new CreateStatusCommand { StatusDto = Status };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-Status/{id}")]
    public async Task<ActionResult> Put([FromBody] StatusDto Status)
    {
        var command = new UpdateStatusCommand { StatusDto = Status };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-Status/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteStatusCommand { StatusId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedStatus")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedStatus()
    {
        var Status = await _mediator.Send(new GetSelectedStatusRequest { });
        return Ok(Status);
    }
}

