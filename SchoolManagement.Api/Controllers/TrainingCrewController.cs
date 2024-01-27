using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.TrainingCrew;
using SchoolManagement.Application.Features.Acceptances.Requests.Queries;
using SchoolManagement.Application.Features.TrainingCrews.Requests.Commands;
using SchoolManagement.Application.Features.TrainingCrews.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.TrainingCrew)]
[ApiController]
[Authorize]
public class TrainingCrewController : ControllerBase
{
    private readonly IMediator _mediator;

    public TrainingCrewController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-TrainingCrews")]
    public async Task<ActionResult<List<TrainingCrewDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var TrainingCrews = await _mediator.Send(new GetTrainingCrewListRequest { QueryParams = queryParams });
        return Ok(TrainingCrews);
    }

    [HttpGet]
    [Route("get-TrainingCrewDetail/{id}")]
    public async Task<ActionResult<TrainingCrewDto>> Get(int id)
    {
        var TrainingCrew = await _mediator.Send(new GetTrainingCrewDetailRequest { TrainingCrewId = id });
        return Ok(TrainingCrew);
    }  

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-TrainingCrew")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateTrainingCrewDto TrainingCrew)
    {
        var command = new CreateTrainingCrewCommand { TrainingCrewDto = TrainingCrew };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-TrainingCrew/{id}")]
    public async Task<ActionResult> Put([FromBody] TrainingCrewDto TrainingCrew)
    {
        var command = new UpdateTrainingCrewCommand { TrainingCrewDto = TrainingCrew };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-TrainingCrew/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteTrainingCrewCommand { TrainingCrewId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedTrainingCrews")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedTrainingCrew()
    {
        var selectedTrainingCrew = await _mediator.Send(new GetSelectedTrainingCrewRequest { });
        return Ok(selectedTrainingCrew);
    }
    [HttpGet]
    [Route("get-TrainingCrewListByDepartmentNameId")]
    public async Task<ActionResult> GetTrainingCrewListByDepartmentNameId(string text, int departmentNameId,int employeeTypeId)
    {
        var trainingCrew = await _mediator.Send(new GetTrainingCrewListByDepartmentNameIdRequest
        {
            Text = text,
            DepartmentNameId = departmentNameId,
            EmployeeTypeId = employeeTypeId
        });
        return Ok(trainingCrew);
    }

    [HttpGet]
    [Route("get-TrainingCrewListByDepartmentNameIdForSailor")]
    public async Task<ActionResult> GetTrainingCrewListByDepartmentNameIdSailor(string text,int departmentNameId, int employeeTypeId)
    {
      var trainingCrew = await _mediator.Send(new GetTrainingCrewListByDepartmentNameIdSailorRequest
      {
        Text = text,
        DepartmentNameId = departmentNameId,
        EmployeeTypeId = employeeTypeId
      });
      return Ok(trainingCrew);
    }

  [HttpGet]
    [Route("change-OfficerStatus")]
    public async Task<ActionResult> ChangeOfficerStatus(int trainingCrewId, int officerStatusId)
    {
      var trainingCrew = await _mediator.Send(new ChangeTrainingCrewStatusCommand
      {
        TrainingCrewId = trainingCrewId,
        OfficerStatusId = officerStatusId
      });
      return Ok(trainingCrew);
    }
    [HttpGet]
    [Route("get-autocompletePnoForIssueRegister")]
    public async Task<ActionResult<List<SelectedModel>>> GetAutoCompletePnoForIssueRegister(string pno)
    {
        var trainee = await _mediator.Send(new GetAutoCompletePnoForIssueRegisterRequest
        {
            Pno = pno,
        });
        return Ok(trainee);
    }

    [HttpGet]
    [Route("get-TrainingCrewPresentListByDepartmentNameId")]
    public async Task<ActionResult> GetTrainingCrewPresentListByDepartmentNameId(int departmentNameId, int officerStatusId)
    {
      var trainingCrew = await _mediator.Send(new GetTrainingCrewPresentListByDepartmentNameIdRequest
      {
        DepartmentNameId = departmentNameId,
        OfficersStatusId = officerStatusId
      });
      return Ok(trainingCrew);
    }
    
}

