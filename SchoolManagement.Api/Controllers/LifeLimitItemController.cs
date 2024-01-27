using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.LifeLimitItem;
using SchoolManagement.Application.Features.LifeLimitItems.Requests.Commands;
using SchoolManagement.Application.Features.LifeLimitItems.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.LifeLimitItem)]
[ApiController]
[Authorize]
public class LifeLimitItemController : ControllerBase
{
    private readonly IMediator _mediator;

    public LifeLimitItemController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-lifeLimitItems")]
    public async Task<ActionResult<List<LifeLimitItemDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var LifeLimitItems = await _mediator.Send(new GetLifeLimitItemListRequest { QueryParams = queryParams });
        return Ok(LifeLimitItems);
    }

    [HttpGet]
    [Route("get-lifeLimitItemDetail/{id}")]
    public async Task<ActionResult<LifeLimitItemDto>> Get(int id)
    {
        var LifeLimitItem = await _mediator.Send(new GetLifeLimitItemDetailRequest { LifeLimitItemId = id });
        return Ok(LifeLimitItem);
    }

    

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-lifeLimitItem")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateLifeLimitItemDto LifeLimitItem)
    {
        var command = new CreateLifeLimitItemCommand { LifeLimitItemDto = LifeLimitItem };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-lifeLimitItem/{id}")]
    public async Task<ActionResult> Put([FromBody] LifeLimitItemDto LifeLimitItem)
    {
        var command = new UpdateLifeLimitItemCommand { LifeLimitItemDto = LifeLimitItem };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-lifeLimitItem/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteLifeLimitItemCommand { LifeLimitItemId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedLifeLimitItems")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedLifeLimitItem()
    {
        var selectedLifeLimitItem = await _mediator.Send(new GetSelectedLifeLimitItemRequest { });
        return Ok(selectedLifeLimitItem);
    }
}

