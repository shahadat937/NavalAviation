using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.ItemDetail;
using SchoolManagement.Application.Features.ItemDetails.Requests.Commands;
using SchoolManagement.Application.Features.ItemDetails.Requests.Queries;
using SchoolManagement.Application.Features.ItemStatuses.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.ItemDetail)]
[ApiController]
[Authorize]
public class ItemDetailController : ControllerBase
{
    private readonly IMediator _mediator;

    public ItemDetailController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-ItemDetails")]
    public async Task<ActionResult<List<ItemDetailDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var ItemDetails = await _mediator.Send(new GetItemDetailListRequest { QueryParams = queryParams });
        return Ok(ItemDetails);
    }

    [HttpGet]
    [Route("get-itemDetailsForTools")]
    public async Task<ActionResult<List<ItemDetailDto>>> GetItemDetailsForTools([FromQuery] QueryParams queryParams,int sparesCategoryId)
    {
        var ItemDetails = await _mediator.Send(new GetItemDetailListForToolsRequest
        { 
            QueryParams = queryParams,
            SparesCategoryId =sparesCategoryId
            
        });
        return Ok(ItemDetails);
    }

    [HttpGet]
    [Route("get-ItemDetailDetail/{id}")]
    public async Task<ActionResult<ItemDetailDto>> Get(int id)
    {
        var ItemDetail = await _mediator.Send(new GetItemDetailDetailRequest { ItemDetailId = id });
        return Ok(ItemDetail);
    }

    

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-ItemDetail")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateItemDetailDto ItemDetail)
    {
        var command = new CreateItemDetailCommand { ItemDetailDto = ItemDetail };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-ItemDetail/{id}")]
    public async Task<ActionResult> Put([FromBody] ItemDetailDto ItemDetail)
    {
        var command = new UpdateItemDetailCommand { ItemDetailDto = ItemDetail };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-ItemDetail/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteItemDetailCommand { ItemDetailId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedItemDetails")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedItemDetail(int departmentNameId, int sparesCategoryId)
    {
        var selectedItemDetail = await _mediator.Send(new GetSelectedItemDetailRequest {
          DepartmentNameId = departmentNameId,
          SparesCategoryId = sparesCategoryId
          
        });
        return Ok(selectedItemDetail);
    }

    [HttpGet] 
    [Route("get-partnoByDepartmentNameId")]
    public async Task<ActionResult<List<SelectedModel>>> GetPartnoByDepartmentNameId(int departmentNameId)
    {
        var partNos = await _mediator.Send(new GetSelectedPartNoByDepartmentNameRequest 
        { 
            DepartmentNameId = departmentNameId
        });
        return Ok(partNos); 
    }

    [HttpGet]
    [Route("get-partnoForSparesByDepartmentNameId")]
    public async Task<ActionResult<List<SelectedModel>>> GetPartnoForSparesByDepartmentNameId(int departmentNameId,int spareCategoryId)
    {
      var partNos = await _mediator.Send(new GetSelectedPartNoForSparesByDepartmentNameRequest
      {
        DepartmentNameId = departmentNameId,
        SpareCategoryId =spareCategoryId
      });
      return Ok(partNos);
    }

  [HttpGet]
    [Route("get-itemNameByItemDetailId")] 
    public async Task<ActionResult<List<SelectedModel>>> GetItemNameByItemDetailId(int itemDetailId)
    {
        var partNos = await _mediator.Send(new GetSelectedItemNameByItemDetailIdRequest
        {
            ItemDetailId = itemDetailId 
        });
        return Ok(partNos);
    }

    [HttpGet]
    [Route("get-selectedItemDetailListByDepartmentId")]
    public async Task<ActionResult<List<ItemDetailDto>>> selectedItemDetailListByDepartmentId(int departmentNameId)
    {
        var itemDetail = await _mediator.Send(new GetItemDetailListByDepartmentIdRequest
        {
            DepartmentNameId = departmentNameId
        });
        return Ok(itemDetail);

    }
    [HttpGet]
    [Route("get-ItemDetailByDepartmentId")]
    public async Task<ActionResult<List<ItemDetailDto>>> GetItemDetailByDepartmentId(int departmentNameId)
    {
        var itemdetails = await _mediator.Send(new GetItemDetailByDepartmentIdRequest
        {
            DepartmentNameId = departmentNameId,
        });
        return Ok(itemdetails);
    }

    [HttpGet]
    [Route("get-autocompletePartNoByNameForSpares")]
    public async Task<ActionResult<List<SelectedModel>>> GetAutoCompletePartNoForSpares(string partNo)
    {
        var course = await _mediator.Send(new GetAutoCompletePartNoForSparesRequest 
        {
            PartNo = partNo,
        });
        return Ok(course);
    }

    [HttpGet]
    [Route("get-autocompletePartNoByNameForSparesByDepartmentId")]
    public async Task<ActionResult<List<SelectedModel>>> GetAutoCompletePartNoForSparesByDepartmentNameId(string partNo,int departmentNameId)
    {
    var course = await _mediator.Send(new GetAutoCompletePartNoForSparesByDepartmentIdRequest
    {
      PartNo = partNo,
      DepartmentNameId = departmentNameId
    });
      return Ok(course);
    }

  [HttpGet]
    [Route("get-autocompletePartNoForParameterRequest")]
    public async Task<ActionResult<List<SelectedModel>>> GetAutoCompletePartNoForSparesByParameterRequest(string partNo,int departmentNameId,int spareCategoryId)
    {
      var course = await _mediator.Send(new GetAutoCompletePartNoByParameterRequest
      {
        PartNo = partNo,
        DepartmentNameId = departmentNameId,
        SpareCategoryId = spareCategoryId
      });
      return Ok(course);

    }


  [HttpGet]
    [Route("get-autocompletePartNoByDepartment")]
    public async Task<ActionResult<List<SelectedModel>>> GetAutoCompletePartNoForDepartment(string partNo)
    {
        var itemDetail = await _mediator.Send(new GetAutoCompletePartNoByDepartmentRequest
        {
            PartNo = partNo,
        });
        return Ok(itemDetail);

    }


    [HttpGet]
    [Route("get-presentStocks")]
    public async Task<ActionResult> GetPresentStocks(int departmentId, int sparesCategoryId, string searchText)
    {
        var presentStocks = await _mediator.Send(new GetPresentStockSpRequest
        {
            DepartmentId = departmentId,
            SparesCategoryId = sparesCategoryId,
            SearchText = searchText
        });
        return Ok(presentStocks);
    }

    [HttpGet]
    [Route("get-searchingByItemDetailId")]
    public async Task<ActionResult> GetSearchingByItemDetailId(int itemDetailId)
    {
        var presentStocks = await _mediator.Send(new GetSearchingByItemDetailIdSpRequest
        {
          ItemDetailId = itemDetailId
        });
        return Ok(presentStocks);
    }
      [HttpGet]
      [Route("get-itemNmaeAndPartNoByDepartmentNameId")]
      public async Task<ActionResult<List<SelectedModel>>> GetItemNmaeAndPartNoByDepartmentNameId(int departmentNameId, int spare)
      {
        var partNos = await _mediator.Send(new GetSelectedItemNmaeAndPartNoByDepartmentNameRequest
        {
          DepartmentNameId = departmentNameId,
          SparesCategoryId=spare
        });
        return Ok(partNos);
     }

      [HttpGet]
      [Route("get-itemNameAndPartNoByDepartmentNameId")]
      public async Task<ActionResult<List<SelectedModel>>> GetSelectedItemNmaeAndPartNoByDepartmentNameId(int departmentNameId)
      {
        var partNos = await _mediator.Send(new GetSelectedItemNameAndPartNoByDepartmentNameRequest
        {
          DepartmentNameId = departmentNameId
        });
        return Ok(partNos);
      }
      [HttpGet]
      [ProducesResponseType(StatusCodes.Status204NoContent)]
      [ProducesResponseType(StatusCodes.Status404NotFound)]
      [ProducesDefaultResponseType]
      [Route("approved-ItemDetail/{id}")]
      public async Task<ActionResult> ApprovedItemDetail(int id)
      {
        var command = new ApprovedItemDetailCommand { ItemDetailId = id };
        await _mediator.Send(command);
        return NoContent();
      }
  [HttpGet]
  [Route("get-selectedItemNameAndPattNo")]
  public async Task<ActionResult<List<SelectedModel>>> GetSelectedItemNameAndPattNoRequest()
  {
    var ItemStatus = await _mediator.Send(new GetSelectedItemNameAndPattNoRequest { });
    return Ok(ItemStatus);
  }
  [HttpGet]
  [Route("get-nameOfItemIsExistCheck")]
  public async Task<ActionResult<bool>> GetnameOfItemIsEXistCheck(string nameOfItem)
  {
    var isExist = await _mediator.Send(new GetItemNameIsExistCheckRequest
    {
      NameOfItem = nameOfItem,
    });
    return Ok(isExist);
  }

}

