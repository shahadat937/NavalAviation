using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.ItemTypes;
using SchoolManagement.Application.Features.ItemTypes.Requests.Commands;
using SchoolManagement.Application.Features.ItemTypes.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.ItemType)]
[ApiController]
[Authorize]
public class ItemTypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public ItemTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-itemTypes")]
    public async Task<ActionResult<List<ItemTypeDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var ItemTypes = await _mediator.Send(new GetItemTypeListRequest { QueryParams = queryParams });
        return Ok(ItemTypes);
    }


    [HttpGet]
    [Route("get-itemTypeDetail/{id}")]
    public async Task<ActionResult<ItemTypeDto>> Get(int id)
    {
        var ItemType = await _mediator.Send(new GetItemTypeDetailRequest { ItemTypeId = id });
        return Ok(ItemType);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-itemType")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateItemTypeDto ItemType)
    {
        var command = new CreateItemTypeCommand { ItemTypeDto = ItemType };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-itemType/{id}")]
    public async Task<ActionResult> Put([FromBody] ItemTypeDto ItemType)
    {
        var command = new UpdateItemTypeCommand { ItemTypeDto = ItemType };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-itemType/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteItemTypeCommand { ItemTypeId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedItemType")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedItemType()
    {
        var ItemType = await _mediator.Send(new GetSelectedItemTypeRequest { });
        return Ok(ItemType);
    }
}

