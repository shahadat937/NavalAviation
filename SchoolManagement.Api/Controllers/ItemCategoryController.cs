using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.ItemCategorys;
using SchoolManagement.Application.Features.ItemCategories.Requests.Commands;
using SchoolManagement.Application.Features.ItemCategories.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.ItemCategory)]
[ApiController]
[Authorize]
public class ItemCategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public ItemCategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-itemCategories")]
    public async Task<ActionResult<List<ItemCategoryDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var ItemCategorys = await _mediator.Send(new GetItemCategoryListRequest { QueryParams = queryParams });
        return Ok(ItemCategorys);
    }


    [HttpGet]
    [Route("get-itemCategoryDetail/{id}")]
    public async Task<ActionResult<ItemCategoryDto>> Get(int id)
    {
        var ItemCategory = await _mediator.Send(new GetItemCategoryDetailRequest { ItemCategoryId = id });
        return Ok(ItemCategory);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-itemCategory")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateItemCategoryDto ItemCategory)
    {
        var command = new CreateItemCategoryCommand { ItemCategoryDto = ItemCategory };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-itemCategory/{id}")]
    public async Task<ActionResult> Put([FromBody] ItemCategoryDto ItemCategory)
    {
        var command = new UpdateItemCategoryCommand { ItemCategoryDto = ItemCategory };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-itemCategory/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteItemCategoryCommand { ItemCategoryId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedItemCategory")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedItemCategory(int? spareCategoryId)
    {
        var ItemCategory = await _mediator.Send(new GetSelectedItemCategoryRequest {
          spareCategoryId = spareCategoryId
        });
        return Ok(ItemCategory);
    }
}

