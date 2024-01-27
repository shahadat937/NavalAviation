using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.Procurements.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.Procurements.Handlers.Queries
{
    public class GetSelectedPartNoFromProcurementByDepartmentNameRequestHandler : IRequestHandler<GetSelectedPartNoFromProcurementByDepartmentNameRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<Procurement> _ProcurementRepository;


        public GetSelectedPartNoFromProcurementByDepartmentNameRequestHandler(ISchoolManagementRepository<Procurement> ProcurementRepository)
        {
            _ProcurementRepository = ProcurementRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedPartNoFromProcurementByDepartmentNameRequest request, CancellationToken cancellationToken)
        {
            IQueryable<Procurement> Procurements = _ProcurementRepository.FilterWithInclude((x => x.IsActive && x.DepartmentNameId==request.DepartmentNameId && x.SparesCategoryId == request.SparesCategoryId && x.ProcurementCompleteStatus == 0), "ItemDetail");
            List<SelectedModel> selectModels = Procurements.Select(x => new SelectedModel 
            {
                Text = x.ItemDetail.PartNo + " - " + x.ItemDetail.NameOfItem,
                Value = x.ProcurementId, 
            }).ToList();
            return selectModels;
        }
    }
}
