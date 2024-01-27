using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.TrainingCrew;
using SchoolManagement.Application.Features.TrainingCrews.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.TrainingCrews.Handlers.Queries
{
    public class GetTrainingCrewDetailRequestHandler : IRequestHandler<GetTrainingCrewDetailRequest, TrainingCrewDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<TrainingCrew> _TrainingCrewRepository;
        public GetTrainingCrewDetailRequestHandler(ISchoolManagementRepository<TrainingCrew> TrainingCrewRepository, IMapper mapper)
        {
            _TrainingCrewRepository = TrainingCrewRepository;
            _mapper = mapper;
        }
        public async Task<TrainingCrewDto> Handle(GetTrainingCrewDetailRequest request, CancellationToken cancellationToken)
        {
        //var TrainingCrew = await _TrainingCrewRepository.Get(request.TrainingCrewId);
        //return _mapper.Map<TrainingCrewDto>(TrainingCrew);
        var TrainingCrew = _TrainingCrewRepository.FinedOneInclude(x => x.TrainingCrewId == request.TrainingCrewId, "DepartmentName", "Rank", "SailorRank");
        return _mapper.Map<TrainingCrewDto>(TrainingCrew);
        }
    }
}
