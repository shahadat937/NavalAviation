using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.TrainingCrews.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.TrainingCrews.Handlers.Queries
{
    public class GetSelectedTrainingCrewRequestHandler : IRequestHandler<GetSelectedTrainingCrewRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<TrainingCrew> _TrainingCrewRepository;


        public GetSelectedTrainingCrewRequestHandler(ISchoolManagementRepository<TrainingCrew> TrainingCrewRepository)
        {
            _TrainingCrewRepository = TrainingCrewRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedTrainingCrewRequest request, CancellationToken cancellationToken)
        {
            ICollection<TrainingCrew> codeValues = await _TrainingCrewRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Pno + "_" + x.Name,
                Value = x.TrainingCrewId
            }).ToList();
            return selectModels;
        }

    }
}
