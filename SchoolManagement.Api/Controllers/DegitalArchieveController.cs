using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.DegitalArchieve;
using SchoolManagement.Application.Features.DegitalArchieves.Requests.Commands;
using SchoolManagement.Application.Features.DegitalArchieves.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.DegitalArchieve)]
[ApiController]
[Authorize]
public class DegitalArchieveController : ControllerBase
{
    private readonly IMediator _mediator;

    public DegitalArchieveController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-DegitalArchieves")]
    public async Task<ActionResult<List<DegitalArchieveDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var DegitalArchieves = await _mediator.Send(new GetDegitalArchieveListRequest { QueryParams = queryParams });
        return Ok(DegitalArchieves);
    }

    [HttpGet]
    [Route("get-DegitalArchieveDetail/{id}")]
    public async Task<ActionResult<DegitalArchieveDto>> Get(int id)
    {
        var DegitalArchieve = await _mediator.Send(new GetDegitalArchieveDetailRequest { DegitalArchieveId = id });
        return Ok(DegitalArchieve);
    }

    

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-DegitalArchieve")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromForm] CreateDegitalArchieveDto DegitalArchieve)
    {
        var command = new CreateDegitalArchieveCommand { DegitalArchieveDto = DegitalArchieve };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-DegitalArchieve/{id}")]
    public async Task<ActionResult> Put([FromForm] CreateDegitalArchieveDto DegitalArchieve)
    {
        var command = new UpdateDegitalArchieveCommand { UpdateDegitalArchieveDto = DegitalArchieve };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-DegitalArchieve/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteDegitalArchieveCommand { DegitalArchieveId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedDegitalArchieves")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedDegitalArchieve()
    {
        var selectedDegitalArchieve = await _mediator.Send(new GetSelectedDegitalArchieveRequest { });
        return Ok(selectedDegitalArchieve);
    }
    [HttpGet]
    [Route("get-degitalArchieveListByDepartmentNameId")]
    public async Task<ActionResult> GetDegitalArchieveListByDepartmentNameId(int departmentNameId)
    {
      var equipmentName = await _mediator.Send(new GetDegitalArchieveListByDepartmentNameIdRequest
      {
        DepartmentNameId = departmentNameId
      });
      return Ok(equipmentName);
    }
}

