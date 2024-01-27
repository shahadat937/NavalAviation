using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.AccountType;
using SchoolManagement.Application.Features.AccountTypes.Requests.Commands;
using SchoolManagement.Application.Features.AccountTypes.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.AccountType)]
[ApiController]
[Authorize]
public class AccountTypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public AccountTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-accountTypes")]
    public async Task<ActionResult<List<AccountTypeDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var AccountTypes = await _mediator.Send(new GetAccountTypeListRequest { QueryParams = queryParams });
        return Ok(AccountTypes);
    }

    [HttpGet]
    [Route("get-accountTypeDetail/{id}")]
    public async Task<ActionResult<AccountTypeDto>> Get(int id)
    {
        var AccountType = await _mediator.Send(new GetAccountTypeDetailRequest { AccountTypeId = id });
        return Ok(AccountType);
    }

    

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-accountType")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateAccountTypeDto AccountType)
    {
        var command = new CreateAccountTypeCommand { AccountTypeDto = AccountType };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-accountType/{id}")]
    public async Task<ActionResult> Put([FromBody] AccountTypeDto AccountType)
    {
        var command = new UpdateAccountTypeCommand { AccountTypeDto = AccountType };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-accountType/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteAccountTypeCommand { AccountTypeId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedAccountTypes")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedAccountType()
    {
        var selectedAccountType = await _mediator.Send(new GetSelectedAccountTypeRequest { });
        return Ok(selectedAccountType);
    }
}

