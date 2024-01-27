using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.IssueRegister;
using SchoolManagement.Application.DTOs.IssueRegister.MultipleInsertDto;
using SchoolManagement.Application.Features.IssueRegisters.Requests.Commands;
using SchoolManagement.Application.Features.IssueRegisters.Requests.Queries;
using SchoolManagement.Application.Features.ItemDetails.Requests.Queries;
using SchoolManagement.Application.Features.ItemStors.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.IssueRegister)]
[ApiController]
[Authorize]
public class IssueRegisterController : ControllerBase
{
    private readonly IMediator _mediator;

    public IssueRegisterController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-IssueRegisters")]
    public async Task<ActionResult<List<IssueRegisterDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var IssueRegisters = await _mediator.Send(new GetIssueRegisterListRequest { QueryParams = queryParams });
        return Ok(IssueRegisters);
    }

    [HttpGet]
    [Route("get-IssueRegisterDetail/{id}")]
    public async Task<ActionResult<IssueRegisterDto>> Get(int id)
    {
        var IssueRegister = await _mediator.Send(new GetIssueRegisterDetailRequest { IssueRegisterId = id });
        return Ok(IssueRegister);
    }

    

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-IssueRegister")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateIssueRegisterDto IssueRegister)
    {
        var command = new CreateIssueRegisterCommand { IssueRegisterDto = IssueRegister };
        var response = await _mediator.Send(command);
        return Ok(response); 
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-IssueRegister/{id}")]
    public async Task<ActionResult> Put([FromBody] IssueRegisterDto IssueRegister)
    {
        var command = new UpdateIssueRegisterCommand { IssueRegisterDto = IssueRegister };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("return-IssueRegister/{id}")]
    public async Task<ActionResult> ReturnIssueRegister([FromBody] ReturnIssueRegisterDto IssueRegister)
    {
        var command = new ReturnIssueRegisterCommand { ReturnIssueRegisterDto = IssueRegister };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-IssueRegister/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteIssueRegisterCommand { IssueRegisterId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedIssueRegisters")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedIssueRegister()
    {
        var selectedIssueRegister = await _mediator.Send(new GetSelectedIssueRegisterRequest { });
        return Ok(selectedIssueRegister);
    }

    [HttpGet]
    [Route("get-selectedIssueRegisterList")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedIssueRegisterListRequest(int departmentNameId, int sparesCategoryId)
    {
        var selectedIssueRegister = await _mediator.Send(new GetSelectedIssueRegisterListRequest
        {
            DepartmentNameId = departmentNameId,
            SparesCategoryId = sparesCategoryId
        });
        return Ok(selectedIssueRegister);
    }

    [HttpGet]
    [Route("get-selectedIssueRegisterOfTyList")]
    public async Task<ActionResult<List<IssueRegisterDto>>> GetIssueRegisterOfTyListRequest(int departmentNameId, int sparesCategoryId, int issueStatusId)
    {
        var selectedIssueRegister = await _mediator.Send(new GetIssueRegisterOfTyListRequest
        {
            DepartmentNameId = departmentNameId,
            SparesCategoryId = sparesCategoryId,
            IssueStatusId = issueStatusId
        });
        return Ok(selectedIssueRegister);
    }

    [HttpGet]
    [Route("get-availableIssueQtyDetailList")]
    public async Task<ActionResult> GetAvailableIssueQtyDetailList(int itemDetailId)
    {
      var selectedIssueRegister = await _mediator.Send(new GetAvailableQtyIssueDetailSpRequest
      {
        ItemDetailId = itemDetailId
      });
      return Ok(selectedIssueRegister);
    }

    [HttpGet]
    [Route("get-itemDetailForSurveyByDepartmentNameId")]
    public async Task<ActionResult> GetItemDetailForSurveyByDepartmentNameId(int departmentNameId)
    {
      var equipmentName = await _mediator.Send(new GetSelectedItemDetailForSurveyRequest
      {
        DepartmentNameId = departmentNameId
      });
      return Ok(equipmentName);
    }
  [HttpGet]
  [Route("get-autocompleteItemNameForSurveyParameterRequest")]
  public async Task<ActionResult<List<SelectedModel>>> GetAutoCompleteItemNameForSurveyByParameterRequest(string nameOfItem, int departmentNameId)
  {
    var course = await _mediator.Send(new GetAutoCompleteItemNameForSurveyByDepartmentRequest
    {
      NameOfItem = nameOfItem,
      DepartmentNameId = departmentNameId
    });
    return Ok(course);

  }

}

