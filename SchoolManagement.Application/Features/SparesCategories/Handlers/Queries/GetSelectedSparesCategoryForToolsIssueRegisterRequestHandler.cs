using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.SparesCategories.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.SparesCategories.Handlers.Queries
{
    public class GetSelectedSparesCategoryForToolsIssueRegisterRequestHandler : IRequestHandler<GetSelectedSparesCategoryForToolsIssueRegisterRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<SparesCategory> _SparesCategoryRepository;


        public GetSelectedSparesCategoryForToolsIssueRegisterRequestHandler(ISchoolManagementRepository<SparesCategory> SparesCategoryRepository)
        {
            _SparesCategoryRepository = SparesCategoryRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedSparesCategoryForToolsIssueRegisterRequest request, CancellationToken cancellationToken)
        {
            ICollection<SparesCategory> codeValues = await _SparesCategoryRepository.FilterAsync(x => x.SparesCategoryId != 1 && x.SparesCategoryId!=3);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.SparesCategoryId
            }).ToList();
            return selectModels;
        }
    }
}
