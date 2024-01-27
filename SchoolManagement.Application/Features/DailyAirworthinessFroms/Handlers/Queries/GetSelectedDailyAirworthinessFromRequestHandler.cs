using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.DailyAirworthinessFroms.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.DailyAirworthinessFroms.Handlers.Queries
{
    public class GetSelectedDailyAirworthinessFromRequestHandler : IRequestHandler<GetSelectedDailyAirworthinessFromRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<DailyAirworthinessFrom> _DailyAirworthinessFromRepository;


        public GetSelectedDailyAirworthinessFromRequestHandler(ISchoolManagementRepository<DailyAirworthinessFrom> DailyAirworthinessFromRepository)
        {
            _DailyAirworthinessFromRepository = DailyAirworthinessFromRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedDailyAirworthinessFromRequest request, CancellationToken cancellationToken)
        {
            ICollection<DailyAirworthinessFrom> codeValues = await _DailyAirworthinessFromRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.DailyAirworthinessFromId
            }).ToList();
            return selectModels;
        }
    }
}
