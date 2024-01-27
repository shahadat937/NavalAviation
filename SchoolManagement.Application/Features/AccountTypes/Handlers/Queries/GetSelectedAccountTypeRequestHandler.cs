using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.AccountTypes.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.AccountTypes.Handlers.Queries
{
    public class GetSelectedAccountTypeRequestHandler : IRequestHandler<GetSelectedAccountTypeRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<AccountType> _AccountTypeRepository;


        public GetSelectedAccountTypeRequestHandler(ISchoolManagementRepository<AccountType> AccountTypeRepository)
        {
            _AccountTypeRepository = AccountTypeRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedAccountTypeRequest request, CancellationToken cancellationToken)
        {
            ICollection<AccountType> codeValues = await _AccountTypeRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.AccoutType,
                Value = x.AccountTypeId
            }).ToList();
            return selectModels;
        }
    }
}
