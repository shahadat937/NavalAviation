using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.Castes.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.Castes.Handlers.Queries
{
    public class GetSelectedCasteByTypeHandler : IRequestHandler<GetSelectedCasteByReligion, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<Caste> _CasteRepository;


        public GetSelectedCasteByTypeHandler(ISchoolManagementRepository<Caste> CasteRepository)
        {
            _CasteRepository = CasteRepository;           
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedCasteByReligion request, CancellationToken cancellationToken)
        {
            ICollection<Caste> Castes = await _CasteRepository.FilterAsync(x =>x.ReligionId == request.ReligionId);
            List<SelectedModel> selectModels = Castes.Select(x => new SelectedModel
            {
                Text = x.CastName,
                Value = x.CasteId
            }).ToList();
            return selectModels;
        }
    }
}
