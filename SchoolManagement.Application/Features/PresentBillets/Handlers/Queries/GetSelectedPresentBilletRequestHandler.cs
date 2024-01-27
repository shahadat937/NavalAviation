using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.PresentBillets.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.PresentBillets.Handlers.Queries
{
    public class GetSelectedPresentBilletRequestHandler : IRequestHandler<GetSelectedPresentBilletRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<PresentBillet> _PresentBilletRepository;


        public GetSelectedPresentBilletRequestHandler(ISchoolManagementRepository<PresentBillet> PresentBilletRepository)
        {
            _PresentBilletRepository = PresentBilletRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedPresentBilletRequest request, CancellationToken cancellationToken)
        {
            ICollection<PresentBillet> codeValues = await _PresentBilletRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.PresentBilletName,
                Value = x.PresentBilletId
            }).ToList();
            return selectModels;
        }
    }
}
