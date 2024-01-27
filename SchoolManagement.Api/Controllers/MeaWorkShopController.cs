using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.MeaWorkShop;
using SchoolManagement.Application.Features.MeaWorkShops.Requests.Commands;
using SchoolManagement.Application.Features.MeaWorkShops.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.MeaWorkShop)]
[ApiController]
[Authorize]
public class MeaWorkShopController : ControllerBase
{
    private readonly IMediator _mediator;

    public MeaWorkShopController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-MeaWorkShops")]
    public async Task<ActionResult<List<MeaWorkShopDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var MeaWorkShops = await _mediator.Send(new GetMeaWorkShopListRequest { QueryParams = queryParams });
        return Ok(MeaWorkShops);
    }

    [HttpGet]
    [Route("get-MeaWorkShopDetail/{id}")]
    public async Task<ActionResult<MeaWorkShopDto>> Get(int id)
    {
        var MeaWorkShop = await _mediator.Send(new GetMeaWorkShopDetailRequest { MeaWorkShopId = id });
        return Ok(MeaWorkShop);
    }

    

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-MeaWorkShop")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateMeaWorkShopDto MeaWorkShop)
    {
        var command = new CreateMeaWorkShopCommand { MeaWorkShopDto = MeaWorkShop };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-MeaWorkShop/{id}")]
    public async Task<ActionResult> Put([FromBody] MeaWorkShopDto MeaWorkShop)
    {
        var command = new UpdateMeaWorkShopCommand { MeaWorkShopDto = MeaWorkShop };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-MeaWorkShop/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteMeaWorkShopCommand { MeaWorkShopId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedMeaWorkShops")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedMeaWorkShop()
    {
        var selectedMeaWorkShop = await _mediator.Send(new GetSelectedMeaWorkShopRequest { });
        return Ok(selectedMeaWorkShop);
    }
}

