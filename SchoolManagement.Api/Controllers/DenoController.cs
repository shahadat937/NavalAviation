using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.Denos;
using SchoolManagement.Application.Features.Denos.Requests.Commands;
using SchoolManagement.Application.Features.Denos.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.Deno)]
[ApiController]
[Authorize]
public class DenoController : ControllerBase
{
    private readonly IMediator _mediator;

    public DenoController(IMediator mediator)   
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-denos")]
    public async Task<ActionResult<List<DenoDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var Denos = await _mediator.Send(new GetDenoListRequest { QueryParams = queryParams });
        return Ok(Denos);
    }


    [HttpGet]
    [Route("get-denoDetail/{id}")]
    public async Task<ActionResult<DenoDto>> Get(int id)
    {
        var Deno = await _mediator.Send(new GetDenoDetailRequest { DenoId = id });
        return Ok(Deno);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-deno")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateDenoDto Deno)
    {
        var command = new CreateDenoCommand { DenoDto = Deno };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-deno/{id}")]
    public async Task<ActionResult> Put([FromBody] DenoDto Deno)
    {
        var command = new UpdateDenoCommand { DenoDto = Deno };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-deno/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteDenoCommand { DenoId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedDeno")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedDeno()
    {
        var Deno = await _mediator.Send(new GetSelectedDenoRequest { });
        return Ok(Deno);
    }
}

