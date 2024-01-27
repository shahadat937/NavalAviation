using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.CodeValueTypes.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.CodeValueTypes.Handlers.Queries
{
    public class GetSelectedCodeValueTypeRequestHandler : IRequestHandler<GetSelectedCodeValueTypeRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<CodeValueType> _CodeValueTypeRepository;


        public GetSelectedCodeValueTypeRequestHandler(ISchoolManagementRepository<CodeValueType> CodeValueTypeRepository)
        {
            _CodeValueTypeRepository = CodeValueTypeRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedCodeValueTypeRequest request, CancellationToken cancellationToken)
        {
            ICollection<CodeValueType> codeValues = await _CodeValueTypeRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Type,
                Value = x.CodeValueTypeId
            }).ToList();
            return selectModels;
        }
    }
}
