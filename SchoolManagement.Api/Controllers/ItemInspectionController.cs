using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.ItemInspection;
using SchoolManagement.Application.Features.ItemInspections.Requests.Commands;
using SchoolManagement.Application.Features.ItemInspections.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.ItemInspection)]
[ApiController]
[Authorize]
public class ItemInspectionController : ControllerBase
{
    private readonly IMediator _mediator;

    public ItemInspectionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-ItemInspections")]
    public async Task<ActionResult<List<ItemInspectionDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var ItemInspections = await _mediator.Send(new GetItemInspectionListRequest { QueryParams = queryParams });
        return Ok(ItemInspections);
    }

    [HttpGet]
    [Route("get-ItemInspectionDetail/{id}")]
    public async Task<ActionResult<ItemInspectionDto>> Get(int id)
    {
        var ItemInspection = await _mediator.Send(new GetItemInspectionDetailRequest { ItemInspectionId = id });
        return Ok(ItemInspection);
    }

    

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-ItemInspection")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateItemInspectionDto ItemInspection)
    {
        var command = new CreateItemInspectionCommand { ItemInspectionDto = ItemInspection };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-ItemInspection/{id}")]
    public async Task<ActionResult> Put([FromBody] ItemInspectionDto ItemInspection)
    {
        var command = new UpdateItemInspectionCommand { ItemInspectionDto = ItemInspection };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-ItemInspection/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteItemInspectionCommand { ItemInspectionId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedItemInspections")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedItemInspection()
    {
        var selectedItemInspection = await _mediator.Send(new GetSelectedItemInspectionRequest { });
        return Ok(selectedItemInspection);
    }
}

