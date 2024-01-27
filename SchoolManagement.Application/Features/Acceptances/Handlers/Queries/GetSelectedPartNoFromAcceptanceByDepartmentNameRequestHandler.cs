using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.Acceptances.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.Acceptances.Handlers.Queries
{
    public class GetSelectedPartNoFromAcceptanceByDepartmentNameRequestHandler : IRequestHandler<GetSelectedPartNoFromAcceptanceByDepartmentNameRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<Acceptance> _AcceptanceRepository;


        public GetSelectedPartNoFromAcceptanceByDepartmentNameRequestHandler(ISchoolManagementRepository<Acceptance> AcceptanceRepository)
        {
            _AcceptanceRepository = AcceptanceRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedPartNoFromAcceptanceByDepartmentNameRequest request, CancellationToken cancellationToken)
        {
            IQueryable<Acceptance> Acceptances = _AcceptanceRepository.FilterWithInclude((x => x.IsActive && x.DepartmentNameId==request.DepartmentNameId && x.SparesCategoryId == request.SparesCategoryId && x.SftStatus == 0), "ItemDetail");
            List<SelectedModel> selectModels = Acceptances.Select(x => new SelectedModel 
            {
                Text = x.ItemDetail.PartNo +" - "+ x.ItemDetail.NameOfItem,
                Value = x.AcceptanceId
            }).ToList();
            return selectModels;
        }
    }
}
