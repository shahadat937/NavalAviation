using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.SparesCategorys;
using SchoolManagement.Application.Features.SparesCategories.Requests.Commands;
using SchoolManagement.Application.Features.SparesCategories.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.SparesCategory)]
[ApiController]
[Authorize]
public class SparesCategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public SparesCategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-sparesCategories")]
    public async Task<ActionResult<List<SparesCategoryDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var SparesCategorys = await _mediator.Send(new GetSparesCategoryListRequest { QueryParams = queryParams });
        return Ok(SparesCategorys);
    }


    [HttpGet]
    [Route("get-sparesCategoryDetail/{id}")]
    public async Task<ActionResult<SparesCategoryDto>> Get(int id)
    {
        var SparesCategory = await _mediator.Send(new GetSparesCategoryDetailRequest { SparesCategoryId = id });
        return Ok(SparesCategory);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-sparesCategory")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateSparesCategoryDto SparesCategory)
    {
        var command = new CreateSparesCategoryCommand { SparesCategoryDto = SparesCategory };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-sparesCategory/{id}")]
    public async Task<ActionResult> Put([FromBody] SparesCategoryDto SparesCategory)
    {
        var command = new UpdateSparesCategoryCommand { SparesCategoryDto = SparesCategory };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-sparesCategory/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteSparesCategoryCommand { SparesCategoryId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedSparesCategory")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedSparesCategory()
    {
        var SparesCategory = await _mediator.Send(new GetSelectedSparesCategoryRequest { });
        return Ok(SparesCategory);
    }
    [HttpGet]
    [Route("get-selectedSparesCategoryForToolsIssueRegister")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedSparesCategoryForToolsIssueRegister()
    {
        var SparesCategory = await _mediator.Send(new GetSelectedSparesCategoryForToolsIssueRegisterRequest { });
        return Ok(SparesCategory);
    }
    [HttpGet]
    [Route("get-selectedSparesCategoryForReturnableIssue")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedSparesCategoryForReturnableIssue()
    {
        var sparesCategory = await _mediator.Send(new GetSelectedSparesCategoryForReturnableIssueRequest { });
        return Ok(sparesCategory);
    }
    [HttpGet]
    [Route("get-selectedSparesCategoryForTools")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedSparesCategoryForTools()
    {
        var SparesCategory = await _mediator.Send(new GetSelectedSparesCategoryForToolsRequest { });
        return Ok(SparesCategory);
    }
    [HttpGet]
    [Route("get-selectedSparesCategoryforRequired")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedSparesCategoryforRequired()
    {
      var SparesCategory = await _mediator.Send(new GetSelectedSparesCategoryforRequiredRequest { });
      return Ok(SparesCategory);
    }
}

