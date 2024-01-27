using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.PartOfShipment;
using SchoolManagement.Application.Features.PartOfShipments.Requests.Commands;
using SchoolManagement.Application.Features.PartOfShipments.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.PartOfShipment)]
[ApiController]
[Authorize]
public class PartOfShipmentController : ControllerBase
{
    private readonly IMediator _mediator;

    public PartOfShipmentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-PartOfShipments")]
    public async Task<ActionResult<List<PartOfShipmentDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var PartOfShipments = await _mediator.Send(new GetPartOfShipmentListRequest { QueryParams = queryParams });
        return Ok(PartOfShipments);
    }

    [HttpGet]
    [Route("get-PartOfShipmentDetail/{id}")]
    public async Task<ActionResult<PartOfShipmentDto>> Get(int id)
    {
        var PartOfShipment = await _mediator.Send(new GetPartOfShipmentDetailRequest { PartOfShipmentId = id });
        return Ok(PartOfShipment);
    }

    

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-PartOfShipment")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreatePartOfShipmentDto PartOfShipment)
    {
        var command = new CreatePartOfShipmentCommand { PartOfShipmentDto = PartOfShipment };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-PartOfShipment/{id}")]
    public async Task<ActionResult> Put([FromBody] PartOfShipmentDto PartOfShipment)
    {
        var command = new UpdatePartOfShipmentCommand { PartOfShipmentDto = PartOfShipment };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-PartOfShipment/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeletePartOfShipmentCommand { PartOfShipmentId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedPartOfShipments")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedPartOfShipment()
    {
        var selectedPartOfShipment = await _mediator.Send(new GetSelectedPartOfShipmentRequest { });
        return Ok(selectedPartOfShipment);
    }
}

