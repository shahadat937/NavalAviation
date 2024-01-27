using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.Store;
using SchoolManagement.Application.Features.Stores.Requests.Commands;
using SchoolManagement.Application.Features.Stores.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.Store)]
[ApiController]
[Authorize]
public class StoreController : ControllerBase
{
    private readonly IMediator _mediator;

    public StoreController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-Stores")]
    public async Task<ActionResult<List<StoreDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var Stores = await _mediator.Send(new GetStoreListRequest { QueryParams = queryParams });
        return Ok(Stores);
    }

    [HttpGet]
    [Route("get-StoreDetail/{id}")]
    public async Task<ActionResult<StoreDto>> Get(int id)
    {
        var Store = await _mediator.Send(new GetStoreDetailRequest { StoreId = id });
        return Ok(Store);
    }

    

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-Store")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateStoreDto Store)
    {
        var command = new CreateStoreCommand { StoreDto = Store };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-Store/{id}")]
    public async Task<ActionResult> Put([FromBody] StoreDto Store)
    {
        var command = new UpdateStoreCommand { StoreDto = Store };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-Store/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteStoreCommand { StoreId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedStores")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedStore()
    {
        var selectedStore = await _mediator.Send(new GetSelectedStoreRequest { });
        return Ok(selectedStore);
    }
}

