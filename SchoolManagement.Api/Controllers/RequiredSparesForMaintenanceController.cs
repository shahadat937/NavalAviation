using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.RequiredSparesForMaintenance;
using SchoolManagement.Application.Features.RequiredSparesForMaintenances.Requests.Commands;
using SchoolManagement.Application.Features.RequiredSparesForMaintenances.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.RequiredSparesForMaintenance)]
[ApiController]
[Authorize]
public class RequiredSparesForMaintenanceController : ControllerBase
{
    private readonly IMediator _mediator;

    public RequiredSparesForMaintenanceController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-RequiredSparesForMaintenances")]
    public async Task<ActionResult<List<RequiredSparesForMaintenanceDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var RequiredSparesForMaintenances = await _mediator.Send(new GetRequiredSparesForMaintenanceListRequest { QueryParams = queryParams });
        return Ok(RequiredSparesForMaintenances);
    }

    [HttpGet]
    [Route("get-RequiredSparesForMaintenanceDetail/{id}")]
    public async Task<ActionResult<RequiredSparesForMaintenanceDto>> Get(int id)
    {
        var RequiredSparesForMaintenance = await _mediator.Send(new GetRequiredSparesForMaintenanceDetailRequest { RequiredSparesForMaintenanceId = id });
        return Ok(RequiredSparesForMaintenance);
    }

    

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-RequiredSparesForMaintenance")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateRequiredSparesForMaintenanceDto RequiredSparesForMaintenance)
    {
        var command = new CreateRequiredSparesForMaintenanceCommand { RequiredSparesForMaintenanceDto = RequiredSparesForMaintenance };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-RequiredSparesForMaintenance/{id}")]
    public async Task<ActionResult> Put([FromBody] RequiredSparesForMaintenanceDto RequiredSparesForMaintenance)
    {
        var command = new UpdateRequiredSparesForMaintenanceCommand { RequiredSparesForMaintenanceDto = RequiredSparesForMaintenance };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-RequiredSparesForMaintenance/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteRequiredSparesForMaintenanceCommand { RequiredSparesForMaintenanceId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedRequiredSparesForMaintenances")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedRequiredSparesForMaintenance()
    {
        var selectedRequiredSparesForMaintenance = await _mediator.Send(new GetSelectedRequiredSparesForMaintenanceRequest { });
        return Ok(selectedRequiredSparesForMaintenance);
    }
    [HttpGet]
    [Route("get-RequiredSparesForMaintenanceListByDepartmentNameId")]
    public async Task<ActionResult> GetEquipmentNameListByDepartmentNameId(int departmentNameId)
    {
      var equipmentName = await _mediator.Send(new GetRequiredSparesForMaintenanceListByDepartmentNameIdRequest
      {
        DepartmentNameId = departmentNameId
      });
      return Ok(equipmentName);
    }
    [HttpGet]
    [Route("get-presentStocksForMaintenance")]
    public async Task<ActionResult> GetPresentStocksForMaintenance(int departmentId, int sparesCategoryId,int maintenanceTypeId, int maintenanceCategoryId, int maintenanceSubCategoryId)
    {
      var presentStocks = await _mediator.Send(new GetPresentStockForMaintenanceSpRequest
      {
        DepartmentId = departmentId,
        SparesCategoryId = sparesCategoryId,
        MaintenanceTypeId = maintenanceTypeId,
        MaintenanceCategoryId = maintenanceCategoryId,
        MaintenanceSubCategoryId = maintenanceSubCategoryId
      });
      return Ok(presentStocks);
    }

    [HttpGet]
    [Route("get-presentNsdStocksForMaintenance")]
    public async Task<ActionResult> GetPresentNsdStocksForMaintenance(int itemDetailId, int toolsLocationId)
    {
      var presentStocks = await _mediator.Send(new GetNsdPresentStockForMaintenanceSpRequest
      {
        ItemDetailId = itemDetailId,
        ToolsLocationId = toolsLocationId
      });
      return Ok(presentStocks);
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("approved-requiredSparesForMaintenance/{id}")]
    public async Task<ActionResult> ApprovedRequiredSparesForMaintenance(int id)
    {
      var command = new ApprovedRequiredSparesForMaintenanceCommand { RequiredSparesForMaintenanceId = id };
      await _mediator.Send(command);
      return NoContent();
    }
}

