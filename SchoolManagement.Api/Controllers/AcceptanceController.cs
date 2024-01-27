using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.Acceptances;
using SchoolManagement.Application.Features.Acceptances.Requests.Commands;
using SchoolManagement.Application.Features.Acceptances.Requests.Queries;
using SchoolManagement.Application.Features.AirCraftFlyings.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.Acceptance)]
[ApiController]
[Authorize]
public class AcceptanceController : ControllerBase
{
    private readonly IMediator _mediator;

    public AcceptanceController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-acceptances")]
    public async Task<ActionResult<List<AcceptanceDto>>> Get([FromQuery] QueryParams queryParams, int sparesCategoryId)
    {
        var Acceptances = await _mediator.Send(new GetAcceptanceListRequest 
        {
            QueryParams = queryParams,
            SparesCategoryId =sparesCategoryId
        });
        return Ok(Acceptances);
    }
   
    [HttpGet]
    [Route("get-acceptanceDetail/{id}")]
    public async Task<ActionResult<AcceptanceDto>> Get(int id)
    {
        var Acceptance = await _mediator.Send(new GetAcceptanceDetailRequest { AcceptanceId = id });
        return Ok(Acceptance);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-acceptance")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromForm] CreateAcceptanceDto Acceptance)
    {
        var command = new CreateAcceptanceCommand { AcceptanceDto = Acceptance };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-acceptance/{id}")]
    public async Task<ActionResult> Put([FromForm] CreateAcceptanceDto Acceptance)
    {
        var command = new UpdateAcceptanceCommand { AcceptanceDto = Acceptance };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-acceptance/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteAcceptanceCommand { AcceptanceId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedAcceptance")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedAcceptance()
    {
        var Acceptance = await _mediator.Send(new GetSelectedAcceptanceRequest { });
        return Ok(Acceptance);
    }

    [HttpGet]
    [Route("get-acceptanceById")]
    public async Task<ActionResult<List<AcceptanceDto>>> GetAcceptanceByDepartmentAndCategoryRequest(int acceptanceId)
    {
        var acceptenceLists = await _mediator.Send(new GetSelectedAcceptanceByDepartmentAndCategoryRequest
        {
            AcceptanceId = acceptanceId
        });
        return Ok(acceptenceLists);
    }


    [HttpGet]
    [Route("get-partnoFromAcceptanceByDepartmentNameId")]
    public async Task<ActionResult<List<SelectedModel>>> GetPartnoFromAcceptanceByDepartmentNameId(int departmentNameId, int sparesCategoryId)
    {
        var partNos = await _mediator.Send(new GetSelectedPartNoFromAcceptanceByDepartmentNameRequest
        {
            DepartmentNameId = departmentNameId,
            SparesCategoryId = sparesCategoryId
        });
        return Ok(partNos);
    }

    [HttpGet]
    [Route("get-partnoFromAcceptanceForUpdateByDepartmentNameId")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedPartNoFromAcceptanceForUpdateByDepartmentName(int departmentNameId, int sparesCategoryId)
    {
        var partNos = await _mediator.Send(new GetSelectedPartNoFromAcceptanceForUpdateByDepartmentNameRequest
        {
            DepartmentNameId = departmentNameId,
            SparesCategoryId = sparesCategoryId
        });
        return Ok(partNos);
    }
    [HttpGet]
    [Route("get-AcceptanceListByDepartmentNameId")]
    public async Task<ActionResult> GetAcceptanceListByDepartmentNameId([FromQuery] QueryParams queryParams, int sparesCategoryId, int departmentNameId)
    {
        var procurements = await _mediator.Send(new GetAcceptanceListByDepartmentNameIdRequest
        {
            QueryParams = queryParams,
            DepartmentNameId = departmentNameId,
            SparesCategoryId = sparesCategoryId
        });
        return Ok(procurements);
    }
    [HttpGet]
    [Route("get-AcceptanceListForToolsByDepartmentNameId")]
    public async Task<ActionResult> GetAcceptanceListForToolsByDepartmentNameId([FromQuery] QueryParams queryParams, int sparesCategoryId, int departmentNameId)
    {
        var procurements = await _mediator.Send(new GetAcceptanceListForToolsByDepartmentNameIdRequest
        {
            QueryParams = queryParams,
            DepartmentNameId = departmentNameId,
            SparesCategoryId = sparesCategoryId
        });
        return Ok(procurements);
    }
    [HttpGet]
    [Route("get-PartNoPassItemCategoryIdInAcceptance")]
    public async Task<ActionResult<List<SelectedModel>>> GetPartNoPassItemCategoryIdInAcceptance(int itemDetailId)
    {
        var partNos = await _mediator.Send(new GetSelectedPartNoPassItemCategoryIdInAcceptanceRequest
        {
            ItemDetailId = itemDetailId
            //DemandId = demandId
        });
        return Ok(partNos);
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("approved-Acceptance/{id}")]
    public async Task<ActionResult> ApprovedAcceptance(int id)
    {
      var command = new ApprovedAcceptanceCommand { AcceptanceId = id };
      await _mediator.Send(command);
      return NoContent();
    }


    [HttpGet]
    [Route("get-acceptanceListByPattNo")]
    public async Task<ActionResult> GetAcceptanceListByPattNo(int itemDetailId)
    {
      var acceptanceList = await _mediator.Send(new GetAcceptanceListByPattNoSpRequest
      {
        ItemDetailId=itemDetailId
      });
      return Ok(acceptanceList);
    }
}

