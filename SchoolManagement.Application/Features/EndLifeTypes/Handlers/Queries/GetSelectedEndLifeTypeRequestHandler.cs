using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.EndLifeTypes.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.EndLifeTypes.Handlers.Queries
{
    public class GetSelectedEndLifeTypeRequestHandler : IRequestHandler<GetSelectedEndLifeTypeRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<EndLifeType> _EndLifeTypeRepository;


        public GetSelectedEndLifeTypeRequestHandler(ISchoolManagementRepository<EndLifeType> EndLifeTypeRepository)
        {
            _EndLifeTypeRepository = EndLifeTypeRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedEndLifeTypeRequest request, CancellationToken cancellationToken)
        {
            ICollection<EndLifeType> codeValues = await _EndLifeTypeRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.EndLifeTypeId
            }).ToList();
            return selectModels;
        }
    }
}
