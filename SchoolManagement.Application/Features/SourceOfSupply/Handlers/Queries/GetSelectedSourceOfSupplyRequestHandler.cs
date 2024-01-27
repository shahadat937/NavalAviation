using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.SourceOfSupplys.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.SourceOfSupplys.Handlers.Queries
{
    public class GetSelectedSourceOfSupplyRequestHandler : IRequestHandler<GetSelectedSourceOfSupplyRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<SourceOfSupply> _SourceOfSupplyRepository;


        public GetSelectedSourceOfSupplyRequestHandler(ISchoolManagementRepository<SourceOfSupply> SourceOfSupplyRepository)
        {
            _SourceOfSupplyRepository = SourceOfSupplyRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedSourceOfSupplyRequest request, CancellationToken cancellationToken)
        {
            ICollection<SourceOfSupply> codeValues = await _SourceOfSupplyRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.SourceOfSupplyId
            }).ToList();
            return selectModels;
        }
    }
}
