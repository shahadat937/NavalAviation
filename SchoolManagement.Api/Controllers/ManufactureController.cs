using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.Manufacture;
using SchoolManagement.Application.Features.Manufactures.Requests.Commands;
using SchoolManagement.Application.Features.Manufactures.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.Manufacture)]
[ApiController]
[Authorize]
public class ManufactureController : ControllerBase
{
    private readonly IMediator _mediator;

    public ManufactureController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-Manufactures")]
    public async Task<ActionResult<List<ManufactureDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var Manufactures = await _mediator.Send(new GetManufactureListRequest { QueryParams = queryParams });
        return Ok(Manufactures);
    }

    [HttpGet]
    [Route("get-ManufactureDetail/{id}")]
    public async Task<ActionResult<ManufactureDto>> Get(int id)
    {
        var Manufacture = await _mediator.Send(new GetManufactureDetailRequest { ManufactureId = id });
        return Ok(Manufacture);
    }

    

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-Manufacture")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateManufactureDto Manufacture)
    {
        var command = new CreateManufactureCommand { ManufactureDto = Manufacture };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-Manufacture/{id}")]
    public async Task<ActionResult> Put([FromBody] ManufactureDto Manufacture)
    {
        var command = new UpdateManufactureCommand { ManufactureDto = Manufacture };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-Manufacture/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteManufactureCommand { ManufactureId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedManufactures")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedManufacture()
    {
        var selectedManufacture = await _mediator.Send(new GetSelectedManufactureRequest { });
        return Ok(selectedManufacture);
    }
}

