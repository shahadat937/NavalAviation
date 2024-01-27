using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.DailyAirworthinessFromCategorys.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.DailyAirworthinessFromCategorys.Handlers.Queries
{
    public class GetSelectedDailyAirworthinessFromCategoryRequestHandler : IRequestHandler<GetSelectedDailyAirworthinessFromCategoryRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<DailyAirworthinessFromCategory> _DailyAirworthinessFromCategoryRepository;


        public GetSelectedDailyAirworthinessFromCategoryRequestHandler(ISchoolManagementRepository<DailyAirworthinessFromCategory> DailyAirworthinessFromCategoryRepository)
        {
            _DailyAirworthinessFromCategoryRepository = DailyAirworthinessFromCategoryRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedDailyAirworthinessFromCategoryRequest request, CancellationToken cancellationToken)
        {
            ICollection<DailyAirworthinessFromCategory> codeValues = await _DailyAirworthinessFromCategoryRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.DailyAirworthinessFromCategoryId
            }).ToList();
            return selectModels;
        }
    }
}
