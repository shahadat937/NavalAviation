using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.Division;
using SchoolManagement.Application.Features.Divisions.Requests.Commands;
using SchoolManagement.Application.Features.Divisions.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.Division)]
[ApiController]
[Authorize]
public class DivisionController : ControllerBase
{
    private readonly IMediator _mediator;

    public DivisionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-divisions")]
    public async Task<ActionResult<List<DivisionDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var Divisions = await _mediator.Send(new GetDivisionListRequest { QueryParams = queryParams });
        return Ok(Divisions);
    }



    [HttpGet]
    [Route("get-divisionDetail/{id}")]
    public async Task<ActionResult<DivisionDto>> Get(int id)
    {
        var Division = await _mediator.Send(new GetDivisionDetailRequest { DivisionId = id });
        return Ok(Division);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-division")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateDivisionDto bDivision)
    {
        var command = new CreateDivisionCommand { DivisionDto = bDivision };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-division/{id}")]
    public async Task<ActionResult> Put([FromBody] DivisionDto bDivision)
    {
        var command = new UpdateDivisionCommand { DivisionDto = bDivision };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-division/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteDivisionCommand { DivisionId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    //Relational data get 
    [HttpGet]
    [Route("get-selectedDivisions")]
    public async Task<ActionResult<List<SelectedModel>>> getselecteddivision()
    {
        var selectedDivision = await _mediator.Send(new GetSelectedDivisionRequest { });
        return Ok(selectedDivision);
    }
}

