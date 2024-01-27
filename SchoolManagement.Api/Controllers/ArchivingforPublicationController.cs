using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.ArchivingforPublication;
using SchoolManagement.Application.Features.ArchivingforPublications.Requests.Commands;
using SchoolManagement.Application.Features.ArchivingforPublications.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.ArchivingforPublication)]
[ApiController]
[Authorize]
public class ArchivingforPublicationController : ControllerBase
{
    private readonly IMediator _mediator;

    public ArchivingforPublicationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-ArchivingforPublications")]
    public async Task<ActionResult<List<ArchivingforPublicationDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var ArchivingforPublications = await _mediator.Send(new GetArchivingforPublicationListRequest { QueryParams = queryParams });
        return Ok(ArchivingforPublications);
    }

    [HttpGet]
    [Route("get-ArchivingforPublicationDetail/{id}")]
    public async Task<ActionResult<ArchivingforPublicationDto>> Get(int id)
    {
        var ArchivingforPublication = await _mediator.Send(new GetArchivingforPublicationDetailRequest { ArchivingforPublicationId = id });
        return Ok(ArchivingforPublication);
    }

    

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-ArchivingforPublication")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromForm] CreateArchivingforPublicationDto ArchivingforPublication)
    {
        var command = new CreateArchivingforPublicationCommand { ArchivingforPublicationDto = ArchivingforPublication };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-ArchivingforPublication/{id}")]
    public async Task<ActionResult> Put([FromForm] CreateArchivingforPublicationDto ArchivingforPublication)
    {
        var command = new UpdateArchivingforPublicationCommand { UpdateArchivingforPublicationDto = ArchivingforPublication };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-ArchivingforPublication/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteArchivingforPublicationCommand { ArchivingforPublicationId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedArchivingforPublications")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedArchivingforPublication()
    {
        var selectedArchivingforPublication = await _mediator.Send(new GetSelectedArchivingforPublicationRequest { });
        return Ok(selectedArchivingforPublication);
    }
    [HttpGet]
    [Route("get-archivingforPublicationListByDepartmentNameId")]
    public async Task<ActionResult> GetArchivingforPublicationListByDepartmentNameId(int departmentNameId)
    {
      var equipmentName = await _mediator.Send(new GetArchivingforPublicationListByDepartmentNameIdRequest
      {
        DepartmentNameId = departmentNameId
      });
      return Ok(equipmentName);
    }
}

