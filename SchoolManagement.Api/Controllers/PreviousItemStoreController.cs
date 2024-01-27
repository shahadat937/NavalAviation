using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.PreviousItemStore;
using SchoolManagement.Application.Features.PreviousItemStores.Requests.Commands;
using SchoolManagement.Application.Features.PreviousItemStores.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.PreviousItemStore)]
[ApiController]
[Authorize]
public class PreviousItemStoreController : ControllerBase
{
    private readonly IMediator _mediator;

    public PreviousItemStoreController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-PreviousItemStores")]
    public async Task<ActionResult<List<PreviousItemStoreDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var PreviousItemStores = await _mediator.Send(new GetPreviousItemStoreListRequest { QueryParams = queryParams });
        return Ok(PreviousItemStores);
    }


    [HttpGet]
    [Route("get-PreviousItemStoreDetail/{id}")]
    public async Task<ActionResult<PreviousItemStoreDto>> Get(int id)
    {
        var PreviousItemStore = await _mediator.Send(new GetPreviousItemStoreDetailRequest { PreviousItemStoreId = id });
        return Ok(PreviousItemStore);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-PreviousItemStore")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreatePreviousItemStoreDto PreviousItemStore)
    {
        var command = new CreatePreviousItemStoreCommand { PreviousItemStoreDto = PreviousItemStore };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-PreviousItemStore/{id}")]
    public async Task<ActionResult> Put([FromBody] PreviousItemStoreDto PreviousItemStore)
    {
        var command = new UpdatePreviousItemStoreCommand { PreviousItemStoreDto = PreviousItemStore };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-PreviousItemStore/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeletePreviousItemStoreCommand { PreviousItemStoreId = id };
        await _mediator.Send(command);
        return NoContent();
    }
    [HttpGet]
    [Route("get-selectedPreviousItemStoreListByDepartmentId")]
    public async Task<ActionResult<List<PreviousItemStoreDto>>> selectedItemDetailListByDepartmentId(int departmentNameId)
    {
        var itemDetail = await _mediator.Send(new GetPreviousItemStoreListByDepartmentIdRequest
        {
            DepartmentNameId = departmentNameId
        });
        return Ok(itemDetail);

    }


}

