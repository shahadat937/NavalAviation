using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.Procurements.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.Procurements.Handlers.Queries
{
    public class GetSelectedPartNoFromProcurementForUpdateByDepartmentNameRequestHandler : IRequestHandler<GetSelectedPartNoFromProcurementForUpdateByDepartmentNameRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<Procurement> _ProcurementRepository;


        public GetSelectedPartNoFromProcurementForUpdateByDepartmentNameRequestHandler(ISchoolManagementRepository<Procurement> ProcurementRepository)
        {
            _ProcurementRepository = ProcurementRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedPartNoFromProcurementForUpdateByDepartmentNameRequest request, CancellationToken cancellationToken)
        {
            IQueryable<Procurement> Procurements = _ProcurementRepository.FilterWithInclude((x => x.IsActive && x.SparesCategoryId == request.SparesCategoryId && x.DepartmentNameId==request.DepartmentNameId), "ItemDetail");
            List<SelectedModel> selectModels = Procurements.Select(x => new SelectedModel 
            {
                Text = x.ItemDetail.PartNo +" - "+ x.ItemDetail.NameOfItem,
                Value = x.ProcurementId
            }).ToList();
            return selectModels;
        }
    }
}
