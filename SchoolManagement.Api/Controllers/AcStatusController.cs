using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.AcStatus;
using SchoolManagement.Application.Features.AcStatuses.Requests.Commands;
using SchoolManagement.Application.Features.AcStatuses.Requests.Queries;
using SchoolManagement.Application.Features.RunningHours.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.AcStatus)]
[ApiController]
[Authorize]
public class AcStatusController : ControllerBase
{
    private readonly IMediator _mediator;

    public AcStatusController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-acStatuses")]
    public async Task<ActionResult<List<AcStatusDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var AcStatuss = await _mediator.Send(new GetAcStatusListRequest { QueryParams = queryParams });
        return Ok(AcStatuss);
    }


    [HttpGet]
    [Route("get-acStatusDetail/{id}")]
    public async Task<ActionResult<AcStatusDto>> Get(int id)
    {
        var AcStatus = await _mediator.Send(new GetAcStatusDetailRequest { AcStatusId = id });
        return Ok(AcStatus);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-acStatus")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateAcStatusDto AcStatus)
    {
        var command = new CreateAcStatusCommand { AcStatusDto = AcStatus };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-acStatus/{id}")]
    public async Task<ActionResult> Put([FromBody] AcStatusDto AcStatus)
    {
        var command = new UpdateAcStatusCommand { AcStatusDto = AcStatus };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-acStatus/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteAcStatusCommand { AcStatusId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedAcStatus")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedAcStatus()
    {
        var AcStatus = await _mediator.Send(new GetSelectedAcStatusRequest { });
        return Ok(AcStatus);
    }

  [HttpGet]
  [Route("get-AcStatusListByDepartmentId")]

  public async Task<ActionResult> GetAcStatusListByDepartmentId(int departmentNameId)
  {
    var trainingCrew = await _mediator.Send(new GetAcStatusListByDepartmentIdRequest
    {
      DepartmentNameId = departmentNameId
    });
    return Ok(trainingCrew);
  }
}

