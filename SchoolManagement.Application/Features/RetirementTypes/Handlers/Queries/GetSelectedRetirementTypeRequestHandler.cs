using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.RetirementTypes.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.RetirementTypes.Handlers.Queries
{
    public class GetSelectedRetirementTypeRequestHandler : IRequestHandler<GetSelectedRetirementTypeRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<RetirementType> _RetirementTypeRepository;


        public GetSelectedRetirementTypeRequestHandler(ISchoolManagementRepository<RetirementType> RetirementTypeRepository)
        {
            _RetirementTypeRepository = RetirementTypeRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedRetirementTypeRequest request, CancellationToken cancellationToken)
        {
            ICollection<RetirementType> codeValues = await _RetirementTypeRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.RetirementTypeId
            }).ToList();
            return selectModels;
        }
    }
}
