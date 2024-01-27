using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.CstTecs.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.CstTecs.Handlers.Queries
{
    public class GetSelectedCstTecRequestHandler : IRequestHandler<GetSelectedCstTecRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<CstTec> _CstTecRepository;


        public GetSelectedCstTecRequestHandler(ISchoolManagementRepository<CstTec> CstTecRepository)
        {
            _CstTecRepository = CstTecRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedCstTecRequest request, CancellationToken cancellationToken)
        {
            ICollection<CstTec> codeValues = await _CstTecRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.CstTecId
            }).ToList();
            return selectModels;
        }
    }
}
