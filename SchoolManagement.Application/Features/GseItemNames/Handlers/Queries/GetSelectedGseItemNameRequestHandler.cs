using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.GseItemNames.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.GseItemNames.Handlers.Queries
{
    public class GetSelectedGseItemNameRequestHandler : IRequestHandler<GetSelectedGseItemNameRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<GseItemName> _GseItemNameRepository;


        public GetSelectedGseItemNameRequestHandler(ISchoolManagementRepository<GseItemName> GseItemNameRepository)
        {
            _GseItemNameRepository = GseItemNameRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedGseItemNameRequest request, CancellationToken cancellationToken)
        {
            ICollection<GseItemName> codeValues = await _GseItemNameRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.ItemName,
                Value = x.GseItemNameId
            }).ToList();
            return selectModels;
        }
    }
}
