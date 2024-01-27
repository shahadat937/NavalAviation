using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.Demands;
using SchoolManagement.Application.Features.Demands.Requests.Commands;
using SchoolManagement.Application.Features.Demands.Requests.Queries;
using SchoolManagement.Application.Features.ItemDetails.Requests.Queries;
using SchoolManagement.Application.Features.TraineeBioDataGeneralInfos.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.Demand)]
[ApiController]
[Authorize]
public class DemandController : ControllerBase
{
    private readonly IMediator _mediator;

    public DemandController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-demands")]
    public async Task<ActionResult<List<DemandDto>>> Get([FromQuery] QueryParams queryParams, int sparesCategoryId)
    {
        var Demands = await _mediator.Send(new GetDemandListRequest
        {
            QueryParams = queryParams,
            SparesCategoryId=sparesCategoryId
        });
        return Ok(Demands);
    }

    [HttpGet]
    [Route("get-demandDetail/{id}")]
    public async Task<ActionResult<DemandDto>> Get(int id)
    {
        var Demand = await _mediator.Send(new GetDemandDetailRequest { DemandId = id });
        return Ok(Demand);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-demand")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromForm] CreateDemandDto Demand)
    {
        var command = new CreateDemandCommand { DemandDto = Demand };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-demand/{id}")]
    public async Task<ActionResult> Put([FromForm] CreateDemandDto Demand)
    {
        var command = new UpdateDemandCommand { UpdateDemandDto = Demand };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-demand/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteDemandCommand { DemandId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedDemand")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedDemand()
    {
        var Demand = await _mediator.Send(new GetSelectedDemandRequest { });
        return Ok(Demand); 
    }

    [HttpGet]
    [Route("get-itemNameByIdRequest")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedDemand(int itemDetailId)
    {
        var itemName = await _mediator.Send(new GetItemNameByIdRequest
        {
            ItemDetailId = itemDetailId
        });
        return Ok(itemName); 
    }

    [HttpGet]
    [Route("get-autocompletePartNoByName")]
    public async Task<ActionResult<List<SelectedModel>>> GetAutoCompletePartNoByName(string partNo)
    {
        var course = await _mediator.Send(new GetAutoCompletePartNoRequest
        {
            PartNo = partNo,
        });
        return Ok(course);
    }

    [HttpGet]
    [Route("get-partnoFromDemandByDepartmentNameId")]
    public async Task<ActionResult<List<SelectedModel>>> GetPartnoFromDemandByDepartmentNameId(int departmentNameId, int sparesCategoryId)
    {
        var partNos = await _mediator.Send(new GetSelectedPartNoFromDemandByDepartmentNameRequest
        {
            DepartmentNameId = departmentNameId,
            SparesCategoryId = sparesCategoryId
        });
        return Ok(partNos);
    }

    [HttpGet]
    [Route("get-partnoFromDemandForUpdateByDepartmentNameId")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedPartNoFromDemandForUpdateByDepartmentName(int departmentNameId, int sparesCategoryId)
    {
        var partNos = await _mediator.Send(new GetSelectedPartNoFromDemandForUpdateByDepartmentNameRequest
        {
            DepartmentNameId = departmentNameId,
            SparesCategoryId = sparesCategoryId
        });
        return Ok(partNos);
    }

    [HttpGet]
    [Route("get-selectedDemandById")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedDemandByIdRequest(int demandId)
    {
        var demandLists = await _mediator.Send(new GetSelectedDemandByIdRequest
        {
            DemandId = demandId
        });
        return Ok(demandLists);
    }
    [HttpGet]
    [Route("get-DemandListByDepartmentNameId")]
    public async Task<ActionResult> GetDemandListByDepartmentNameId([FromQuery] QueryParams queryParams,int sparesCategoryId, int departmentNameId)
    {
        var demand = await _mediator.Send(new GetDemandListByDepartmentNameIdRequest
        {
            QueryParams = queryParams,
            DepartmentNameId = departmentNameId,
            SparesCategoryId= sparesCategoryId
        });
        return Ok(demand);
    }
    [HttpGet]
    [Route("get-DemandListForSparesByDepartmentNameId")]
    public async Task<ActionResult> GetDemandListForSparesByDepartmentNameId([FromQuery] QueryParams queryParams, int sparesCategoryId, int departmentNameId, int demandTypeId)
    {
        var demand = await _mediator.Send(new GetDemandListForSparesByDepartmentNameIdRequest
        {
            QueryParams = queryParams,
            DepartmentNameId = departmentNameId,
            SparesCategoryId = sparesCategoryId,
            DemandTypeId = demandTypeId
        });
        return Ok(demand);
    }
    [HttpGet]
    [Route("get-PartNoPassItemCategoryIdInDemand")]
    public async Task<ActionResult<List<SelectedModel>>> GetPartNoPassItemCategoryIdInDemand(int itemDetailId)
    {
        var partNos = await _mediator.Send(new GetSelectedPartNoPassItemCategoryIdInDemandRequest
        {
            ItemDetailId = itemDetailId
        });
        return Ok(partNos);
    }
    [HttpGet]
    [Route("get-SpGetCompleteStatus")]
    public async Task<ActionResult> GetSpGetCompleteStatus(int departmentId)
    {
        var FlyingTimeByAricraft = await _mediator.Send(new GetSpGetCompleteStatusRequest
        {
            DepartmentId = departmentId
        });
        return Ok(FlyingTimeByAricraft);
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("approved-Demand/{id}")]
    public async Task<ActionResult> ApprovedDemand(int id)
    {
      var command = new ApprovedDemandCommand { DemandId = id };
      await _mediator.Send(command);
      return NoContent();
    }
}

