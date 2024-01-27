using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.SparesCategories.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.SparesCategories.Handlers.Queries
{
    public class GetSelectedSparesCategoryForReturnableIssueHandler : IRequestHandler<GetSelectedSparesCategoryForReturnableIssueRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<SparesCategory> _SparesCategoryRepository;


        public GetSelectedSparesCategoryForReturnableIssueHandler(ISchoolManagementRepository<SparesCategory> SparesCategoryRepository)
        {
            _SparesCategoryRepository = SparesCategoryRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedSparesCategoryForReturnableIssueRequest request, CancellationToken cancellationToken)
        {
            ICollection<SparesCategory> SparesCategorys = await _SparesCategoryRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = SparesCategorys.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.SparesCategoryId
            }).ToList();
            return selectModels;
        }
    }
}
