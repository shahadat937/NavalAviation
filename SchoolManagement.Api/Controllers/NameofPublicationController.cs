using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.NameofPublication;
using SchoolManagement.Application.Features.NameofPublications.Requests.Commands;
using SchoolManagement.Application.Features.NameofPublications.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.NameofPublication)]
[ApiController]
[Authorize]
public class NameofPublicationController : ControllerBase
{
    private readonly IMediator _mediator;

    public NameofPublicationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-NameofPublications")]
    public async Task<ActionResult<List<NameofPublicationDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var NameofPublications = await _mediator.Send(new GetNameofPublicationListRequest { QueryParams = queryParams });
        return Ok(NameofPublications);
    }

    [HttpGet]
    [Route("get-NameofPublicationDetail/{id}")]
    public async Task<ActionResult<NameofPublicationDto>> Get(int id)
    {
        var NameofPublication = await _mediator.Send(new GetNameofPublicationDetailRequest { NameofPublicationId = id });
        return Ok(NameofPublication);
    }

    

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-NameofPublication")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateNameofPublicationDto NameofPublication)
    {
        var command = new CreateNameofPublicationCommand { NameofPublicationDto = NameofPublication };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-NameofPublication/{id}")]
    public async Task<ActionResult> Put([FromBody] NameofPublicationDto NameofPublication)
    {
        var command = new UpdateNameofPublicationCommand { NameofPublicationDto = NameofPublication };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-NameofPublication/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteNameofPublicationCommand { NameofPublicationId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedNameofPublications")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedNameofPublication()
    {
        var selectedNameofPublication = await _mediator.Send(new GetSelectedNameofPublicationRequest { });
        return Ok(selectedNameofPublication);
    }
}

