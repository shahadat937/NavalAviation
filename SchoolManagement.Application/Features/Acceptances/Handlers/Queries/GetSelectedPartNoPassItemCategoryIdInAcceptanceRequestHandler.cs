using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.Acceptances.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.Acceptances.Handlers.Queries
{
    public class GetSelectedPartNoPassItemCategoryIdInAcceptanceRequestHandler : IRequestHandler<GetSelectedPartNoPassItemCategoryIdInAcceptanceRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<Acceptance> _AcceptanceRepository;


        public GetSelectedPartNoPassItemCategoryIdInAcceptanceRequestHandler(ISchoolManagementRepository<Acceptance> AcceptanceRepository)
        {
            _AcceptanceRepository = AcceptanceRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedPartNoPassItemCategoryIdInAcceptanceRequest request, CancellationToken cancellationToken)
        {
            IQueryable<Acceptance> Acceptances = _AcceptanceRepository.FilterWithInclude((x => x.IsActive && x.ItemDetailId == request.ItemDetailId ));
            List<SelectedModel> selectModels = Acceptances.Select(x => new SelectedModel 
            {
                Text = x.ItemDetail.ItemCategoryId,
                Value = x.AcceptanceId
            }).ToList();
            return selectModels;
        }
    }
}
