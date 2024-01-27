using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.ItemStatuses;
using SchoolManagement.Application.Features.ItemStatuses.Requests.Commands;
using SchoolManagement.Application.Features.ItemStatuses.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.ItemStatus)]
[ApiController]
[Authorize]
public class ItemStatusController : ControllerBase
{
    private readonly IMediator _mediator;

    public ItemStatusController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-itemStatuss")]
    public async Task<ActionResult<List<ItemStatusDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var ItemStatuss = await _mediator.Send(new GetItemStatusListRequest { QueryParams = queryParams });
        return Ok(ItemStatuss);
    }


    [HttpGet]
    [Route("get-itemStatusDetail/{id}")]
    public async Task<ActionResult<ItemStatusDto>> Get(int id)
    {
        var ItemStatus = await _mediator.Send(new GetItemStatusDetailRequest { ItemStatusId = id });
        return Ok(ItemStatus);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-itemStatus")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateItemStatusDto ItemStatus)
    {
        var command = new CreateItemStatusCommand { ItemStatusDto = ItemStatus };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-itemStatus/{id}")]
    public async Task<ActionResult> Put([FromBody] ItemStatusDto ItemStatus)
    {
        var command = new UpdateItemStatusCommand { ItemStatusDto = ItemStatus };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-itemStatus/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteItemStatusCommand { ItemStatusId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedItemStatus")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedItemStatus()
    {
        var ItemStatus = await _mediator.Send(new GetSelectedItemStatusRequest { });
        return Ok(ItemStatus);
    }
}

