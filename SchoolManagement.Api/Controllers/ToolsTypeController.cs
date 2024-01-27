using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.ToolsTypes;
using SchoolManagement.Application.Features.ToolsTypes.Requests.Commands;
using SchoolManagement.Application.Features.ToolsTypes.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.ToolsType)]
[ApiController]
[Authorize]
public class ToolsTypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public ToolsTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-toolsTypes")]
    public async Task<ActionResult<List<ToolsTypeDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var ToolsTypes = await _mediator.Send(new GetToolsTypeListRequest { QueryParams = queryParams });
        return Ok(ToolsTypes);
    }


    [HttpGet]
    [Route("get-toolsTypeDetail/{id}")]
    public async Task<ActionResult<ToolsTypeDto>> Get(int id)
    {
        var ToolsType = await _mediator.Send(new GetToolsTypeDetailRequest { ToolsTypeId = id });
        return Ok(ToolsType);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-toolsType")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateToolsTypeDto ToolsType)
    {
        var command = new CreateToolsTypeCommand { ToolsTypeDto = ToolsType };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-toolsType/{id}")]
    public async Task<ActionResult> Put([FromBody] ToolsTypeDto ToolsType)
    {
        var command = new UpdateToolsTypeCommand { ToolsTypeDto = ToolsType };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-toolsType/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteToolsTypeCommand { ToolsTypeId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedToolsType")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedToolsType()
    {
        var ToolsType = await _mediator.Send(new GetSelectedToolsTypeRequest { });
        return Ok(ToolsType);
    }
}

