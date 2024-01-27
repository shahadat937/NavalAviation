using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.AcctStores.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.AcctStores.Handlers.Queries
{
    public class GetSelectedAcctStoreRequestHandler : IRequestHandler<GetSelectedAcctStoreRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<AcctStore> _AcctStoreRepository;


        public GetSelectedAcctStoreRequestHandler(ISchoolManagementRepository<AcctStore> AcctStoreRepository)
        {
            _AcctStoreRepository = AcctStoreRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedAcctStoreRequest request, CancellationToken cancellationToken)
        {
            ICollection<AcctStore> codeValues = await _AcctStoreRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.AcctStoreId
            }).ToList();
            return selectModels;
        }
    }
}
