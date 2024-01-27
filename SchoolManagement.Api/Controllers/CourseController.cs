using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.Coursees;
using SchoolManagement.Application.DTOs.Courses;
using SchoolManagement.Application.Features.Courses.Requests.Commands;
using SchoolManagement.Application.Features.Courses.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.Course)]
[ApiController]
[Authorize]
public class CourseController : ControllerBase
{
    private readonly IMediator _mediator;

    public CourseController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-courses")]
    public async Task<ActionResult<List<CourseDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var Courses = await _mediator.Send(new GetCourseListRequest { QueryParams = queryParams });
        return Ok(Courses);
    }


    [HttpGet]
    [Route("get-courseDetail/{id}")]
    public async Task<ActionResult<CourseDto>> Get(int id)
    {
        var Course = await _mediator.Send(new GetCourseDetailRequest { CourseId = id });
        return Ok(Course);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-course")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateCourseDto Course)
    {
        var command = new CreateCourseCommand { CourseDto = Course };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-course/{id}")]
    public async Task<ActionResult> Put([FromBody] CourseDto Course)
    {
        var command = new UpdateCourseCommand { CourseDto = Course };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-course/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteCourseCommand { CourseId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedCourse")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedCourse()
    {
        var Course = await _mediator.Send(new GetSelectedCourseRequest { });
        return Ok(Course);
    }
}

