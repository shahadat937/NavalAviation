using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.MaintenancePlanning;
using SchoolManagement.Application.Features.MaintenancePlannings.Requests.Commands;
using SchoolManagement.Application.Features.MaintenancePlannings.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.MaintenancePlanning)]
[ApiController]
[Authorize]
public class MaintenancePlanningController : ControllerBase
{
    private readonly IMediator _mediator;

    public MaintenancePlanningController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-MaintenancePlannings")]
    public async Task<ActionResult<List<MaintenancePlanningDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var MaintenancePlannings = await _mediator.Send(new GetMaintenancePlanningListRequest { QueryParams = queryParams });
        return Ok(MaintenancePlannings);
    }

    [HttpGet]
    [Route("get-MaintenancePlanningDetail/{id}")]
    public async Task<ActionResult<MaintenancePlanningDto>> Get(int id)
    {
        var MaintenancePlanning = await _mediator.Send(new GetMaintenancePlanningDetailRequest { MaintenancePlanningId = id });
        return Ok(MaintenancePlanning);
    }

    

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-MaintenancePlanning")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromForm] CreateMaintenancePlanningDto MaintenancePlanning)
    {
        var command = new CreateMaintenancePlanningCommand { MaintenancePlanningDto = MaintenancePlanning };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-MaintenancePlanning/{id}")]
    public async Task<ActionResult> Put([FromForm] CreateMaintenancePlanningDto MaintenancePlanning)
    {
        var command = new UpdateMaintenancePlanningCommand { UpdateMaintenancePlanningDto = MaintenancePlanning };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-MaintenancePlanning/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteMaintenancePlanningCommand { MaintenancePlanningId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedMaintenancePlannings")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedMaintenancePlanning()
    {
        var selectedMaintenancePlanning = await _mediator.Send(new GetSelectedMaintenancePlanningRequest { });
        return Ok(selectedMaintenancePlanning);
    }
    [HttpGet]
    [Route("get-maintemancePlanningListByDepartmentAndAirCraftName")]

    public async Task<ActionResult> GetMaintemancePlanningListByDepartmentAndAirCraftName(int airCraftNameId, int departmentNameId)
    {
        var maintenancePlanning = await _mediator.Send(new GetMaintemancePlanningListByDepartmentAndAirCraftNameRequest
        {
            AirCraftNameId = airCraftNameId,
            DepartmentNameId = departmentNameId
        });
        return Ok(maintenancePlanning);
    }
    [HttpGet]
    [Route("get-maintemancePlanningListByDepartmentAndAirCraftNameAndType")]

    public async Task<ActionResult> GetMaintemancePlanningListByDepartmentAndAirCraftNameAndType(int maintenanceTypeId, int airCraftNameId, int departmentNameId)
    {
        var maintenancePlanning = await _mediator.Send(new GetMaintemancePlanningListByDepartmentAndAirCraftNameAndTypeRequest
        {
            MaintenanceTypeId= maintenanceTypeId,
            AirCraftNameId = airCraftNameId,
            DepartmentNameId = departmentNameId
        });
        return Ok(maintenancePlanning);
    }
    [HttpGet]
    [Route("get-maintemancePlanningListByDepartmentAndAirCraftNameAndTypeAndCategory")]

    public async Task<ActionResult> GetMaintemancePlanningListByDepartmentAndAirCraftNameAndTypeAndCategory(int maintenanceCategoryId, int maintenanceTypeId, int airCraftNameId, int departmentNameId)
    {
        var maintenancePlanning = await _mediator.Send(new GetMaintemancePlanningListByDepartmentAndAirCraftNameAndTypeAndCategoryRequest
        {
            MaintenanceCategoryId= maintenanceCategoryId,
            MaintenanceTypeId = maintenanceTypeId,
            AirCraftNameId = airCraftNameId,
            DepartmentNameId = departmentNameId
        });
        return Ok(maintenancePlanning);
    }
    [HttpGet]
    [Route("get-maintemancePlanningListByDepartmentAndAirCraftNameAndTypeAndCategoryAndSubCategory")]

    public async Task<ActionResult> GetMaintemancePlanningListByDepartmentAndAirCraftNameAndTypeAndCategoryAndSubCategory(int maintenanceSubCategoryId, int maintenanceCategoryId, int maintenanceTypeId, int airCraftNameId, int departmentNameId)
    {
        var maintenancePlanning = await _mediator.Send(new GetMaintemancePlanningListByDepartmentAndAirCraftNameAndTypeAndCategoryAndSubCategoryRequest
        {
            MaintenanceSubCategoryId= maintenanceSubCategoryId,
            MaintenanceCategoryId = maintenanceCategoryId,
            MaintenanceTypeId = maintenanceTypeId,
            AirCraftNameId = airCraftNameId,
            DepartmentNameId = departmentNameId
        });
        return Ok(maintenancePlanning);
    }
    [HttpGet]
    [Route("get-selectedAllowedNestInspDateByMaintenancePlanningId")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedAllowedNestInspDateByMaintenancePlanningId(int maintenancePlanningId)
    {
        var allowedNestInspDateByMaintenancePlanning = await _mediator.Send(new GetAllowedNestInspDateByMaintenancePlanningIdRequest { MaintenancePlanningId = maintenancePlanningId });
        return Ok(allowedNestInspDateByMaintenancePlanning);
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("approved-maintenancePlanning/{id}")]
    public async Task<ActionResult> ApprovedMaintenancePlanning(int id)
    {
      var command = new ApprovedMaintenancePlanningCommand { MaintenancePlanningId = id };
      await _mediator.Send(command);
      return NoContent();
    }
  [HttpGet]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesDefaultResponseType]
  [Route("completeStatus-maintenancePlanning/{id}")]
  public async Task<ActionResult> CompleteStatusMaintenancePlanning(int id)
  {
    var command = new CompleteStatusMaintenancePlanningCommand { MaintenancePlanningId = id };
    await _mediator.Send(command);
    return NoContent();
  }
}

