using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.MaintenanceSchedule;
using SchoolManagement.Application.DTOs.Procurement;
using SchoolManagement.Application.Features.MaintenanceSchedules.Requests.Commands;
using SchoolManagement.Application.Features.Procurements.Requests.Commands;
using SchoolManagement.Application.Features.Procurements.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.Procurement)]
[ApiController]
[Authorize]
public class ProcurementController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProcurementController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-procurements")]
    public async Task<ActionResult<List<ProcurementDto>>> Get([FromQuery] QueryParams queryParams,int sparesCategoryId)
    {
        var Procurements = await _mediator.Send(new GetProcurementListRequest
        { 
            QueryParams = queryParams,
            SparesCategoryId = sparesCategoryId
        });
        return Ok(Procurements);
    }

    [HttpGet]
    [Route("get-procurementDetail/{id}")]
    public async Task<ActionResult<ProcurementDto>> Get(int id)
    {
        var Procurement = await _mediator.Send(new GetProcurementDetailRequest { ProcurementId = id });
        return Ok(Procurement);
    }

    

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-procurement")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromForm] CreateProcurementDto Procurement)
    {
        var command = new CreateProcurementCommand { ProcurementDto = Procurement };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-procurement/{id}")]
    public async Task<ActionResult> Put([FromForm] CreateProcurementDto Procurement)
    {
        var command = new UpdateProcurementCommand { UpdateProcurementDto = Procurement };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("procurement-update/{id}")]
    public async Task<ActionResult> UpdateProcurement([FromBody] CreateProcurementDto Procurement)
    {
      var command = new ProcurementUpdateCommand { ProcurementDto = Procurement };
      await _mediator.Send(command);
      return NoContent();
    }

  [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-procurement/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteProcurementCommand { ProcurementId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-partnoFromProcurementByDepartmentNameId")]
    public async Task<ActionResult<List<SelectedModel>>> GetPartnoFromProcurementByDepartmentNameId(int departmentNameId, int sparesCategoryId)
    {
        var partNos = await _mediator.Send(new GetSelectedPartNoFromProcurementByDepartmentNameRequest
        {
            DepartmentNameId = departmentNameId,
            SparesCategoryId = sparesCategoryId
        });
        return Ok(partNos);
    }

    [HttpGet]
    [Route("get-partnoFromProcurementForUpdateByDepartmentNameId")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedPartNoFromProcurementForUpdateByDepartmentName(int departmentNameId, int sparesCategoryId)
    {
        var partNos = await _mediator.Send(new GetSelectedPartNoFromProcurementForUpdateByDepartmentNameRequest
        {
            DepartmentNameId = departmentNameId,
            SparesCategoryId = sparesCategoryId
        });
        return Ok(partNos);
    }


    [HttpGet]
    [Route("get-selectedProcurementById")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedProcurementByIdRequest(int procurementId)
    {
        var ProcurementLists = await _mediator.Send(new GetSelectedProcurementByIdRequest
        {
            ProcurementId = procurementId
        });
        return Ok(ProcurementLists);
    }

    [HttpGet]
    [Route("get-ProcurementListByDepartmentNameId")]
    public async Task<ActionResult> GetProcurementListByDepartmentNameId([FromQuery] QueryParams queryParams, int sparesCategoryId, int departmentNameId)
    {
        var procurements = await _mediator.Send(new GetProcurementListByDepartmentNameIdRequest
        {
            QueryParams = queryParams,
            DepartmentNameId = departmentNameId,
            SparesCategoryId = sparesCategoryId
        });
        return Ok(procurements);
    }
    [HttpGet]
    [Route("get-ProcurementListForToolsByDepartmentNameId")]
    public async Task<ActionResult> GetProcurementListForToolsByDepartmentNameId([FromQuery] QueryParams queryParams, int sparesCategoryId, int departmentNameId)
    {
        var procurements = await _mediator.Send(new GetProcurementListForToolsByDepartmentNameIdRequest
        {
            QueryParams = queryParams,
            DepartmentNameId = departmentNameId,
            SparesCategoryId = sparesCategoryId
        });
        return Ok(procurements);
    }
    [HttpGet]
    [Route("get-PartNoPassItemCategoryIdInProcurement")]
    public async Task<ActionResult<List<SelectedModel>>> GetPartNoPassItemCategoryIdInProcurement(int itemDetailId)
    {
        var partNos = await _mediator.Send(new GetSelectedPartNoPassItemCategoryIdInProcurementRequest
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
    [Route("approved-Procurement/{id}")]
    public async Task<ActionResult> ApprovedProcurement(int id)
    {
      var command = new ApprovedProcurementCommand { ProcurementId = id };
      await _mediator.Send(command);
      return NoContent();
    }

}

