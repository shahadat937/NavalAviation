using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.DailyAirworthinessFromCategory;
using SchoolManagement.Application.Features.DailyAirworthinessFromCategorys.Requests.Commands;
using SchoolManagement.Application.Features.DailyAirworthinessFromCategorys.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.DailyAirworthinessFromCategory)]
[ApiController]
[Authorize]
public class DailyAirworthinessFromCategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public DailyAirworthinessFromCategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-DailyAirworthinessFromCategories")]
    public async Task<ActionResult<List<DailyAirworthinessFromCategoryDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var DailyAirworthinessFromCategorys = await _mediator.Send(new GetDailyAirworthinessFromCategoryListRequest { QueryParams = queryParams });
        return Ok(DailyAirworthinessFromCategorys);
    }

    [HttpGet]
    [Route("get-DailyAirworthinessFromCategoryDetail/{id}")]
    public async Task<ActionResult<DailyAirworthinessFromCategoryDto>> Get(int id)
    {
        var DailyAirworthinessFromCategory = await _mediator.Send(new GetDailyAirworthinessFromCategoryDetailRequest { DailyAirworthinessFromCategoryId = id });
        return Ok(DailyAirworthinessFromCategory);
    }

    

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-DailyAirworthinessFromCategory")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateDailyAirworthinessFromCategoryDto DailyAirworthinessFromCategory)
    {
        var command = new CreateDailyAirworthinessFromCategoryCommand { DailyAirworthinessFromCategoryDto = DailyAirworthinessFromCategory };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-DailyAirworthinessFromCategory/{id}")]
    public async Task<ActionResult> Put([FromBody] DailyAirworthinessFromCategoryDto DailyAirworthinessFromCategory)
    {
        var command = new UpdateDailyAirworthinessFromCategoryCommand { DailyAirworthinessFromCategoryDto = DailyAirworthinessFromCategory };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-DailyAirworthinessFromCategory/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteDailyAirworthinessFromCategoryCommand { DailyAirworthinessFromCategoryId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedDailyAirworthinessFromCategories")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedDailyAirworthinessFromCategory()
    {
        var selectedDailyAirworthinessFromCategory = await _mediator.Send(new GetSelectedDailyAirworthinessFromCategoryRequest { });
        return Ok(selectedDailyAirworthinessFromCategory);
    }
      [HttpGet]
      [Route("get-dailyAirworthinessFromListByDepartmentNameId")]
      public async Task<ActionResult> GetDailyAirworthinessFromListByDepartmentNameId(int departmentNameId)
      {
        var equipmentName = await _mediator.Send(new GetDailyAirworthinessFromCategoryListByDepartmentNameIdRequest
        {
          DepartmentNameId = departmentNameId
        });
        return Ok(equipmentName);
      }
}

