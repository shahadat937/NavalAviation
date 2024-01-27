using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.AirCraftFlying;
using SchoolManagement.Application.Features.AirCraftFlyings.Requests.Commands;
using SchoolManagement.Application.Features.AirCraftFlyings.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.AirCraftFlying)]
[ApiController]
[Authorize]
public class AirCraftFlyingController : ControllerBase
{
    private readonly IMediator _mediator;

    public AirCraftFlyingController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-AirCraftFlyings")]
    public async Task<ActionResult<List<AirCraftFlyingDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var AirCraftFlyings = await _mediator.Send(new GetAirCraftFlyingListRequest { QueryParams = queryParams });
        return Ok(AirCraftFlyings);
    }

    [HttpGet]
    [Route("get-AirCraftFlyingDetail/{id}")]
    public async Task<ActionResult<AirCraftFlyingDto>> Get(int id)
    {
        var AirCraftFlying = await _mediator.Send(new GetAirCraftFlyingDetailRequest { AirCraftFlyingId = id });
        return Ok(AirCraftFlying);
    }

    

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-AirCraftFlying")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateAirCraftFlyingDto AirCraftFlying)
    {
        var command = new CreateAirCraftFlyingCommand { AirCraftFlyingDto = AirCraftFlying };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-AirCraftFlying/{id}")]
    public async Task<ActionResult> Put([FromBody] AirCraftFlyingDto AirCraftFlying)
    {
        var command = new UpdateAirCraftFlyingCommand { AirCraftFlyingDto = AirCraftFlying };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-aircraftflyingdelay/{id}")] 
    public async Task<ActionResult> UpdateAircraftFlyingDelay([FromBody] AirCraftFlyingDelayDto AirCraftFlying)
    {
      var command = new UpdateAirCraftFlyingDelayCommand { AirCraftFlyingDto = AirCraftFlying };
      await _mediator.Send(command);
      return NoContent();
    }

  [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-AirCraftFlying/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteAirCraftFlyingCommand { AirCraftFlyingId = id };
        await _mediator.Send(command);
        return NoContent();
    }
    [HttpGet]
    [Route("get-AirCraftFlyingListByDepartmentNameId")]
    public async Task<ActionResult> GetAirCraftFlyingListByDepartmentNameId(int departmentNameId, int airCraftNameId)
    {
        var trainingCrew = await _mediator.Send(new GetAirCraftFlyingListByDepartmentNameIdRequest
        {
            DepartmentNameId = departmentNameId,
            AirCraftNameId = airCraftNameId
        });
        return Ok(trainingCrew);
    }

}

