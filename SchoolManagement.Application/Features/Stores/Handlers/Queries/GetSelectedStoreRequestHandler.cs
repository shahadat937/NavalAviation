using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.Stores.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.Stores.Handlers.Queries
{
    public class GetSelectedStoreRequestHandler : IRequestHandler<GetSelectedStoreRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<Store> _StoreRepository;


        public GetSelectedStoreRequestHandler(ISchoolManagementRepository<Store> StoreRepository)
        {
            _StoreRepository = StoreRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedStoreRequest request, CancellationToken cancellationToken)
        {
            ICollection<Store> codeValues = await _StoreRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.StoreId
            }).ToList();
            return selectModels;
        }
    }
}
