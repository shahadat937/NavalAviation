using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.MaintenanceType;
using SchoolManagement.Application.Features.MaintenanceTypes.Requests.Commands;
using SchoolManagement.Application.Features.MaintenanceTypes.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.MaintenanceType)]
[ApiController]
[Authorize]
public class MaintenanceTypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public MaintenanceTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-MaintenanceTypes")]
    public async Task<ActionResult<List<MaintenanceTypeDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var MaintenanceTypes = await _mediator.Send(new GetMaintenanceTypeListRequest { QueryParams = queryParams });
        return Ok(MaintenanceTypes);
    }

    [HttpGet]
    [Route("get-MaintenanceTypeDetail/{id}")]
    public async Task<ActionResult<MaintenanceTypeDto>> Get(int id)
    {
        var MaintenanceType = await _mediator.Send(new GetMaintenanceTypeDetailRequest { MaintenanceTypeId = id });
        return Ok(MaintenanceType);
    }

    

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-MaintenanceType")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateMaintenanceTypeDto MaintenanceType)
    {
        var command = new CreateMaintenanceTypeCommand { MaintenanceTypeDto = MaintenanceType };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-MaintenanceType/{id}")]
    public async Task<ActionResult> Put([FromBody] MaintenanceTypeDto MaintenanceType)
    {
        var command = new UpdateMaintenanceTypeCommand { MaintenanceTypeDto = MaintenanceType };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-MaintenanceType/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteMaintenanceTypeCommand { MaintenanceTypeId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedMaintenanceTypes")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedMaintenanceType()
    {
        var selectedMaintenanceType = await _mediator.Send(new GetSelectedMaintenanceTypeRequest { });
        return Ok(selectedMaintenanceType);
    }
    [HttpGet]
    [Route("get-selectedMaintenanceTypeByDepartmentNameId")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedMaintenanceTypeByDepartmentNameId(int departmentNameId)
    {
        var departmentbyType = await _mediator.Send(new GetMaintenanceTypeByDepartmentNameIdRequest { DepartmentNameId = departmentNameId });
        return Ok(departmentbyType);
    }
}

