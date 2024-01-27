using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.AcctStores;
using SchoolManagement.Application.Features.AcctStores.Requests.Commands;
using SchoolManagement.Application.Features.AcctStores.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.AcctStore)]
[ApiController]
[Authorize]
public class AcctStoreController : ControllerBase
{
    private readonly IMediator _mediator;

    public AcctStoreController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-acctStore")]
    public async Task<ActionResult<List<AcctStoreDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var AcctStores = await _mediator.Send(new GetAcctStoreListRequest { QueryParams = queryParams });
        return Ok(AcctStores);
    }


    [HttpGet]
    [Route("get-acctStoreDetail/{id}")]
    public async Task<ActionResult<AcctStoreDto>> Get(int id)
    {
        var AcctStore = await _mediator.Send(new GetAcctStoreDetailRequest { AcctStoreId = id });
        return Ok(AcctStore);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-acctStore")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateAcctStoreDto AcctStore)
    {
        var command = new CreateAcctStoreCommand { AcctStoreDto = AcctStore };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-acctStore/{id}")]
    public async Task<ActionResult> Put([FromBody] AcctStoreDto AcctStore)
    {
        var command = new UpdateAcctStoreCommand { AcctStoreDto = AcctStore };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-acctStore/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteAcctStoreCommand { AcctStoreId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedAcctStore")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedAcctStore()
    {
        var AcctStore = await _mediator.Send(new GetSelectedAcctStoreRequest { });
        return Ok(AcctStore);
    }
}

