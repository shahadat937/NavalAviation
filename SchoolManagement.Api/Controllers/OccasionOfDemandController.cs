using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.OccasionOfDemand;
using SchoolManagement.Application.Features.OccasionOfDemands.Requests.Commands;
using SchoolManagement.Application.Features.OccasionOfDemands.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.OccasionOfDemand)]
[ApiController]
[Authorize]
public class OccasionOfDemandController : ControllerBase
{
    private readonly IMediator _mediator;

    public OccasionOfDemandController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-OccasionOfDemands")]
    public async Task<ActionResult<List<OccasionOfDemandDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var OccasionOfDemands = await _mediator.Send(new GetOccasionOfDemandListRequest { QueryParams = queryParams });
        return Ok(OccasionOfDemands);
    }

    [HttpGet]
    [Route("get-OccasionOfDemandDetail/{id}")]
    public async Task<ActionResult<OccasionOfDemandDto>> Get(int id)
    {
        var OccasionOfDemand = await _mediator.Send(new GetOccasionOfDemandDetailRequest { OccasionOfDemandId = id });
        return Ok(OccasionOfDemand);
    }

    

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-OccasionOfDemand")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateOccasionOfDemandDto OccasionOfDemand)
    {
        var command = new CreateOccasionOfDemandCommand { OccasionOfDemandDto = OccasionOfDemand };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-OccasionOfDemand/{id}")]
    public async Task<ActionResult> Put([FromBody] OccasionOfDemandDto OccasionOfDemand)
    {
        var command = new UpdateOccasionOfDemandCommand { OccasionOfDemandDto = OccasionOfDemand };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-OccasionOfDemand/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteOccasionOfDemandCommand { OccasionOfDemandId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedOccasionOfDemands")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedOccasionOfDemand()
    {
        var selectedOccasionOfDemand = await _mediator.Send(new GetSelectedOccasionOfDemandRequest { });
        return Ok(selectedOccasionOfDemand);
    }
}

