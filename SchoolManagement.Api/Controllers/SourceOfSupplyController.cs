using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.SourceOfSupply;
using SchoolManagement.Application.Features.SourceOfSupplys.Requests.Commands;
using SchoolManagement.Application.Features.SourceOfSupplys.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.SourceOfSupply)]
[ApiController]
[Authorize]
public class SourceOfSupplyController : ControllerBase
{
    private readonly IMediator _mediator;

    public SourceOfSupplyController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-SourceOfSupplys")]
    public async Task<ActionResult<List<SourceOfSupplyDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var SourceOfSupplys = await _mediator.Send(new GetSourceOfSupplyListRequest { QueryParams = queryParams });
        return Ok(SourceOfSupplys);
    }

    [HttpGet]
    [Route("get-SourceOfSupplyDetail/{id}")]
    public async Task<ActionResult<SourceOfSupplyDto>> Get(int id)
    {
        var SourceOfSupply = await _mediator.Send(new GetSourceOfSupplyDetailRequest { SourceOfSupplyId = id });
        return Ok(SourceOfSupply);
    }

    

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-SourceOfSupply")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateSourceOfSupplyDto SourceOfSupply)
    {
        var command = new CreateSourceOfSupplyCommand { SourceOfSupplyDto = SourceOfSupply };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-SourceOfSupply/{id}")]
    public async Task<ActionResult> Put([FromBody] SourceOfSupplyDto SourceOfSupply)
    {
        var command = new UpdateSourceOfSupplyCommand { SourceOfSupplyDto = SourceOfSupply };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-SourceOfSupply/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteSourceOfSupplyCommand { SourceOfSupplyId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedSourceOfSupplys")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedSourceOfSupply()
    {
        var selectedSourceOfSupply = await _mediator.Send(new GetSelectedSourceOfSupplyRequest { });
        return Ok(selectedSourceOfSupply);
    }
}

