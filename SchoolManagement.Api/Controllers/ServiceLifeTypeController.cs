using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.ServiceLifeTypes;
using SchoolManagement.Application.Features.ServiceLifeTypes.Requests.Commands;
using SchoolManagement.Application.Features.ServiceLifeTypes.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.ServiceLifeType)]
[ApiController]
[Authorize]
public class ServiceLifeTypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public ServiceLifeTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-serviceLifeTypes")]
    public async Task<ActionResult<List<ServiceLifeTypeDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var ServiceLifeTypes = await _mediator.Send(new GetServiceLifeTypeListRequest { QueryParams = queryParams });
        return Ok(ServiceLifeTypes);
    }


    [HttpGet]
    [Route("get-serviceLifeTypeDetail/{id}")]
    public async Task<ActionResult<ServiceLifeTypeDto>> Get(int id)
    {
        var ServiceLifeType = await _mediator.Send(new GetServiceLifeTypeDetailRequest { ServiceLifeTypeId = id });
        return Ok(ServiceLifeType);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-serviceLifeType")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateServiceLifeTypeDto ServiceLifeType)
    {
        var command = new CreateServiceLifeTypeCommand { ServiceLifeTypeDto = ServiceLifeType };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-serviceLifeType/{id}")]
    public async Task<ActionResult> Put([FromBody] ServiceLifeTypeDto ServiceLifeType)
    {
        var command = new UpdateServiceLifeTypeCommand { ServiceLifeTypeDto = ServiceLifeType };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-serviceLifeType/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteServiceLifeTypeCommand { ServiceLifeTypeId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedServiceLifeType")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedServiceLifeType()
    {
        var ServiceLifeType = await _mediator.Send(new GetSelectedServiceLifeTypeRequest { });
        return Ok(ServiceLifeType);
    }
}

