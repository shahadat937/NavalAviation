using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Courses;
using SchoolManagement.Application.Features.Courses.Requests.Queries;

namespace SchoolManagement.Application.Features.Courses.Handlers.Queries
{
    public class GetCourseDetailRequestHandler : IRequestHandler<GetCourseDetailRequest, CourseDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.Course> _CourseRepository;
        public GetCourseDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.Course> CourseRepository, IMapper mapper)
        {
            _CourseRepository = CourseRepository;
            _mapper = mapper;
        }
        public async Task<CourseDto> Handle(GetCourseDetailRequest request, CancellationToken cancellationToken)
        {
            var Course = await _CourseRepository.Get(request.CourseId);
            return _mapper.Map<CourseDto>(Course);
        }
    }
}
