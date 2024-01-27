using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.Courses.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.Courses.Handlers.Queries
{
    public class GetSelectedCourseRequestHandler : IRequestHandler<GetSelectedCourseRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<Course> _CourseRepository;


        public GetSelectedCourseRequestHandler(ISchoolManagementRepository<Course> CourseRepository)
        {
            _CourseRepository = CourseRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedCourseRequest request, CancellationToken cancellationToken)
        {
            ICollection<Course> codeValues = await _CourseRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.CourseId
            }).ToList();
            return selectModels;
        }
    }
}
