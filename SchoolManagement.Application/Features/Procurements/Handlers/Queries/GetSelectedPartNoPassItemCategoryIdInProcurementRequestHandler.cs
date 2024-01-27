using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.Procurements.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.Procurements.Handlers.Queries
{
    public class GetSelectedPartNoPassItemCategoryIdInProcurementRequestHandler : IRequestHandler<GetSelectedPartNoPassItemCategoryIdInProcurementRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<Procurement> _ProcurementRepository;


        public GetSelectedPartNoPassItemCategoryIdInProcurementRequestHandler(ISchoolManagementRepository<Procurement> ProcurementRepository)
        {
            _ProcurementRepository = ProcurementRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedPartNoPassItemCategoryIdInProcurementRequest request, CancellationToken cancellationToken)
        {
            IQueryable<Procurement> Procurements = _ProcurementRepository.FilterWithInclude((x => x.IsActive && x.ItemDetailId == request.ItemDetailId ));
            List<SelectedModel> selectModels = Procurements.Select(x => new SelectedModel 
            {
                Text = x.ItemDetail.ItemCategoryId,
                Value = x.ProcurementId
            }).ToList();
            return selectModels;
        }
    }
}
