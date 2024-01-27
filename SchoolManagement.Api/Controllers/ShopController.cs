using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.Shop;
using SchoolManagement.Application.Features.Shops.Requests.Commands;
using SchoolManagement.Application.Features.Shops.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.Shop)]
[ApiController]
[Authorize]
public class ShopController : ControllerBase
{
    private readonly IMediator _mediator;

    public ShopController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-Shops")]
    public async Task<ActionResult<List<ShopDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var leaveTypes = await _mediator.Send(new GetShopListRequest { QueryParams = queryParams });
        return Ok(leaveTypes);
    }


    [HttpGet]
    [Route("get-ShopDetail/{id}")]
    public async Task<ActionResult<ShopDto>> Get(int id)
    {
        var leaveType = await _mediator.Send(new GetShopDetailRequest { ShopId = id });
        return Ok(leaveType);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-Shop")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateShopDto uTOfficerCategory)
    {
        var command = new CreateShopCommand { ShopDto = uTOfficerCategory };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-Shop/{id}")]
    public async Task<ActionResult> Put([FromBody] ShopDto uTOfficerCategory)
    {
        var command = new UpdateShopCommand { ShopDto = uTOfficerCategory };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-Shop/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteShopCommand { ShopId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedShops")]
    public async Task<ActionResult<List<SelectedModel>>> getselectedShop()
    {
        var CasteByShop = await _mediator.Send(new GetSelectedShopRequest { });
        return Ok(CasteByShop);
    }
}

