using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.Trade;
using SchoolManagement.Application.Features.Trades.Requests.Commands;
using SchoolManagement.Application.Features.Trades.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.Trade)]
[ApiController]
[Authorize]
public class TradeController : ControllerBase
{
    private readonly IMediator _mediator;

    public TradeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-trades")]
    public async Task<ActionResult<List<TradeDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var Trades = await _mediator.Send(new GetTradeListRequest { QueryParams = queryParams });
        return Ok(Trades);
    }

    [HttpGet]
    [Route("get-tradeDetail/{id}")]
    public async Task<ActionResult<TradeDto>> Get(int id)
    {
        var Trade = await _mediator.Send(new GetTradeDetailRequest { TradeId = id });
        return Ok(Trade);
    }

    

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-trade")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateTradeDto Trade)
    {
        var command = new CreateTradeCommand { TradeDto = Trade };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-trade/{id}")]
    public async Task<ActionResult> Put([FromBody] TradeDto Trade)
    {
        var command = new UpdateTradeCommand { TradeDto = Trade };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-trade/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteTradeCommand { TradeId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedTrades")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedTrade()
    {
        var selectedTrade = await _mediator.Send(new GetSelectedTradeRequest { });
        return Ok(selectedTrade);
    }
}

