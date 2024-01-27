using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.ServiceLifeTypes.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.ServiceLifeTypes.Handlers.Queries
{
    public class GetSelectedServiceLifeTypeRequestHandler : IRequestHandler<GetSelectedServiceLifeTypeRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<ServiceLifeType> _ServiceLifeTypeRepository;


        public GetSelectedServiceLifeTypeRequestHandler(ISchoolManagementRepository<ServiceLifeType> ServiceLifeTypeRepository)
        {
            _ServiceLifeTypeRepository = ServiceLifeTypeRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedServiceLifeTypeRequest request, CancellationToken cancellationToken)
        {
            ICollection<ServiceLifeType> codeValues = await _ServiceLifeTypeRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.ServiceLifeTypeId
            }).ToList();
            return selectModels;
        }
    }
}
