using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.Demands.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.Demands.Handlers.Queries
{
    public class GetSelectedPartNoFromDemandByDepartmentNameRequestHandler : IRequestHandler<GetSelectedPartNoFromDemandByDepartmentNameRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<Demand> _DemandRepository;


        public GetSelectedPartNoFromDemandByDepartmentNameRequestHandler(ISchoolManagementRepository<Demand> DemandRepository)
        {
            _DemandRepository = DemandRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedPartNoFromDemandByDepartmentNameRequest request, CancellationToken cancellationToken)
        {
            IQueryable<Demand> Demands = _DemandRepository.FilterWithInclude((x => x.IsActive && x.DepartmentNameId==request.DepartmentNameId && x.SparesCategoryId == request.SparesCategoryId && x.DemandCompleteStatus == 0), "ItemDetail");
            List<SelectedModel> selectModels = Demands.Select(x => new SelectedModel 
            {
                Text = x.ItemDetail.PartNo +" - "+ x.ItemDetail.NameOfItem,
                Value = x.DemandId
            }).ToList();
            return selectModels;
        }
    }
}
