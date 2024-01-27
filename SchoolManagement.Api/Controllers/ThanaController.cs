using SchoolManagement.Application.DTOs.Thana;
using SchoolManagement.Application.Features.Thanas.Requests.Commands;
using SchoolManagement.Application.Features.Thanas.Requests.Queries;
using SchoolManagement.Shared.Models;
using SchoolManagement.Application.Features.Districts.Requests.Queries;
using SchoolManagement.Application;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.Thana)]
[ApiController]
[Authorize]
public class ThanaController : ControllerBase
{
    private readonly IMediator _mediator;

    public ThanaController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-thanas")]
    public async Task<ActionResult<List<ThanaDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var Thanas = await _mediator.Send(new GetThanaListRequest { QueryParams = queryParams });
        return Ok(Thanas);
    }

    [HttpGet]
    [Route("get-thanaDetail/{id}")]
    public async Task<ActionResult<ThanaDto>> Get(int id)
    {
        var Thana = await _mediator.Send(new GetThanaDetailRequest { ThanaId = id });
        return Ok(Thana);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-thana")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateThanaDto bThana)
    {
        var command = new CreateThanaCommand { ThanaDto = bThana };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-thana/{id}")]
    public async Task<ActionResult> Put([FromBody] ThanaDto bThana)
    {
        var command = new UpdateThanaCommand { ThanaDto = bThana };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-thana/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteThanaCommand { ThanaId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedThanas")]
    public async Task<ActionResult<List<SelectedModel>>> getselectedthana()
    {
        var ThanaList = await _mediator.Send(new GetSelectedThanaRequest { });
        return Ok(ThanaList);
    }

    [HttpGet("getSelectedThanaByDistrict")]
    public async Task<ActionResult<List<SelectedModel>>> getselectedthanabydistrict(int districtid)
    {
        var ThanaByDistrict = await _mediator.Send(new GetSelectedThanaByDistrictRequest { DistrictId = districtid });
        return Ok(ThanaByDistrict);
    }
}
