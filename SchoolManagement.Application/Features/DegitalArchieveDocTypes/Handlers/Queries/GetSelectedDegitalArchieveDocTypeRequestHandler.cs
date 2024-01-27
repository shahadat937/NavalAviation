using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.DegitalArchieveDocTypes.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.DegitalArchieveDocTypes.Handlers.Queries
{
    public class GetSelectedDegitalArchieveDocTypeRequestHandler : IRequestHandler<GetSelectedDegitalArchieveDocTypeRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<DegitalArchieveDocType> _DegitalArchieveDocTypeRepository;


        public GetSelectedDegitalArchieveDocTypeRequestHandler(ISchoolManagementRepository<DegitalArchieveDocType> DegitalArchieveDocTypeRepository)
        {
            _DegitalArchieveDocTypeRepository = DegitalArchieveDocTypeRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedDegitalArchieveDocTypeRequest request, CancellationToken cancellationToken)
        {
            ICollection<DegitalArchieveDocType> codeValues = await _DegitalArchieveDocTypeRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.DegitalArchieveDocTypeId
            }).ToList();
            return selectModels;
        }
    }
}
