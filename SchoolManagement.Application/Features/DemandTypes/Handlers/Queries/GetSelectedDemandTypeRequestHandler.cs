using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.DemandTypes.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.DemandTypes.Handlers.Queries
{
    public class GetSelectedDemandTypeRequestHandler : IRequestHandler<GetSelectedDemandTypeRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<DemandType> _DemandTypeRepository;


        public GetSelectedDemandTypeRequestHandler(ISchoolManagementRepository<DemandType> DemandTypeRepository)
        {
            _DemandTypeRepository = DemandTypeRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedDemandTypeRequest request, CancellationToken cancellationToken)
        {
            ICollection<DemandType> codeValues = await _DemandTypeRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.DemandTypeId
            }).ToList();
            return selectModels;
        }
    }
}
