using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.PresentState;
using SchoolManagement.Application.Features.PresentStates.Requests.Commands;
using SchoolManagement.Application.Features.PresentStates.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.PresentState)]
[ApiController]
[Authorize]
public class PresentStateController : ControllerBase
{
    private readonly IMediator _mediator;

    public PresentStateController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-PresentStates")]
    public async Task<ActionResult<List<PresentStateDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var PresentStates = await _mediator.Send(new GetPresentStateListRequest { QueryParams = queryParams });
        return Ok(PresentStates);
    }


    [HttpGet]
    [Route("get-PresentStateDetail/{id}")]
    public async Task<ActionResult<PresentStateDto>> Get(int id)
    {
        var PresentState = await _mediator.Send(new GetPresentStateDetailRequest { PresentStateId = id });
        return Ok(PresentState);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-PresentState")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreatePresentStateDto PresentState)
    {
        var command = new CreatePresentStateCommand { PresentStateDto = PresentState };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-PresentState/{id}")]
    public async Task<ActionResult> Put([FromBody] PresentStateDto PresentState)
    {
        var command = new UpdatePresentStateCommand { PresentStateDto = PresentState };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-PresentState/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeletePresentStateCommand { PresentStateId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedPresentState")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedPresentState()
    {
        var PresentState = await _mediator.Send(new GetSelectedPresentStateRequest { });
        return Ok(PresentState);
    }
}

