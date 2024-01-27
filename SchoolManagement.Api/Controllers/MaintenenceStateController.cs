using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.MaintenenceState;
using SchoolManagement.Application.Features.MaintenenceStates.Requests.Commands;
using SchoolManagement.Application.Features.MaintenenceStates.Requests.Queries;
using SchoolManagement.Application.Features.ItemStors.Requests.Queries;
using SchoolManagement.Shared.Models;
using SchoolManagement.Application.Features.MaintainenceStates.Requests.Queries;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.MaintenenceState)]
[ApiController]
[Authorize]
public class MaintenenceStateController : ControllerBase
{
    private readonly IMediator _mediator;

    public MaintenenceStateController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-maintenenceStates")]
    public async Task<ActionResult<List<MaintenenceStateDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var MaintenenceStates = await _mediator.Send(new GetMaintenenceStateListRequest { QueryParams = queryParams });
        return Ok(MaintenenceStates);
    }


    [HttpGet]
    [Route("get-maintenenceStateDetail/{id}")]
    public async Task<ActionResult<MaintenenceStateDto>> Get(int id)
    {
        var MaintenenceState = await _mediator.Send(new GetMaintenenceStateDetailRequest { MaintenenceStateId = id });
        return Ok(MaintenenceState);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-maintenenceState")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateMaintenenceStateDto MaintenenceState)
    {
        var command = new CreateMaintenenceStateCommand { MaintenenceStateDto = MaintenenceState };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpGet]
    [Route("get-maintenenceStateForToolsSpRequest")]
    public async Task<ActionResult> GetMaintenenceStateForTools(int departmentNameId)
    {
        var MaintenenceState = await _mediator.Send(new GetMaintenenceStateForToolsSpRequest
        {
          DepartmentNameId = departmentNameId
        });
        return Ok(MaintenenceState);
    }
   
    [HttpGet]
    [Route("get-maintenenceStateForSpareSpRequest")]
    public async Task<ActionResult> GetMaintenenceStateForSpares(int departmentNameId)
    {
      var MaintenenceState = await _mediator.Send(new GetMaintenenceStateForSpareSpRequest
      {
        DepartmentNameId = departmentNameId
      });
      return Ok(MaintenenceState);
    }

    [HttpGet]
    [Route("get-maintenenceStateListForSpareSpRequest")]
    public async Task<ActionResult> GetMaintenenceStateListForSpare(int departmentNameId)
    {
      var MaintenenceState = await _mediator.Send(new GetMaintenenceStateListForSpareSpRequest
      {
        DepartmentNameId = departmentNameId
      }); 
      return Ok(MaintenenceState);
    }

    [HttpGet] 
    [Route("get-maintenenceStateListForSearch")]
    public async Task<ActionResult> GetMaintenenceStateListForSearch(int departmentNameId,string searchText)
    {
      var MaintenenceState = await _mediator.Send(new GetMaintenenceStateLisBySearchTextRequest
      {
        DepartmentNameId =departmentNameId,
        SearchText = searchText
      });
      return Ok(MaintenenceState);
    }

  [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-maintenenceState/{id}")]
    public async Task<ActionResult> Put([FromBody] MaintenenceStateDto MaintenenceState)
    {
        var command = new UpdateMaintenenceStateCommand { MaintenenceStateDto = MaintenenceState };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-maintenenceState/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteMaintenenceStateCommand { MaintenenceStateId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    
}

