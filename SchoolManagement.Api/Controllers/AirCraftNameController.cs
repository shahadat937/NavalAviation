using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.AirCraftName;
using SchoolManagement.Application.Features.AirCraftNames.Requests.Commands;
using SchoolManagement.Application.Features.AirCraftNames.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.AirCraftName)]
[ApiController]
[Authorize]
public class AirCraftNameController : ControllerBase
{
    private readonly IMediator _mediator;

    public AirCraftNameController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-AirCraftNames")]
    public async Task<ActionResult<List<AirCraftNameDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var AirCraftNames = await _mediator.Send(new GetAirCraftNameListRequest { QueryParams = queryParams });
        return Ok(AirCraftNames);
    }

    [HttpGet]
    [Route("get-AirCraftNameDetail/{id}")]
    public async Task<ActionResult<AirCraftNameDto>> Get(int id)
    {
        var AirCraftName = await _mediator.Send(new GetAirCraftNameDetailRequest { AirCraftNameId = id });
        return Ok(AirCraftName);
    }

    

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-AirCraftName")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromForm] CreateAirCraftNameDto airCraftName)
    {
        var command = new CreateAirCraftNameCommand { AirCraftNameDto = airCraftName };
        var response = await _mediator.Send(command);
        return Ok(response); 
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-AirCraftName/{id}")]
    public async Task<ActionResult> Put([FromForm] CreateAirCraftNameDto createAirCraftName)
    {
        var command = new UpdateAirCraftNameCommand { CreateAirCraftNameDto = createAirCraftName };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-AirCraftName/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteAirCraftNameCommand { AirCraftNameId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedAirCraftNames")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedAirCraftName()
    {
        var selectedAirCraftName = await _mediator.Send(new GetSelectedAirCraftNameRequest { });
        return Ok(selectedAirCraftName);
    }
    [HttpGet]
    [Route("get-selectedAirCraftNameByDepartmentNameId")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedAirCraftNameByDepartmentNameId(int departmentNameId)
    {
        var departmentbyAirCraftName = await _mediator.Send(new GetAirCraftNameByDepartmentNameIdRequest { DepartmentNameId = departmentNameId });
        return Ok(departmentbyAirCraftName);
    }
    [HttpGet]
    [Route("get-selectedAirCraftNameByDepartmentId")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedAirCraftNameByDepartmentId(int departmentNameId)
    {
        var airCraftNameByDepartment = await _mediator.Send(new GetAirCraftNameByDepartmentIdRequest { DepartmentNameId = departmentNameId });
        return Ok(airCraftNameByDepartment);
    }
    [HttpGet]
    [Route("get-selectedAirCraftNameByDepartmentIdForStatus")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedAirCraftNameByDepartmentIdForStatus(int departmentNameId)
    {
        var airCraftNameByDepartment = await _mediator.Send(new GetAirCraftNameByDepartmentIdForStatusRequest { DepartmentNameId = departmentNameId });
        return Ok(airCraftNameByDepartment);
    }
    [HttpGet]
    [Route("get-AirCraftNameListByDepartmentNameId")]
    public async Task<ActionResult> GetAirCraftNameListByDepartmentNameId(int departmentNameId)
    {
        var airCraftName = await _mediator.Send(new GetAirCraftNameListByDepartmentNameIdRequest
        {
            DepartmentNameId = departmentNameId
        });
        return Ok(airCraftName);
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("operational-aircraft/{id}")]
    public async Task<ActionResult> OperationalAircraft(int id)
    {
      var command = new OperationalCommand { AirCraftNameId = id };
      await _mediator.Send(command);
      return NoContent();
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("underMaint-aircraft/{id}")]
    public async Task<ActionResult> UnderMaintAircraft(int id)
    {
      var command = new UnderMaintCommand { AcStatusId = id };
      await _mediator.Send(command);
      return NoContent();
    }
}

