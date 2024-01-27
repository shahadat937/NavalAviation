using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.TrainingCrews.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TrainingCrews.Handlers.Queries
{
    public class GetAutoCompletePnoForIssueRegisterRequestHandler : IRequestHandler<GetAutoCompletePnoForIssueRegisterRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<TrainingCrew> _TrainingCrewRepository; 
        public GetAutoCompletePnoForIssueRegisterRequestHandler(ISchoolManagementRepository<TrainingCrew> TrainingCrewRepository)
        {
            _TrainingCrewRepository = TrainingCrewRepository;
        }
          
        public async Task<List<SelectedModel>> Handle(GetAutoCompletePnoForIssueRegisterRequest request, CancellationToken cancellationToken)
        {
            IQueryable<TrainingCrew> TrainingCrews = _TrainingCrewRepository.FilterWithInclude((x => x.IsActive && x.Pno.Contains(request.Pno)), "Rank", "SailorRank");
            List<SelectedModel> selectModels = TrainingCrews.Select(x => new SelectedModel
            {
              Text = x.Pno + " - " + x.Rank.Name + "  " + x.SailorRank.Name + "  " + x.Name ,
              Value = x.TrainingCrewId
            }).ToList();
            return selectModels;
            //ICollection<TrainingCrew> trainingCrews = await _TrainingCrewRepository.FilterAsync(x => x.IsActive && x.Pno.Contains(request.Pno));
            //var selectModels = trainingCrews.Select(x => new SelectedModel
            //{ 
            //    Text = x.Pno + "_" + x.Name,
            //    Value = x.TrainingCrewId
            //}).ToList();
            //return selectModels;
        }
    }
}
