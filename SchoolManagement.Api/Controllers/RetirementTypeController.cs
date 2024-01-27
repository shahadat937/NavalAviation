using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.RetirementType;
using SchoolManagement.Application.Features.RetirementTypes.Requests.Commands;
using SchoolManagement.Application.Features.RetirementTypes.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.RetirementType)]
[ApiController]
[Authorize]
public class RetirementTypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public RetirementTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-RetirementTypes")]
    public async Task<ActionResult<List<RetirementTypeDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var RetirementTypes = await _mediator.Send(new GetRetirementTypeListRequest { QueryParams = queryParams });
        return Ok(RetirementTypes);
    }

    [HttpGet]
    [Route("get-RetirementTypeDetail/{id}")]
    public async Task<ActionResult<RetirementTypeDto>> Get(int id)
    {
        var RetirementType = await _mediator.Send(new GetRetirementTypeDetailRequest { RetirementTypeId = id });
        return Ok(RetirementType);
    }

    

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-RetirementType")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateRetirementTypeDto RetirementType)
    {
        var command = new CreateRetirementTypeCommand { RetirementTypeDto = RetirementType };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-RetirementType/{id}")]
    public async Task<ActionResult> Put([FromBody] RetirementTypeDto RetirementType)
    {
        var command = new UpdateRetirementTypeCommand { RetirementTypeDto = RetirementType };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-RetirementType/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteRetirementTypeCommand { RetirementTypeId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedRetirementTypes")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedRetirementType()
    {
        var selectedRetirementType = await _mediator.Send(new GetSelectedRetirementTypeRequest { });
        return Ok(selectedRetirementType);
    }
}

