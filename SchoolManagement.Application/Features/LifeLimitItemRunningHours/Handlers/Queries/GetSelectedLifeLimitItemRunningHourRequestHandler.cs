using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.LifeLimitItemRunningHours.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.LifeLimitItemRunningHours.Handlers.Queries
{
    public class GetSelectedLifeLimitItemRunningHourRequestHandler : IRequestHandler<GetSelectedLifeLimitItemRunningHourRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<LifeLimitItemRunningHour> _LifeLimitItemRunningHourRepository;


        public GetSelectedLifeLimitItemRunningHourRequestHandler(ISchoolManagementRepository<LifeLimitItemRunningHour> LifeLimitItemRunningHourRepository)
        {
            _LifeLimitItemRunningHourRepository = LifeLimitItemRunningHourRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedLifeLimitItemRunningHourRequest request, CancellationToken cancellationToken)
        {
            ICollection<LifeLimitItemRunningHour> codeValues = await _LifeLimitItemRunningHourRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.SlNo,
                Value = x.LifeLimitItemRunningHourId
            }).ToList();
            return selectModels;
        }
    }
}
