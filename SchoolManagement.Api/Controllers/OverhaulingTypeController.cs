using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.OverhaulingType;
using SchoolManagement.Application.Features.OverhaulingTypes.Requests.Commands;
using SchoolManagement.Application.Features.OverhaulingTypes.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.OverhaulingType)]
[ApiController]
[Authorize]
public class OverhaulingTypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public OverhaulingTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-OverhaulingTypes")]
    public async Task<ActionResult<List<OverhaulingTypeDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var OverhaulingTypes = await _mediator.Send(new GetOverhaulingTypeListRequest { QueryParams = queryParams });
        return Ok(OverhaulingTypes);
    }

    [HttpGet]
    [Route("get-OverhaulingTypeDetail/{id}")]
    public async Task<ActionResult<OverhaulingTypeDto>> Get(int id)
    {
        var OverhaulingType = await _mediator.Send(new GetOverhaulingTypeDetailRequest { OverhaulingTypeId = id });
        return Ok(OverhaulingType);
    }

    

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-OverhaulingType")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateOverhaulingTypeDto OverhaulingType)
    {
        var command = new CreateOverhaulingTypeCommand { OverhaulingTypeDto = OverhaulingType };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-OverhaulingType/{id}")]
    public async Task<ActionResult> Put([FromBody] OverhaulingTypeDto OverhaulingType)
    {
        var command = new UpdateOverhaulingTypeCommand { OverhaulingTypeDto = OverhaulingType };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-OverhaulingType/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteOverhaulingTypeCommand { OverhaulingTypeId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedOverhaulingTypes")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedOverhaulingType()
    {
        var selectedOverhaulingType = await _mediator.Send(new GetSelectedOverhaulingTypeRequest { });
        return Ok(selectedOverhaulingType);
    }
}

