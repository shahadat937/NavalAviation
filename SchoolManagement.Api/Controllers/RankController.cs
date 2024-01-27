using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.Rank;
using SchoolManagement.Application.Features.Ranks.Requests.Commands;
using SchoolManagement.Application.Features.Ranks.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.Rank)]
[ApiController]
[Authorize]
public class RankController : ControllerBase
{
    private readonly IMediator _mediator;

    public RankController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-Ranks")]
    public async Task<ActionResult<List<RankDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var Ranks = await _mediator.Send(new GetRankListRequest { QueryParams = queryParams });
        return Ok(Ranks);
    }

    [HttpGet]
    [Route("get-RankDetail/{id}")]
    public async Task<ActionResult<RankDto>> Get(int id)
    {
        var Rank = await _mediator.Send(new GetRankDetailRequest { RankId = id });
        return Ok(Rank);
    }

    

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-Rank")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateRankDto Rank)
    {
        var command = new CreateRankCommand { RankDto = Rank };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-Rank/{id}")]
    public async Task<ActionResult> Put([FromBody] RankDto Rank)
    {
        var command = new UpdateRankCommand { RankDto = Rank };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-Rank/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteRankCommand { RankId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedRanks")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedRank()
    {
        var selectedRank = await _mediator.Send(new GetSelectedRankRequest { });
        return Ok(selectedRank);
    }
}

