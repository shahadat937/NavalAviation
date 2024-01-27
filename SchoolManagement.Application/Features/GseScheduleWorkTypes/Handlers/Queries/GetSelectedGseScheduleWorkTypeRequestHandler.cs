using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.GseScheduleWorkTypes.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.GseScheduleWorkTypes.Handlers.Queries
{
    public class GetSelectedGseScheduleWorkTypeRequestHandler : IRequestHandler<GetSelectedGseScheduleWorkTypeRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<GseScheduleWorkType> _GseScheduleWorkTypeRepository;


        public GetSelectedGseScheduleWorkTypeRequestHandler(ISchoolManagementRepository<GseScheduleWorkType> GseScheduleWorkTypeRepository)
        {
            _GseScheduleWorkTypeRepository = GseScheduleWorkTypeRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedGseScheduleWorkTypeRequest request, CancellationToken cancellationToken)
        {
            ICollection<GseScheduleWorkType> codeValues = await _GseScheduleWorkTypeRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.ScheduleWorkName,
                Value = x.GseScheduleWorkTypeId
            }).ToList();
            return selectModels;
        }
    }
}
