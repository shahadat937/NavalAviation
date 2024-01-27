using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.DegitalArchieveDocType;
using SchoolManagement.Application.Features.DegitalArchieveDocTypes.Requests.Commands;
using SchoolManagement.Application.Features.DegitalArchieveDocTypes.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.DegitalArchieveDocType)]
[ApiController]
[Authorize]
public class DegitalArchieveDocTypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public DegitalArchieveDocTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-DegitalArchieveDocTypes")]
    public async Task<ActionResult<List<DegitalArchieveDocTypeDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var DegitalArchieveDocTypes = await _mediator.Send(new GetDegitalArchieveDocTypeListRequest { QueryParams = queryParams });
        return Ok(DegitalArchieveDocTypes);
    }

    [HttpGet]
    [Route("get-DegitalArchieveDocTypeDetail/{id}")]
    public async Task<ActionResult<DegitalArchieveDocTypeDto>> Get(int id)
    {
        var DegitalArchieveDocType = await _mediator.Send(new GetDegitalArchieveDocTypeDetailRequest { DegitalArchieveDocTypeId = id });
        return Ok(DegitalArchieveDocType);
    }

    

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-DegitalArchieveDocType")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateDegitalArchieveDocTypeDto DegitalArchieveDocType)
    {
        var command = new CreateDegitalArchieveDocTypeCommand { DegitalArchieveDocTypeDto = DegitalArchieveDocType };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-DegitalArchieveDocType/{id}")]
    public async Task<ActionResult> Put([FromBody] DegitalArchieveDocTypeDto DegitalArchieveDocType)
    {
        var command = new UpdateDegitalArchieveDocTypeCommand { DegitalArchieveDocTypeDto = DegitalArchieveDocType };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-DegitalArchieveDocType/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteDegitalArchieveDocTypeCommand { DegitalArchieveDocTypeId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedDegitalArchieveDocTypes")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedDegitalArchieveDocType()
    {
        var selectedDegitalArchieveDocType = await _mediator.Send(new GetSelectedDegitalArchieveDocTypeRequest { });
        return Ok(selectedDegitalArchieveDocType);
    }
}

