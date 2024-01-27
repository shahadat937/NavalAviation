using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.ConditionOfItems;
using SchoolManagement.Application.Features.ConditionOfItems.Requests.Commands;
using SchoolManagement.Application.Features.ConditionOfItems.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.ConditionOfItem)]
[ApiController]
[Authorize]
public class ConditionOfItemController : ControllerBase
{
    private readonly IMediator _mediator;

    public ConditionOfItemController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-conditionOfItems")]
    public async Task<ActionResult<List<ConditionOfItemDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var ConditionOfItems = await _mediator.Send(new GetConditionOfItemListRequest { QueryParams = queryParams });
        return Ok(ConditionOfItems);
    }


    [HttpGet]
    [Route("get-conditionOfItemDetail/{id}")]
    public async Task<ActionResult<ConditionOfItemDto>> Get(int id)
    {
        var ConditionOfItem = await _mediator.Send(new GetConditionOfItemDetailRequest { ConditionOfItemId = id });
        return Ok(ConditionOfItem);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-conditionOfItem")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateConditionOfItemDto ConditionOfItem)
    {
        var command = new CreateConditionOfItemCommand { ConditionOfItemDto = ConditionOfItem };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-conditionOfItem/{id}")]
    public async Task<ActionResult> Put([FromBody] ConditionOfItemDto ConditionOfItem)
    {
        var command = new UpdateConditionOfItemCommand { ConditionOfItemDto = ConditionOfItem };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-conditionOfItem/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteConditionOfItemCommand { ConditionOfItemId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedConditionOfItem")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedConditionOfItem()
    {
        var ConditionOfItem = await _mediator.Send(new GetSelectedConditionOfItemRequest { });
        return Ok(ConditionOfItem);
    }
}

