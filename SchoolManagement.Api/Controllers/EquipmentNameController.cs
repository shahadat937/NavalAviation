using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.EquipmentName;
using SchoolManagement.Application.Features.EquipmentNames.Requests.Commands;
using SchoolManagement.Application.Features.EquipmentNames.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.EquipmentName)]
[ApiController]
[Authorize]
public class EquipmentNameController : ControllerBase
{
    private readonly IMediator _mediator;

    public EquipmentNameController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-equipmentNames")]
    public async Task<ActionResult<List<EquipmentNameDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var EquipmentNames = await _mediator.Send(new GetEquipmentNameListRequest { QueryParams = queryParams });
        return Ok(EquipmentNames);
    }


    [HttpGet]
    [Route("get-equipmentNameDetail/{id}")]
    public async Task<ActionResult<EquipmentNameDto>> Get(int id)
    {
        var EquipmentName = await _mediator.Send(new GetEquipmentNameDetailRequest { EquipmentNameId = id });
        return Ok(EquipmentName);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-equipmentName")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateEquipmentNameDto EquipmentName)
    {
        var command = new CreateEquipmentNameCommand { EquipmentNameDto = EquipmentName };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-equipmentName/{id}")]
    public async Task<ActionResult> Put([FromBody] EquipmentNameDto EquipmentName)
    {
        var command = new UpdateEquipmentNameCommand { EquipmentNameDto = EquipmentName };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-equipmentName/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteEquipmentNameCommand { EquipmentNameId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedEquipmentName")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedEquipmentName()
    {
        var EquipmentName = await _mediator.Send(new GetSelectedEquipmentNameRequest { });
        return Ok(EquipmentName);
    }
    [HttpGet]
    [Route("get-equipmentNameListByDepartmentNameId")]
    public async Task<ActionResult> GetEquipmentNameListByDepartmentNameId(int departmentNameId)
    {
        var equipmentName = await _mediator.Send(new GetEquipmentNameListByDepartmentNameIdRequest
        {
            DepartmentNameId = departmentNameId
        });
        return Ok(equipmentName);
    }
    [HttpGet]
    [Route("get-selectedEquipmentNameBySparesCategoryId")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedEquipmentNameBySparesCategoryId(int sparesCategoryId)
    {
        var departmentbyType = await _mediator.Send(new GetEquipmentNameBySparesCategoryIdRequest
        {   
            SparesCategoryId = sparesCategoryId

        });
        return Ok(departmentbyType);
    }
}

