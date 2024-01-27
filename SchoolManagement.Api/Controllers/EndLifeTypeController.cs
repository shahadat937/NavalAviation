using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.EndLifeTypes;
using SchoolManagement.Application.Features.EndLifeTypes.Requests.Commands;
using SchoolManagement.Application.Features.EndLifeTypes.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.EndLifeType)]
[ApiController]
[Authorize]
public class EndLifeTypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public EndLifeTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-endLifeTypes")]
    public async Task<ActionResult<List<EndLifeTypeDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var EndLifeTypes = await _mediator.Send(new GetEndLifeTypeListRequest { QueryParams = queryParams });
        return Ok(EndLifeTypes);
    }


    [HttpGet]
    [Route("get-endLifeTypeDetail/{id}")]
    public async Task<ActionResult<EndLifeTypeDto>> Get(int id)
    {
        var EndLifeType = await _mediator.Send(new GetEndLifeTypeDetailRequest { EndLifeTypeId = id });
        return Ok(EndLifeType);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-endLifeType")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateEndLifeTypeDto EndLifeType)
    {
        var command = new CreateEndLifeTypeCommand { EndLifeTypeDto = EndLifeType };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-endLifeType/{id}")]
    public async Task<ActionResult> Put([FromBody] EndLifeTypeDto EndLifeType)
    {
        var command = new UpdateEndLifeTypeCommand { EndLifeTypeDto = EndLifeType };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-endLifeType/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteEndLifeTypeCommand { EndLifeTypeId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedEndLifeType")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedEndLifeType()
    {
        var EndLifeType = await _mediator.Send(new GetSelectedEndLifeTypeRequest { });
        return Ok(EndLifeType);
    }
}

