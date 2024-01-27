using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.Attendence;
using SchoolManagement.Application.Features.Attendences.Requests.Commands;
using SchoolManagement.Application.Features.Attendences.Requests.Queries;
using SchoolManagement.Application.Features.TrainingCrews.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.Attendence)]
[ApiController]
[Authorize]
public class AttendenceController : ControllerBase
{
    private readonly IMediator _mediator;

    public AttendenceController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-Attendences")]
    public async Task<ActionResult<List<AttendenceDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var Attendences = await _mediator.Send(new GetAttendenceListRequest { QueryParams = queryParams });
        return Ok(Attendences);
    }

    [HttpGet]
    [Route("get-AttendenceDetail/{id}")]
    public async Task<ActionResult<AttendenceDto>> Get(int id)
    {
        var Attendence = await _mediator.Send(new GetAttendenceDetailRequest { AttendenceId = id });
        return Ok(Attendence);
    }

    

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-Attendence")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateAttendanceListDto createAttendanceList)
    {
        var command = new CreateAttendenceCommand { AttendenceDto = createAttendanceList };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-Attendence/{id}")]
    public async Task<ActionResult> Put([FromBody] AttendenceDto Attendence)
    {
        var command = new UpdateAttendenceCommand { AttendenceDto = Attendence };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-Attendence/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteAttendenceCommand { AttendenceId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedAttendences")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedAttendence()
    {
        var selectedAttendence = await _mediator.Send(new GetSelectedAttendenceRequest { });
        return Ok(selectedAttendence);
    }

    [HttpGet]
    [Route("get-atendanceListByDepartmentNameIdandDate")]
    public async Task<ActionResult> GetNominatedTraineeCountByDurationId(DateTime date, int departmentNameId, int officerStatusId, string searchText)
    {
    var CourseTrainee = await _mediator.Send(new GetAttendanceListByDepartmentandDateSpRequest
      {
        AttendanceDate = date,
        DepartmentId =departmentNameId,
        OfficerStatusId = officerStatusId,
        SearchText = searchText
      });
      return Ok(CourseTrainee);
    }
}

