using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.MaintenanceCategory;
using SchoolManagement.Application.Features.MaintenanceCategories.Requests.Commands;
using SchoolManagement.Application.Features.MaintenanceCategories.Requests.Queries;
using SchoolManagement.Application.Features.MaintenanceCategoriess.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.MaintenanceCategory)]
[ApiController]
[Authorize]
public class MaintenanceCategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public MaintenanceCategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-maintenanceCategories")]
    public async Task<ActionResult<List<MaintenanceCategoryDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var MaintenanceCategorys = await _mediator.Send(new GetMaintenanceCategoryListRequest { QueryParams = queryParams });
        return Ok(MaintenanceCategorys);
    }

    [HttpGet]
    [Route("get-maintenanceCategoryDetail/{id}")]
    public async Task<ActionResult<MaintenanceCategoryDto>> Get(int id)
    {
        var MaintenanceCategory = await _mediator.Send(new GetMaintenanceCategoryDetailRequest { MaintenanceCategoryId = id });
        return Ok(MaintenanceCategory);
    }

    

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-maintenanceCategory")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateMaintenanceCategoryDto MaintenanceCategory)
    {
        var command = new CreateMaintenanceCategoryCommand { MaintenanceCategoryDto = MaintenanceCategory };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-maintenanceCategory/{id}")]
    public async Task<ActionResult> Put([FromBody] MaintenanceCategoryDto MaintenanceCategory)
    {
        var command = new UpdateMaintenanceCategoryCommand { MaintenanceCategoryDto = MaintenanceCategory };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-maintenanceCategory/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteMaintenanceCategoryCommand { MaintenanceCategoryId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedMaintenanceCategorys")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedMaintenanceCategory()
    {
        var selectedMaintenanceCategory = await _mediator.Send(new GetSelectedMaintenanceCategoryRequest { });
        return Ok(selectedMaintenanceCategory);
    }

    [HttpGet]
    [Route("get-maintenanceCategoryByTypeAndDepartment")]

    public async Task<ActionResult> GetMaintenanceCategoryByTypeAndDepartment(int maintenanceTypeId, int departmentNameId)
    {
        var maintenanceCategory = await _mediator.Send(new GetMaintemanceCategoryTypeAndDepartmentRequest
        {
            MaintenanceTypeId = maintenanceTypeId,
            DepartmentNameId = departmentNameId
        });
        return Ok(maintenanceCategory);
    }

        [HttpGet]
        [Route("get-maintenanceCategoryByDepartment")]

        public async Task<ActionResult> GetMaintenanceCategoryByDepartmentId(int departmentNameId)
        {
            var maintenanceCategory = await _mediator.Send(new GetSelectedMaintenanceCategoryByDepartmentRequest
            {
                DepartmentNameId = departmentNameId
            });
            return Ok(maintenanceCategory);
        }
    [HttpGet]
    [Route("get-selectedCategoryByDepartmentNameIdAndMaintenanceTypeId")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedCategoryByDepartmentNameIdAndMaintenanceTypeId(int departmentNameId, int maintenanceTypeId)
    {
        var departmentbyType = await _mediator.Send(new GetMaintenanceCategoryByDepartmentNameIdAndMaintenanceTypeIdRequest 
        {
            DepartmentNameId = departmentNameId, 
            MaintenanceTypeId= maintenanceTypeId

        });
        return Ok(departmentbyType);
    }
}

