using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.ToolsLocation;
using SchoolManagement.Application.Features.ToolsLocations.Requests.Commands;
using SchoolManagement.Application.Features.ToolsLocations.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.ToolsLocation)]
[ApiController]
[Authorize]
public class ToolsLocationController : ControllerBase
{
    private readonly IMediator _mediator;

    public ToolsLocationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-toolsLocations")]
    public async Task<ActionResult<List<ToolsLocationDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var ToolsLocations = await _mediator.Send(new GetToolsLocationListRequest { QueryParams = queryParams });
        return Ok(ToolsLocations);
    }

    [HttpGet]
    [Route("get-toolsLocationDetail/{id}")]
    public async Task<ActionResult<ToolsLocationDto>> Get(int id)
    {
        var ToolsLocation = await _mediator.Send(new GetToolsLocationDetailRequest { ToolsLocationId = id });
        return Ok(ToolsLocation);
    }

    

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-toolsLocation")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateToolsLocationDto ToolsLocation)
    {
        var command = new CreateToolsLocationCommand { ToolsLocationDto = ToolsLocation };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-toolsLocation/{id}")]
    public async Task<ActionResult> Put([FromBody] ToolsLocationDto ToolsLocation)
    {
        var command = new UpdateToolsLocationCommand { ToolsLocationDto = ToolsLocation };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-toolsLocation/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteToolsLocationCommand { ToolsLocationId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedToolsLocations")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedToolsLocation()
    {
        var selectedToolsLocation = await _mediator.Send(new GetSelectedToolsLocationRequest { });
        return Ok(selectedToolsLocation);
    }
}

