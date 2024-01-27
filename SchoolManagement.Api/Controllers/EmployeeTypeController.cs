using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.EmployeeType;
using SchoolManagement.Application.Features.EmployeeTypes.Requests.Commands;
using SchoolManagement.Application.Features.EmployeeTypes.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.EmployeeType)]
[ApiController]
[Authorize]
public class EmployeeTypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmployeeTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-EmployeeTypes")]
    public async Task<ActionResult<List<EmployeeTypeDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var EmployeeTypes = await _mediator.Send(new GetEmployeeTypeListRequest { QueryParams = queryParams });
        return Ok(EmployeeTypes);
    }


    [HttpGet]
    [Route("get-EmployeeTypeDetail/{id}")]
    public async Task<ActionResult<EmployeeTypeDto>> Get(int id)
    {
        var EmployeeType = await _mediator.Send(new GetEmployeeTypeDetailRequest { EmployeeTypeId = id });
        return Ok(EmployeeType);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-EmployeeType")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateEmployeeTypeDto EmployeeType)
    {
        var command = new CreateEmployeeTypeCommand { EmployeeTypeDto = EmployeeType };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-EmployeeType/{id}")]
    public async Task<ActionResult> Put([FromBody] EmployeeTypeDto EmployeeType)
    {
        var command = new UpdateEmployeeTypeCommand { EmployeeTypeDto = EmployeeType };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-EmployeeType/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteEmployeeTypeCommand { EmployeeTypeId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedEmployeeType")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedEmployeeType()
    {
        var EmployeeType = await _mediator.Send(new GetSelectedEmployeeTypeRequest { });
        return Ok(EmployeeType);
    }
}

