using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.ToolsBoxNames;
using SchoolManagement.Application.Features.ToolsBoxNames.Requests.Commands;
using SchoolManagement.Application.Features.ToolsBoxNames.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.ToolsBoxName)]
[ApiController]
[Authorize]
public class ToolsBoxNameController : ControllerBase
{
    private readonly IMediator _mediator;

    public ToolsBoxNameController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-toolsBoxNames")]
    public async Task<ActionResult<List<ToolsBoxNameDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var ToolsBoxNames = await _mediator.Send(new GetToolsBoxNameListRequest { QueryParams = queryParams });
        return Ok(ToolsBoxNames);
    }

    [HttpGet]
    [Route("get-toolsBoxNameDetail/{id}")]
    public async Task<ActionResult<ToolsBoxNameDto>> Get(int id)
    {
        var ToolsBoxName = await _mediator.Send(new GetToolsBoxNameDetailRequest { ToolsBoxNameId = id });
        return Ok(ToolsBoxName);
    }

    

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-toolsBoxName")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateToolsBoxNameDto ToolsBoxName)
    {
        var command = new CreateToolsBoxNameCommand { ToolsBoxNameDto = ToolsBoxName };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-toolsBoxName/{id}")]
    public async Task<ActionResult> Put([FromBody] ToolsBoxNameDto ToolsBoxName)
    {
        var command = new UpdateToolsBoxNameCommand { ToolsBoxNameDto = ToolsBoxName };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-toolsBoxName/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteToolsBoxNameCommand { ToolsBoxNameId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedToolsBoxNames")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedToolsBoxName()
    {
        var selectedToolsBoxName = await _mediator.Send(new GetSelectedToolsBoxNameRequest { });
        return Ok(selectedToolsBoxName);
    }
}

