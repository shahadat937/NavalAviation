using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.RunningHours.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.RunningHours.Handlers.Queries
{
    public class GetSelectedRunningHourRequestHandler : IRequestHandler<GetSelectedRunningHourRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<RunningHour> _RunningHourRepository;


        public GetSelectedRunningHourRequestHandler(ISchoolManagementRepository<RunningHour> RunningHourRepository)
        {
            _RunningHourRepository = RunningHourRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedRunningHourRequest request, CancellationToken cancellationToken)
        {
            ICollection<RunningHour> codeValues = await _RunningHourRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.FlightDate,
                Value = x.RunningHourId
            }).ToList();
            return selectModels;
        }
    }
}
