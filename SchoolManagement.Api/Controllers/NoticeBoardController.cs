using SchoolManagement.Application;
//using SchoolManagement.Application.DTOs.NoticeBoardes;
using SchoolManagement.Application.DTOs.NoticeBoards;
using SchoolManagement.Application.Features.NoticeBoards.Requests.Commands;
using SchoolManagement.Application.Features.NoticeBoards.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.NoticeBoard)]
[ApiController]
[Authorize]
public class NoticeBoardController : ControllerBase
{
    private readonly IMediator _mediator;

    public NoticeBoardController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-noticeBoards")]
    public async Task<ActionResult<List<NoticeBoardDto>>> Get([FromQuery] QueryParams queryParams, int departmentNameId)
    {
        var NoticeBoards = await _mediator.Send(new GetNoticeBoardListRequest 
        { 
            QueryParams = queryParams,
            DepartmentNameId = departmentNameId
        });
        return Ok(NoticeBoards);
    }


    [HttpGet]
    [Route("get-noticeBoardDetail/{id}")]
    public async Task<ActionResult<NoticeBoardDto>> Get(int id)
    {
        var NoticeBoard = await _mediator.Send(new GetNoticeBoardDetailRequest { NoticeBoardId = id });
        return Ok(NoticeBoard);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-noticeBoard")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromForm] CreateNoticeBoardDto NoticeBoard)
    {
        var command = new CreateNoticeBoardCommand { NoticeBoardDto = NoticeBoard };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-noticeBoard/{id}")]
    public async Task<ActionResult> Put([FromForm] CreateNoticeBoardDto NoticeBoard)
    {
        var command = new UpdateNoticeBoardCommand { UpdateNoticeBoardDto = NoticeBoard };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-noticeBoard/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteNoticeBoardCommand { NoticeBoardId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedNoticeBoard")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedNoticeBoard()
    {
        var NoticeBoard = await _mediator.Send(new GetSelectedNoticeBoardRequest { });
        return Ok(NoticeBoard);
    }
}

