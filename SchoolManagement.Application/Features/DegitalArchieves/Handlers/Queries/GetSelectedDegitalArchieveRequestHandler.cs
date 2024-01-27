using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.DegitalArchieves.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.DegitalArchieves.Handlers.Queries
{
    public class GetSelectedDegitalArchieveRequestHandler : IRequestHandler<GetSelectedDegitalArchieveRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<DegitalArchieve> _DegitalArchieveRepository;


        public GetSelectedDegitalArchieveRequestHandler(ISchoolManagementRepository<DegitalArchieve> DegitalArchieveRepository)
        {
            _DegitalArchieveRepository = DegitalArchieveRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedDegitalArchieveRequest request, CancellationToken cancellationToken)
        {
            ICollection<DegitalArchieve> codeValues = await _DegitalArchieveRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.DegitalArchieveId
            }).ToList();
            return selectModels;
        }
    }
}
