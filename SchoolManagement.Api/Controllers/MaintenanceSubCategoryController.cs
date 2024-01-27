using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.MaintenanceSubCategory;
using SchoolManagement.Application.Features.MaintenanceSubCategorys.Requests.Commands;
using SchoolManagement.Application.Features.MaintenanceSubCategorys.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.MaintenanceSubCategory)]
[ApiController]
[Authorize]
public class MaintenanceSubCategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public MaintenanceSubCategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-MaintenanceSubCategorys")]
    public async Task<ActionResult<List<MaintenanceSubCategoryDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var MaintenanceSubCategorys = await _mediator.Send(new GetMaintenanceSubCategoryListRequest { QueryParams = queryParams });
        return Ok(MaintenanceSubCategorys);
    }

    [HttpGet]
    [Route("get-MaintenanceSubCategoryDetail/{id}")]
    public async Task<ActionResult<MaintenanceSubCategoryDto>> Get(int id)
    {
        var MaintenanceSubCategory = await _mediator.Send(new GetMaintenanceSubCategoryDetailRequest { MaintenanceSubCategoryId = id });
        return Ok(MaintenanceSubCategory);
    }

    

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-MaintenanceSubCategory")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateMaintenanceSubCategoryDto MaintenanceSubCategory)
    {
        var command = new CreateMaintenanceSubCategoryCommand { MaintenanceSubCategoryDto = MaintenanceSubCategory };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-MaintenanceSubCategory/{id}")]
    public async Task<ActionResult> Put([FromBody] MaintenanceSubCategoryDto MaintenanceSubCategory)
    {
        var command = new UpdateMaintenanceSubCategoryCommand { MaintenanceSubCategoryDto = MaintenanceSubCategory };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-MaintenanceSubCategory/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteMaintenanceSubCategoryCommand { MaintenanceSubCategoryId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get  GetMaintemanceSubCategoryByIdAndDepartmentIdRequest

    [HttpGet]
    [Route("get-selectedMaintenanceSubCategorys")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedMaintenanceSubCategory()
    {
        var selectedMaintenanceSubCategory = await _mediator.Send(new GetSelectedMaintenanceSubCategoryRequest { });
        return Ok(selectedMaintenanceSubCategory);
    }

    [HttpGet]
    [Route("get-selectedMaintenanceSubCategorysByIdAndDepartmentId")]
    public async Task<ActionResult<List<MaintenanceSubCategoryDto>>> selectedMaintenanceSubCategorysByIdAndDepartmentId(int departmentNameId,int maintenanceCategoryId)
    {
        var selectedMaintenanceSubCategory = await _mediator.Send(new GetMaintemanceSubCategoryByIdAndDepartmentIdRequest 
        { 
          DepartmentNameId=departmentNameId,
          MaintenanceCategoryId = maintenanceCategoryId
        });
        return Ok(selectedMaintenanceSubCategory);
    }
    [HttpGet]
    [Route("get-selectedSubCategoryByDepartmentNameIdAndMaintenanceCategoryId")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedSubCategoryByDepartmentNameIdAndMaintenanceCategoryId(int maintenanceCategoryId)
    {
        var departmentbyType = await _mediator.Send(new GetMaintenanceSubCategoryByDepartmentNameIdAndMaintenanceCategoryIdRequest
        {   //DepartmentNameId = departmentNameId, 
            MaintenanceCategoryId = maintenanceCategoryId

        });
        return Ok(departmentbyType);
    }
    [HttpGet]
    [Route("get-selectedAllowedExtensionBySubCategoryId")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedAllowedExtensionBySubCategoryId(int maintenanceSubCategoryId)
    {
        var currencyByCountry = await _mediator.Send(new GetSelectedAllowedExtensionBySubCategoryIdRequest 
        { 
            MaintenanceSubCategoryId = maintenanceSubCategoryId 
        });
        return Ok(currencyByCountry);
    }
    [HttpGet]
    [Route("get-selectedAllowedExtensionBySubCategoryIdDepartmentIdAndCategoryId")]
    public async Task<ActionResult<object>> GetSelectedAllowedExtensionBySubCategoryIdDepartmentIdAndCategoryId(int departmentNameId, int maintenanceCategoryId, int maintenanceSubCategoryId)
    {
        var bnaSubjectNames = await _mediator.Send(new GetSelectedAllowedExtensionBySubCategoryIdDepartmentIdAndCategoryIdRequest
        {
            DepartmentNameId = departmentNameId,
            MaintenanceCategoryId = maintenanceCategoryId,
            MaintenanceSubCategoryId= maintenanceSubCategoryId
        });
        return Ok(bnaSubjectNames);
    }
    [HttpGet]
    [Route("get-selectedMaintenanceSubCategoryByDepartmentId")]
    public async Task<ActionResult<List<MaintenanceSubCategoryDto>>> selectedMaintenanceSubCategoryByDepartmentId(int departmentNameId)
    {
      var selectedMaintenanceSubCategory = await _mediator.Send(new GetSelectedMaintenanceSubCategoryByDepartmentIdRequest
      {
        DepartmentNameId = departmentNameId
      });
      return Ok(selectedMaintenanceSubCategory);
    }
}

