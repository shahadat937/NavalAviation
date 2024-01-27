using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.PresentStates.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.PresentStates.Handlers.Queries
{
    public class GetSelectedPresentStateRequestHandler : IRequestHandler<GetSelectedPresentStateRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<PresentState> _PresentStateRepository;


        public GetSelectedPresentStateRequestHandler(ISchoolManagementRepository<PresentState> PresentStateRepository)
        {
            _PresentStateRepository = PresentStateRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedPresentStateRequest request, CancellationToken cancellationToken)
        {
            ICollection<PresentState> codeValues = await _PresentStateRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.PresentStateId
            }).ToList();
            return selectModels;
        }
    }
}
