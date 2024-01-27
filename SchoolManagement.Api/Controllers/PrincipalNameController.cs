using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.PrincipalName;
using SchoolManagement.Application.Features.PrincipalNames.Requests.Commands;
using SchoolManagement.Application.Features.PrincipalNames.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.PrincipalName)]
[ApiController]
[Authorize]
public class PrincipalNameController : ControllerBase
{
    private readonly IMediator _mediator;

    public PrincipalNameController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-PrincipalNames")]
    public async Task<ActionResult<List<PrincipalNameDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var PrincipalNames = await _mediator.Send(new GetPrincipalNameListRequest { QueryParams = queryParams });
        return Ok(PrincipalNames);
    }

    [HttpGet]
    [Route("get-PrincipalNameDetail/{id}")]
    public async Task<ActionResult<PrincipalNameDto>> Get(int id)
    {
        var PrincipalName = await _mediator.Send(new GetPrincipalNameDetailRequest { PrincipalNameId = id });
        return Ok(PrincipalName);
    }

    

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-PrincipalName")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreatePrincipalNameDto PrincipalName)
    {
        var command = new CreatePrincipalNameCommand { PrincipalNameDto = PrincipalName };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-PrincipalName/{id}")]
    public async Task<ActionResult> Put([FromBody] PrincipalNameDto PrincipalName)
    {
        var command = new UpdatePrincipalNameCommand { PrincipalNameDto = PrincipalName };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-PrincipalName/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeletePrincipalNameCommand { PrincipalNameId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedPrincipalNames")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedPrincipalName()
    {
        var selectedPrincipalName = await _mediator.Send(new GetSelectedPrincipalNameRequest { });
        return Ok(selectedPrincipalName);
    }
}

