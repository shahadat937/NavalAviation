using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.Demands.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.Demands.Handlers.Queries
{
    public class GetSelectedPartNoFromDemandForUpdateByDepartmentNameRequestHandler : IRequestHandler<GetSelectedPartNoFromDemandForUpdateByDepartmentNameRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<Demand> _DemandRepository;


        public GetSelectedPartNoFromDemandForUpdateByDepartmentNameRequestHandler(ISchoolManagementRepository<Demand> DemandRepository)
        {
            _DemandRepository = DemandRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedPartNoFromDemandForUpdateByDepartmentNameRequest request, CancellationToken cancellationToken)
        {
            IQueryable<Demand> Demands = _DemandRepository.FilterWithInclude((x => x.IsActive && x.DepartmentNameId==request.DepartmentNameId && x.SparesCategoryId == request.SparesCategoryId), "ItemDetail");
            List<SelectedModel> selectModels = Demands.Select(x => new SelectedModel 
            {
                Text = x.ItemDetail.PartNo +" - "+ x.ItemDetail.NameOfItem,
                Value = x.DemandId
            }).ToList();
            return selectModels;
        }
    }
}
