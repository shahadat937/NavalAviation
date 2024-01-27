using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.DTOs.Courses;
using SchoolManagement.Application.Features.Courses.Requests.Queries;

namespace SchoolManagement.Application.Features.Courses.Handlers.Queries
{
    public class GetCourseListRequestHandler : IRequestHandler<GetCourseListRequest, PagedResult<CourseDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.Course> _CourseRepository;

        private readonly IMapper _mapper;

        public GetCourseListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.Course> CourseRepository, IMapper mapper)
        {
            _CourseRepository = CourseRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<CourseDto>> Handle(GetCourseListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.Course> Courses = _CourseRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = Courses.Count();
            Courses = Courses.OrderByDescending(x => x.CourseId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var CourseDtos = _mapper.Map<List<CourseDto>>(Courses);
            var result = new PagedResult<CourseDto>(CourseDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
