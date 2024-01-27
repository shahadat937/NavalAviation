using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.ShelfLifeCategory;
using SchoolManagement.Application.Features.ShelfLifeCategorys.Requests.Commands;
using SchoolManagement.Application.Features.ShelfLifeCategorys.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.ShelfLifeCategory)]
[ApiController]
[Authorize]
public class ShelfLifeCategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public ShelfLifeCategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-ShelfLifeCategorys")]
    public async Task<ActionResult<List<ShelfLifeCategoryDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var ShelfLifeCategorys = await _mediator.Send(new GetShelfLifeCategoryListRequest { QueryParams = queryParams });
        return Ok(ShelfLifeCategorys);
    }

    [HttpGet]
    [Route("get-ShelfLifeCategoryDetail/{id}")]
    public async Task<ActionResult<ShelfLifeCategoryDto>> Get(int id)
    {
        var ShelfLifeCategory = await _mediator.Send(new GetShelfLifeCategoryDetailRequest { ShelfLifeCategoryId = id });
        return Ok(ShelfLifeCategory);
    }

    

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-ShelfLifeCategory")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateShelfLifeCategoryDto ShelfLifeCategory)
    {
        var command = new CreateShelfLifeCategoryCommand { ShelfLifeCategoryDto = ShelfLifeCategory };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-ShelfLifeCategory/{id}")]
    public async Task<ActionResult> Put([FromBody] ShelfLifeCategoryDto ShelfLifeCategory)
    {
        var command = new UpdateShelfLifeCategoryCommand { ShelfLifeCategoryDto = ShelfLifeCategory };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-ShelfLifeCategory/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteShelfLifeCategoryCommand { ShelfLifeCategoryId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedShelfLifeCategorys")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedShelfLifeCategory()
    {
        var selectedShelfLifeCategory = await _mediator.Send(new GetSelectedShelfLifeCategoryRequest { });
        return Ok(selectedShelfLifeCategory);
    }
}

