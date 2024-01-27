using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.DemandDocs;
using SchoolManagement.Application.Features.DemandDocs.Requests.Commands;
using SchoolManagement.Application.Features.DemandDocs.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.DemandDoc)]
[ApiController]
[Authorize]
public class DemandDocController : ControllerBase
{
    private readonly IMediator _mediator;

    public DemandDocController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-demandDocs")]
    public async Task<ActionResult<List<DemandDocDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var DemandDocs = await _mediator.Send(new GetDemandDocListRequest { QueryParams = queryParams });
        return Ok(DemandDocs);
    }


    [HttpGet]
    [Route("get-demandDocDetail/{id}")]
    public async Task<ActionResult<DemandDocDto>> Get(int id)
    {
        var DemandDoc = await _mediator.Send(new GetDemandDocDetailRequest { DemandDocId = id });
        return Ok(DemandDoc);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-demandDoc")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateDemandDocDto DemandDoc)
    {
        var command = new CreateDemandDocCommand { DemandDocDto = DemandDoc };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-demandDoc/{id}")]
    public async Task<ActionResult> Put([FromBody] DemandDocDto DemandDoc)
    {
        var command = new UpdateDemandDocCommand { DemandDocDto = DemandDoc };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-demandDoc/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteDemandDocCommand { DemandDocId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedDemandDoc")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedDemandDoc()
    {
        var DemandDoc = await _mediator.Send(new GetSelectedDemandDocRequest { });
        return Ok(DemandDoc);
    }
}

