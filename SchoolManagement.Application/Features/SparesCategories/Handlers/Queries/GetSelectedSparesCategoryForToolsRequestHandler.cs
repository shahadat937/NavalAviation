using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.SparesCategories.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.SparesCategories.Handlers.Queries
{
    public class GetSelectedSparesCategoryForToolsRequestHandler : IRequestHandler<GetSelectedSparesCategoryForToolsRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<SparesCategory> _SparesCategoryRepository;


        public GetSelectedSparesCategoryForToolsRequestHandler(ISchoolManagementRepository<SparesCategory> SparesCategoryRepository)
        {
            _SparesCategoryRepository = SparesCategoryRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedSparesCategoryForToolsRequest request, CancellationToken cancellationToken)
        {
            ICollection<SparesCategory> codeValues = await _SparesCategoryRepository.FilterAsync(x => x.SparesCategoryId == 2);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.SparesCategoryId
            }).ToList();
            return selectModels;
        }
    }
}
