using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.DepartmentName;
using SchoolManagement.Application.Features.DepartmentNames.Requests.Commands;
using SchoolManagement.Application.Features.DepartmentNames.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.DepartmentName)]
[ApiController]
[Authorize]
public class DepartmentNameController : ControllerBase
{
    private readonly IMediator _mediator;

    public DepartmentNameController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-DepartmentNames")]
    public async Task<ActionResult<List<DepartmentNameDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var DepartmentNames = await _mediator.Send(new GetDepartmentNameListRequest { QueryParams = queryParams });
        return Ok(DepartmentNames);
    }

    [HttpGet]
    [Route("get-DepartmentNameDetail/{id}")]
    public async Task<ActionResult<DepartmentNameDto>> Get(int id)
    {
        var DepartmentName = await _mediator.Send(new GetDepartmentNameDetailRequest { DepartmentNameId = id });
        return Ok(DepartmentName);
    }

    

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-DepartmentName")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateDepartmentNameDto DepartmentName)
    {
        var command = new CreateDepartmentNameCommand { DepartmentNameDto = DepartmentName };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-DepartmentName/{id}")]
    public async Task<ActionResult> Put([FromBody] DepartmentNameDto DepartmentName)
    {
        var command = new UpdateDepartmentNameCommand { DepartmentNameDto = DepartmentName };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-DepartmentName/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteDepartmentNameCommand { DepartmentNameId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedDepartmentNames")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedDepartmentName()
    {
        var selectedDepartmentName = await _mediator.Send(new GetSelectedDepartmentNameRequest { });
        return Ok(selectedDepartmentName);
    }
}

