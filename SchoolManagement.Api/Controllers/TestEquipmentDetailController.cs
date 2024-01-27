using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.TestEquipmentDetail;
using SchoolManagement.Application.Features.TestEquipmentDetails.Requests.Commands;
using SchoolManagement.Application.Features.TestEquipmentDetails.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.TestEquipmentDetail)]
[ApiController]
[Authorize]
public class TestEquipmentDetailController : ControllerBase
{
    private readonly IMediator _mediator;

    public TestEquipmentDetailController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-TestEquipmentDetails")]
    public async Task<ActionResult<List<TestEquipmentDetailDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var leaveTypes = await _mediator.Send(new GetTestEquipmentDetailListRequest { QueryParams = queryParams });
        return Ok(leaveTypes);
    }


    [HttpGet]
    [Route("get-TestEquipmentDetailDetail/{id}")]
    public async Task<ActionResult<TestEquipmentDetailDto>> Get(int id)
    {
        var leaveType = await _mediator.Send(new GetTestEquipmentDetailDetailRequest { TestEquipmentDetailId = id });
        return Ok(leaveType);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-TestEquipmentDetail")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateTestEquipmentDetailDto uTOfficerCategory)
    {
        var command = new CreateTestEquipmentDetailCommand { TestEquipmentDetailDto = uTOfficerCategory };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-TestEquipmentDetail/{id}")]
    public async Task<ActionResult> Put([FromBody] TestEquipmentDetailDto uTOfficerCategory)
    {
        var command = new UpdateTestEquipmentDetailCommand { TestEquipmentDetailDto = uTOfficerCategory };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-TestEquipmentDetail/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteTestEquipmentDetailCommand { TestEquipmentDetailId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedTestEquipmentDetails")]
    public async Task<ActionResult<List<SelectedModel>>> getselectedTestEquipmentDetail()
    {
        var CasteByTestEquipmentDetail = await _mediator.Send(new GetSelectedTestEquipmentDetailRequest { });
        return Ok(CasteByTestEquipmentDetail);
    }
}

