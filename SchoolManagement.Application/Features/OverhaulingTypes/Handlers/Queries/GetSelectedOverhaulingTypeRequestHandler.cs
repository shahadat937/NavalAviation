using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.OverhaulingTypes.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.OverhaulingTypes.Handlers.Queries
{
    public class GetSelectedOverhaulingTypeRequestHandler : IRequestHandler<GetSelectedOverhaulingTypeRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<OverhaulingType> _OverhaulingTypeRepository;


        public GetSelectedOverhaulingTypeRequestHandler(ISchoolManagementRepository<OverhaulingType> OverhaulingTypeRepository)
        {
            _OverhaulingTypeRepository = OverhaulingTypeRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedOverhaulingTypeRequest request, CancellationToken cancellationToken)
        {
            ICollection<OverhaulingType> codeValues = await _OverhaulingTypeRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.OverhaulingTypeId
            }).ToList();
            return selectModels;
        }
    }
}
