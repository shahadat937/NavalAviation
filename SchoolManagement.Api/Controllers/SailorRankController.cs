using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.SailorRank;
using SchoolManagement.Application.Features.SailorRanks.Requests.Commands;
using SchoolManagement.Application.Features.SailorRanks.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.SailorRank)]
[ApiController]
[Authorize]
public class SailorRankController : ControllerBase
{
    private readonly IMediator _mediator;

    public SailorRankController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-SailorRanks")]
    public async Task<ActionResult<List<SailorRankDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var SailorRanks = await _mediator.Send(new GetSailorRankListRequest { QueryParams = queryParams });
        return Ok(SailorRanks);
    }


    [HttpGet]
    [Route("get-SailorRankDetail/{id}")]
    public async Task<ActionResult<SailorRankDto>> Get(int id)
    {
        var SailorRank = await _mediator.Send(new GetSailorRankDetailRequest { SailorRankId = id });
        return Ok(SailorRank);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-SailorRank")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateSailorRankDto SailorRank)
    {
        var command = new CreateSailorRankCommand { SailorRankDto = SailorRank };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-SailorRank/{id}")]
    public async Task<ActionResult> Put([FromBody] SailorRankDto SailorRank)
    {
        var command = new UpdateSailorRankCommand { SailorRankDto = SailorRank };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-SailorRank/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteSailorRankCommand { SailorRankId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedSailorRank")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedSailorRank()
    {
        var SailorRank = await _mediator.Send(new GetSelectedSailorRankRequest { });
        return Ok(SailorRank);
    }
}

