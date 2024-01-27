using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.StockTransferNsd;
using SchoolManagement.Application.Features.StockTransferNsds.Requests.Commands;
using SchoolManagement.Application.Features.StockTransferNsds.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.StockTransferNsd)]
[ApiController]
[Authorize]
public class StockTransferNsdController : ControllerBase
{
    private readonly IMediator _mediator;

    public StockTransferNsdController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-StockTransferNsds")]
    public async Task<ActionResult<List<StockTransferNsdDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var StockTransferNsds = await _mediator.Send(new GetStockTransferNsdListRequest { QueryParams = queryParams });
        return Ok(StockTransferNsds);
    }

    [HttpGet]
    [Route("get-StockTransferNsdDetail/{id}")]
    public async Task<ActionResult<StockTransferNsdDto>> Get(int id)
    {
        var StockTransferNsd = await _mediator.Send(new GetStockTransferNsdDetailRequest { StockTransferNsdId = id });
        return Ok(StockTransferNsd);
    }

    

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-StockTransferNsd")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromForm] CreateStockTransferNsdDto StockTransferNsd)
    {
        var command = new CreateStockTransferNsdCommand { StockTransferNsdDto = StockTransferNsd };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-StockTransferNsd/{id}")]
    public async Task<ActionResult> Put([FromForm] CreateStockTransferNsdDto StockTransferNsd)
    {
        var command = new UpdateStockTransferNsdCommand { UpdateStockTransferNsdDto = StockTransferNsd };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-StockTransferNsd/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteStockTransferNsdCommand { StockTransferNsdId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedStockTransferNsds")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedStockTransferNsd()
    {
        var selectedStockTransferNsd = await _mediator.Send(new GetSelectedStockTransferNsdRequest { });
        return Ok(selectedStockTransferNsd);
    }
    [HttpGet]
    [Route("get-stockTransferNsdListByDepartmentNameId")]
    public async Task<ActionResult> GetEquipmentNameListByDepartmentNameId(int departmentNameId, int status)
    {
      var equipmentName = await _mediator.Send(new GetStockTransferNsdListByDepartmentNameIdRequest
      {
        DepartmentNameId = departmentNameId,
        Status = status
      });
      return Ok(equipmentName);
    }


    [HttpGet]
    [Route("change-stockTransferNsdStatus")]
    public async Task<ActionResult> ChangeStockTransfarNsdStatus(int stockTransferNsdId, int status)
    {
      var equipmentName = await _mediator.Send(new ChangeStockTransfarNsdStatusRequest
      {
        StockTransferNsdId = stockTransferNsdId,
        status = status
      });
      return Ok(equipmentName);
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("approved-StockTransferNsd/{id}")]
    public async Task<ActionResult> ApprovedStockTransferNsd(int id)
    {
      var command = new ApprovedStockTransferNsdCommand { StockTransferNsdId = id };
      await _mediator.Send(command);
      return NoContent();
    }
}

