using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.PlaceOfDelivery;
using SchoolManagement.Application.Features.PlaceOfDeliverys.Requests.Commands;
using SchoolManagement.Application.Features.PlaceOfDeliverys.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.PlaceOfDelivery)]
[ApiController]
[Authorize]
public class PlaceOfDeliveryController : ControllerBase
{
    private readonly IMediator _mediator;

    public PlaceOfDeliveryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-PlaceOfDeliverys")]
    public async Task<ActionResult<List<PlaceOfDeliveryDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var PlaceOfDeliverys = await _mediator.Send(new GetPlaceOfDeliveryListRequest { QueryParams = queryParams });
        return Ok(PlaceOfDeliverys);
    }

    [HttpGet]
    [Route("get-PlaceOfDeliveryDetail/{id}")]
    public async Task<ActionResult<PlaceOfDeliveryDto>> Get(int id)
    {
        var PlaceOfDelivery = await _mediator.Send(new GetPlaceOfDeliveryDetailRequest { PlaceOfDeliveryId = id });
        return Ok(PlaceOfDelivery);
    }

    

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-PlaceOfDelivery")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreatePlaceOfDeliveryDto PlaceOfDelivery)
    {
        var command = new CreatePlaceOfDeliveryCommand { PlaceOfDeliveryDto = PlaceOfDelivery };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-PlaceOfDelivery/{id}")]
    public async Task<ActionResult> Put([FromBody] PlaceOfDeliveryDto PlaceOfDelivery)
    {
        var command = new UpdatePlaceOfDeliveryCommand { PlaceOfDeliveryDto = PlaceOfDelivery };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-PlaceOfDelivery/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeletePlaceOfDeliveryCommand { PlaceOfDeliveryId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedPlaceOfDeliverys")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedPlaceOfDelivery()
    {
        var selectedPlaceOfDelivery = await _mediator.Send(new GetSelectedPlaceOfDeliveryRequest { });
        return Ok(selectedPlaceOfDelivery);
    }
}

