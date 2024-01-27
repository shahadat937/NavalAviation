using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.DailyAirworthinessFrom;
using SchoolManagement.Application.Features.DailyAirworthinessFroms.Requests.Commands;
using SchoolManagement.Application.Features.DailyAirworthinessFroms.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.DailyAirworthinessFrom)]
[ApiController]
[Authorize]
public class DailyAirworthinessFromController : ControllerBase
{
    private readonly IMediator _mediator;

    public DailyAirworthinessFromController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-DailyAirworthinessFroms")]
    public async Task<ActionResult<List<DailyAirworthinessFromDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var DailyAirworthinessFroms = await _mediator.Send(new GetDailyAirworthinessFromListRequest { QueryParams = queryParams });
        return Ok(DailyAirworthinessFroms);
    }

    [HttpGet]
    [Route("get-DailyAirworthinessFromDetail/{id}")]
    public async Task<ActionResult<DailyAirworthinessFromDto>> Get(int id)
    {
        var DailyAirworthinessFrom = await _mediator.Send(new GetDailyAirworthinessFromDetailRequest { DailyAirworthinessFromId = id });
        return Ok(DailyAirworthinessFrom);
    }

    

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-DailyAirworthinessFrom")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromForm] CreateDailyAirworthinessFromDto DailyAirworthinessFrom)
    {
        var command = new CreateDailyAirworthinessFromCommand { DailyAirworthinessFromDto = DailyAirworthinessFrom };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-DailyAirworthinessFrom/{id}")]
    public async Task<ActionResult> Put([FromForm] CreateDailyAirworthinessFromDto DailyAirworthinessFrom)
    {
        var command = new UpdateDailyAirworthinessFromCommand { UpdateDailyAirworthinessFromDto = DailyAirworthinessFrom };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-DailyAirworthinessFrom/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteDailyAirworthinessFromCommand { DailyAirworthinessFromId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedDailyAirworthinessFroms")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedDailyAirworthinessFrom()
    {
        var selectedDailyAirworthinessFrom = await _mediator.Send(new GetSelectedDailyAirworthinessFromRequest { });
        return Ok(selectedDailyAirworthinessFrom);
    }
  [HttpGet]
      [Route("get-dailyAirworthinessFromListByDepartmentNameId")]
      public async Task<ActionResult> GetDailyAirworthinessFromListByDepartmentNameId(int departmentNameId, int docType)
      {
        var equipmentName = await _mediator.Send(new GetDailyAirworthinessFromListByDepartmentNameIdRequest
        {
          DepartmentNameId = departmentNameId,
          DocType = docType
        });
        return Ok(equipmentName);
      }
}

