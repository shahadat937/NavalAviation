using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.GseItemName;
using SchoolManagement.Application.Features.GseItemNames.Requests.Commands;
using SchoolManagement.Application.Features.GseItemNames.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.GseItemName)]
[ApiController]
[Authorize]
public class GseItemNameController : ControllerBase
{
    private readonly IMediator _mediator;

    public GseItemNameController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-gseItemNames")]
    public async Task<ActionResult<List<GseItemNameDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var GseItemNames = await _mediator.Send(new GetGseItemNameListRequest { QueryParams = queryParams });
        return Ok(GseItemNames);
    }

    [HttpGet]
    [Route("get-gseItemNameDetail/{id}")]
    public async Task<ActionResult<GseItemNameDto>> Get(int id)
    {
        var GseItemName = await _mediator.Send(new GetGseItemNameDetailRequest { GseItemNameId = id });
        return Ok(GseItemName);
    }

    

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-gseItemName")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateGseItemNameDto GseItemName)
    {
        var command = new CreateGseItemNameCommand { GseItemNameDto = GseItemName };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-gseItemName/{id}")]
    public async Task<ActionResult> Put([FromBody] GseItemNameDto GseItemName)
    {
        var command = new UpdateGseItemNameCommand { GseItemNameDto = GseItemName };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-gseItemName/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteGseItemNameCommand { GseItemNameId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedGseItemNames")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedGseItemName()
    {
        var selectedGseItemName = await _mediator.Send(new GetSelectedGseItemNameRequest { });
        return Ok(selectedGseItemName);
    }
}

