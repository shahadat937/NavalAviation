using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.CallibrationState;
using SchoolManagement.Application.Features.CallibrationStates.Requests.Commands;
using SchoolManagement.Application.Features.CallibrationStates.Requests.Queries;
using SchoolManagement.Application.Features.ItemStors.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.CallibrationState)]
[ApiController]
[Authorize]
public class CallibrationStateController : ControllerBase
{
    private readonly IMediator _mediator;

    public CallibrationStateController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-CallibrationStates")]
    public async Task<ActionResult<List<CallibrationStateDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var CallibrationStates = await _mediator.Send(new GetCallibrationStateListRequest { QueryParams = queryParams });
        return Ok(CallibrationStates);
    }


    [HttpGet]
    [Route("get-CallibrationStateDetail/{id}")]
    public async Task<ActionResult<CallibrationStateDto>> Get(int id)
    {
        var CallibrationState = await _mediator.Send(new GetCallibrationStateDetailRequest { CallibrationStateId = id });
        return Ok(CallibrationState);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-CallibrationState")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateCallibrationStateDto CallibrationState)
    {
        var command = new CreateCallibrationStateCommand { CallibrationStateDto = CallibrationState };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpGet]
    [Route("get-calibrationStateForToolsSpRequest")]
    public async Task<ActionResult> GetCalibrationStateForTools(int departmentNameId)
    {
        var calibrationState = await _mediator.Send(new GetCalibrationStateForToolsSpRequest
        {
          DepartmentNameId = departmentNameId,
         // SearchText = searchText
        });
        return Ok(calibrationState);
    }

    [HttpGet]
    [Route("get-calibrationStateListForToolsSpRequest")]
    public async Task<ActionResult> GetCalibrationStateListForTools(int departmentNameId,string searchText)
    {
      var calibrationState = await _mediator.Send(new GetCalibrationStateListForToolsSpRequest
      {
        DepartmentNameId = departmentNameId,
        SearchText =searchText
      });
      return Ok(calibrationState);
    }


  [HttpGet]
    [Route("get-calibrationStateForSpareSpRequest")]
    public async Task<ActionResult> GetCalibrationStateForSpares(int departmentNameId)
    {
      var calibrationState = await _mediator.Send(new GetCalibrationStateForSpareSpRequest
      {
        DepartmentNameId = departmentNameId
      });
      return Ok(calibrationState);
    }

  [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-CallibrationState/{id}")]
    public async Task<ActionResult> Put([FromBody] CallibrationStateDto CallibrationState)
    {
        var command = new UpdateCallibrationStateCommand { CallibrationStateDto = CallibrationState };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-CallibrationState/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteCallibrationStateCommand { CallibrationStateId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    
}

