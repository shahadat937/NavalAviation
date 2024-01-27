using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.District;
using SchoolManagement.Application.Features.Districts.Requests.Commands;
using SchoolManagement.Application.Features.Districts.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.District)]
[ApiController]
[Authorize]
public class DistrictController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public DistrictController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
    {
        _mediator = mediator;
        this._httpContextAccessor = httpContextAccessor;
    }

    [HttpGet]
    [Route("get-districts")]
    public async Task<ActionResult<List<DistrictDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var Districts = await _mediator.Send(new GetDistrictListRequest { QueryParams = queryParams });
        return Ok(Districts);
    }

    [HttpGet]
    [Route("get-districtDetail/{id}")]
    public async Task<ActionResult<DistrictDto>> Get(int id)
    {
        var District = await _mediator.Send(new GetDistrictDetailRequest { DistrictId = id });
        return Ok(District);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-district")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateDistrictDto bDistrict)
    {
        var user = _httpContextAccessor.HttpContext.User;
        var command = new CreateDistrictCommand { DistrictDto = bDistrict };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-district/{id}")]
    public async Task<ActionResult> Put([FromBody] DistrictDto bDistrict)
    {
        var command = new UpdateDistrictCommand { DistrictDto = bDistrict };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-district/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteDistrictCommand { DistrictId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    //Relational data get 
    [HttpGet]
    [Route("get-selectedDistricts")]
    public async Task<ActionResult<List<SelectedModel>>> getselecteddistrict()
    {
        var selectedDistrict = await _mediator.Send(new GetSelectedDistrictRequest { });
        return Ok(selectedDistrict);
    }


    //new  

    [HttpGet]
    [Route("get-selectedDistrictByDivisions")]
    public async Task<ActionResult<List<SelectedModel>>> GetDataByBaseSchoolNameId(int divisionId)
    {
        var districtByDivision = await _mediator.Send(new GetSelectedDistrictByDivisionRequest { DivisionId = divisionId });
        return Ok(districtByDivision);
    }
}

