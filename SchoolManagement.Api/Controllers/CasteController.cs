using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.Caste;
using SchoolManagement.Application.Features.Castes.Requests.Commands;
using SchoolManagement.Application.Features.Castes.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.Caste)]
[ApiController]
[Authorize]
public class CasteController : ControllerBase
{
    private readonly IMediator _mediator;

    public CasteController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-castes")]
    public async Task<ActionResult<List<CasteDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var Castes = await _mediator.Send(new GetCasteListRequest { QueryParams = queryParams });
        return Ok(Castes);
    }

   

    [HttpGet]
    [Route("get-casteDetail/{id}")]
    public async Task<ActionResult<CasteDto>> Get(int id)
    {
        var Caste = await _mediator.Send(new GetCasteDetailRequest { CasteId = id });
        return Ok(Caste);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-caste")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateCasteDto bCaste)
    {
        var command = new CreateCasteCommand { CasteDto = bCaste };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-caste/{id}")]
    public async Task<ActionResult> Put([FromBody] CasteDto bCaste)
    {
        var command = new UpdateCasteCommand { CasteDto = bCaste };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-caste/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteCasteCommand { CasteId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    //Relational data get 

    [HttpGet]
    [Route("get-selectedCastes")]
    public async Task<ActionResult<List<SelectedModel>>> getselectedcaste()
    {
        var selectedCaste = await _mediator.Send(new GetSelectedCasteRequest { });
        return Ok(selectedCaste);
    }

    [HttpGet]
    [Route("get-selectedCasteByReligion")]
    public async Task<ActionResult<List<SelectedModel>>> getselectedcastebyReligion(int ReligionId)
    {
        var CasteByReligion = await _mediator.Send(new GetSelectedCasteByReligion { ReligionId = ReligionId });
        return Ok(CasteByReligion);
    }
}

