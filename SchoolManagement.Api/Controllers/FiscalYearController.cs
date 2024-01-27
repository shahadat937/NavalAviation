using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.FiscalYears;
using SchoolManagement.Application.Features.FiscalYears.Requests.Commands;
using SchoolManagement.Application.Features.FiscalYears.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.FiscalYear)]
[ApiController]
[Authorize]
public class FiscalYearController : ControllerBase
{
    private readonly IMediator _mediator;

    public FiscalYearController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-fiscalYears")]
    public async Task<ActionResult<List<FiscalYearDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var FiscalYears = await _mediator.Send(new GetFiscalYearListRequest { QueryParams = queryParams });
        return Ok(FiscalYears);
    }


    [HttpGet]
    [Route("get-fiscalYearDetail/{id}")]
    public async Task<ActionResult<FiscalYearDto>> Get(int id)
    {
        var FiscalYear = await _mediator.Send(new GetFiscalYearDetailRequest { FiscalYearId = id });
        return Ok(FiscalYear);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-fiscalYear")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateFiscalYearDto FiscalYear)
    {
        var command = new CreateFiscalYearCommand { FiscalYearDto = FiscalYear };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-fiscalYear/{id}")]
    public async Task<ActionResult> Put([FromBody] FiscalYearDto FiscalYear)
    {
        var command = new UpdateFiscalYearCommand { FiscalYearDto = FiscalYear };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-fiscalYear/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteFiscalYearCommand { FiscalYearId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedFiscalYear")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedFiscalYear()
    {
        var FiscalYear = await _mediator.Send(new GetSelectedFiscalYearRequest { });
        return Ok(FiscalYear);
    }
}

