using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.ItemCategoryType;
using SchoolManagement.Application.Features.ItemCategoryTypes.Requests.Commands;
using SchoolManagement.Application.Features.ItemCategoryTypes.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.ItemCategoryType)]
[ApiController]
[Authorize]
public class ItemCategoryTypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public ItemCategoryTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-ItemCategoryTypes")]
    public async Task<ActionResult<List<ItemCategoryTypeDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var ItemCategoryTypes = await _mediator.Send(new GetItemCategoryTypeListRequest { QueryParams = queryParams });
        return Ok(ItemCategoryTypes);
    }

    [HttpGet]
    [Route("get-ItemCategoryTypeDetail/{id}")]
    public async Task<ActionResult<ItemCategoryTypeDto>> Get(int id)
    {
        var ItemCategoryType = await _mediator.Send(new GetItemCategoryTypeDetailRequest { ItemCategoryTypeId = id });
        return Ok(ItemCategoryType);
    }

    

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-ItemCategoryType")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateItemCategoryTypeDto ItemCategoryType)
    {
        var command = new CreateItemCategoryTypeCommand { ItemCategoryTypeDto = ItemCategoryType };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-ItemCategoryType/{id}")]
    public async Task<ActionResult> Put([FromBody] ItemCategoryTypeDto ItemCategoryType)
    {
        var command = new UpdateItemCategoryTypeCommand { ItemCategoryTypeDto = ItemCategoryType };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-ItemCategoryType/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteItemCategoryTypeCommand { ItemCategoryTypeId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedItemCategoryTypes")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedItemCategoryType()
    {
        var selectedItemCategoryType = await _mediator.Send(new GetSelectedItemCategoryTypeRequest { });
        return Ok(selectedItemCategoryType);
    }
}

