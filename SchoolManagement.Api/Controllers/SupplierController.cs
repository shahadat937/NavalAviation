using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.Suppliers;
using SchoolManagement.Application.Features.Suppliers.Requests.Commands;
using SchoolManagement.Application.Features.Suppliers.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.Supplier)]
[ApiController]
[Authorize]
public class SupplierController : ControllerBase
{
    private readonly IMediator _mediator;

    public SupplierController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-suppliers")]
    public async Task<ActionResult<List<SupplierDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var Suppliers = await _mediator.Send(new GetSupplierListRequest { QueryParams = queryParams });
        return Ok(Suppliers);
    }


    [HttpGet]
    [Route("get-supplierDetail/{id}")]
    public async Task<ActionResult<SupplierDto>> Get(int id)
    {
        var Supplier = await _mediator.Send(new GetSupplierDetailRequest { SupplierId = id });
        return Ok(Supplier);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-supplier")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateSupplierDto Supplier)
    {
        var command = new CreateSupplierCommand { SupplierDto = Supplier };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-supplier/{id}")]
    public async Task<ActionResult> Put([FromBody] SupplierDto Supplier)
    {
        var command = new UpdateSupplierCommand { SupplierDto = Supplier };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-supplier/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteSupplierCommand { SupplierId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedSupplier")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedSupplier()
    {
        var Supplier = await _mediator.Send(new GetSelectedSupplierRequest { });
        return Ok(Supplier);
    }
}

