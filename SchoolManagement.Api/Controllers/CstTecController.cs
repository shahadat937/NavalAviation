using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.CstTec;
using SchoolManagement.Application.Features.CstTecs.Requests.Commands;
using SchoolManagement.Application.Features.CstTecs.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.CstTec)]
[ApiController]
[Authorize]
public class CstTecController : ControllerBase
{
    private readonly IMediator _mediator;

    public CstTecController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-cstTec")]
    public async Task<ActionResult<List<CstTecDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var CstTecs = await _mediator.Send(new GetCstTecListRequest { QueryParams = queryParams });
        return Ok(CstTecs);
    }


    [HttpGet]
    [Route("get-cstTecDetail/{id}")]
    public async Task<ActionResult<CstTecDto>> Get(int id)
    {
        var CstTec = await _mediator.Send(new GetCstTecDetailRequest { CstTecId = id });
        return Ok(CstTec);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-cstTec")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateCstTecDto CstTec)
    {
        var command = new CreateCstTecCommand { CstTecDto = CstTec };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-cstTec/{id}")]
    public async Task<ActionResult> Put([FromBody] CstTecDto CstTec)
    {
        var command = new UpdateCstTecCommand { CstTecDto = CstTec };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-cstTec/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteCstTecCommand { CstTecId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedCstTec")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedCstTec()
    {
        var CstTec = await _mediator.Send(new GetSelectedCstTecRequest { });
        return Ok(CstTec);
    }
}

