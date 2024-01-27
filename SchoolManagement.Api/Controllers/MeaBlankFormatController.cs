using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.MeaBlankFormat;
using SchoolManagement.Application.Features.MeaBlankFormats.Requests.Commands;
using SchoolManagement.Application.Features.MeaBlankFormats.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.MeaBlankFormat)]
[ApiController]
[Authorize]
public class MeaBlankFormatController : ControllerBase
{
    private readonly IMediator _mediator;

    public MeaBlankFormatController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-MeaBlankFormats")]
    public async Task<ActionResult<List<MeaBlankFormatDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var MeaBlankFormats = await _mediator.Send(new GetMeaBlankFormatListRequest { QueryParams = queryParams });
        return Ok(MeaBlankFormats);
    }

    [HttpGet]
    [Route("get-MeaBlankFormatDetail/{id}")]
    public async Task<ActionResult<MeaBlankFormatDto>> Get(int id)
    {
        var MeaBlankFormat = await _mediator.Send(new GetMeaBlankFormatDetailRequest { MeaBlankFormatId = id });
        return Ok(MeaBlankFormat);
    }

    

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-MeaBlankFormat")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromForm] CreateMeaBlankFormatDto MeaBlankFormat)
    {
        var command = new CreateMeaBlankFormatCommand { MeaBlankFormatDto = MeaBlankFormat };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-MeaBlankFormat/{id}")]
    public async Task<ActionResult> Put([FromForm] CreateMeaBlankFormatDto MeaBlankFormat)
    {
        var command = new UpdateMeaBlankFormatCommand { UpdateMeaBlankFormatDto = MeaBlankFormat };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-MeaBlankFormat/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteMeaBlankFormatCommand { MeaBlankFormatId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedMeaBlankFormats")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedMeaBlankFormat()
    {
        var selectedMeaBlankFormat = await _mediator.Send(new GetSelectedMeaBlankFormatRequest { });
        return Ok(selectedMeaBlankFormat);
    }
}

