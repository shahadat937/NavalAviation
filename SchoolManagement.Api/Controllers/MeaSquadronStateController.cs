using SchoolManagement.Application;
using SchoolManagement.Application.Constants;
using SchoolManagement.Application.DTOs.MeaSquadronState;
using SchoolManagement.Application.Features.MeaSquadronStates.Requests.Commands;
using SchoolManagement.Application.Features.MeaSquadronStates.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.MeaSquadronState)]
[ApiController]
[Authorize]
public class MeaSquadronStateController : ControllerBase
{
    private readonly IMediator _mediator;

    public MeaSquadronStateController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-MeaSquadronStates")]
    public async Task<ActionResult<List<MeaSquadronStateDto>>> Get([FromQuery] QueryParams queryParams, int completeStatus)
    {
        var MeaSquadronStates = await _mediator.Send(new GetMeaSquadronStateListRequest {
          QueryParams = queryParams,
          CompleteStatus = completeStatus
        });
        return Ok(MeaSquadronStates);
    }


    [HttpGet]
    [Route("get-MeaSquadronStateDetail/{id}")]
    public async Task<ActionResult<MeaSquadronStateDto>> Get(int id)
    {
        var MeaSquadronState = await _mediator.Send(new GetMeaSquadronStateDetailRequest { MeaSquadronStateId = id });
        return Ok(MeaSquadronState);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-MeaSquadronState")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateMeaSquadronStateDto MeaSquadronState)
    {
        var command = new CreateMeaSquadronStateCommand { MeaSquadronStateDto = MeaSquadronState };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-MeaSquadronState/{id}")]
    public async Task<ActionResult> Put([FromBody] MeaSquadronStateDto MeaSquadronState)
    {
        var command = new UpdateMeaSquadronStateCommand { MeaSquadronStateDto = MeaSquadronState };
        await _mediator.Send(command);
        return NoContent();
    }
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-completedMeaSquadronState/{id}")]
    public async Task<ActionResult> UpdateCompletedMeaSquadronState([FromBody] CompletedMeaSquadronStateDto maintenanceSchedule)
    {
      var command = new CompletedMeaSquadronStateCommand { CompletedMeaSquadronStateDto = maintenanceSchedule };
      await _mediator.Send(command);
      return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-MeaSquadronState/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteMeaSquadronStateCommand { MeaSquadronStateId = id };
        await _mediator.Send(command);
        return NoContent();
    }
      [HttpGet]
      [ProducesResponseType(StatusCodes.Status204NoContent)]
      [ProducesResponseType(StatusCodes.Status404NotFound)]
      [ProducesDefaultResponseType]
      [Route("accept-meaSquadronState/{id}")]
      public async Task<ActionResult> AcceptMeaSquadronState(int id)
      {
        var command = new AcceptMeaSquadronStateCommand { MeaSquadronStateId = id };
        await _mediator.Send(command);
        return NoContent();
      }

      [HttpGet]
      [ProducesResponseType(StatusCodes.Status204NoContent)]
      [ProducesResponseType(StatusCodes.Status404NotFound)]
      [ProducesDefaultResponseType]
      [Route("cancel-meaSquadronState/{id}")]
      public async Task<ActionResult> CalcelMeaSquadronState(int id)
      {
        var command = new CancelMeaSquadronStateCommand { MeaSquadronStateId = id };
        await _mediator.Send(command);
        return NoContent();
      }

      [HttpGet]
      [Route("get-meaSquadronStateListForWorkShopByJobStatus")]
      public async Task<ActionResult<List<MeaSquadronStateDto>>> GetMeaSquadronStateListForWorkShopByJobStatusRequest([FromQuery] QueryParams queryParams)
      {
        var MeaSquadronStates = await _mediator.Send(new GetMeaSquadronStateListForWorkShopByJobStatusRequest { QueryParams = queryParams});
        return Ok(MeaSquadronStates);
      }
      [HttpGet]
      [ProducesResponseType(StatusCodes.Status204NoContent)]
      [ProducesResponseType(StatusCodes.Status404NotFound)]
      [ProducesDefaultResponseType]
      [Route("completedStatus-meaSquadronState/{id}")]
      public async Task<ActionResult> CompletedStatusMeaSquadronState(int id)
      {
        var command = new CompletedStatusMeaSquadronStateCommand { MeaSquadronStateId = id };
        await _mediator.Send(command);
        return NoContent();
      }
      [HttpGet]
      [ProducesResponseType(StatusCodes.Status204NoContent)]
      [ProducesResponseType(StatusCodes.Status404NotFound)]
      [ProducesDefaultResponseType]
      [Route("unCompletedStatus-meaSquadronState/{id}")]
      public async Task<ActionResult> UnCompletedStatusMeaSquadronState(int id)
      {
        var command = new UnCompletedStatusMeaSquadronStateCommand { MeaSquadronStateId = id };
        await _mediator.Send(command);
        return NoContent();
      }
      [HttpPut]
      [ProducesResponseType(StatusCodes.Status204NoContent)]
      [ProducesResponseType(StatusCodes.Status404NotFound)]
      [ProducesDefaultResponseType]
      [Route("update-remarksMeaSquadronState/{id}")]
      public async Task<ActionResult> UpdateRemarksMeaSquadronState([FromBody] RemarksUpdateMeaSquadronStateDto maintenanceSchedule)
      {
        var command = new RemarksUpdateMeaSquadronStateCommand { RemarksUpdateMeaSquadronStateDto = maintenanceSchedule };
        await _mediator.Send(command);
        return NoContent();
      }
}

