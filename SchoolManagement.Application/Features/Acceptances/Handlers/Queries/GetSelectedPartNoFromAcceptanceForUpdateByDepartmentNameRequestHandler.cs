using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.Acceptances.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.Acceptances.Handlers.Queries
{
    public class GetSelectedPartNoFromAcceptanceForUpdateByDepartmentNameRequestHandler : IRequestHandler<GetSelectedPartNoFromAcceptanceForUpdateByDepartmentNameRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<Acceptance> _AcceptanceRepository;


        public GetSelectedPartNoFromAcceptanceForUpdateByDepartmentNameRequestHandler(ISchoolManagementRepository<Acceptance> AcceptanceRepository)
        {
            _AcceptanceRepository = AcceptanceRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedPartNoFromAcceptanceForUpdateByDepartmentNameRequest request, CancellationToken cancellationToken)
        {
            IQueryable<Acceptance> Acceptances = _AcceptanceRepository.FilterWithInclude((x => x.IsActive && x.DepartmentNameId==request.DepartmentNameId && x.SparesCategoryId == request.SparesCategoryId), "ItemDetail");
            List<SelectedModel> selectModels = Acceptances.Select(x => new SelectedModel 
            {
                Text = x.ItemDetail.PartNo +" - "+ x.ItemDetail.NameOfItem,
                Value = x.AcceptanceId
            }).ToList();
            return selectModels;
        }
    }
}
