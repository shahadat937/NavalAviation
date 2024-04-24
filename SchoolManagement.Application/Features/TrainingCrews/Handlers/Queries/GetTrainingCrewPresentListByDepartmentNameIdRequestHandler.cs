using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.TrainingCrew;
using SchoolManagement.Application.Features.TrainingCrews.Requests.Queries;
using System.Security.Cryptography.X509Certificates;

namespace SchoolManagement.Application.Features.TrainingCrews.Handlers.Queries
{
    public class GetTrainingCrewPresentListByDepartmentNameIdRequestHandler : IRequestHandler<GetTrainingCrewPresentListByDepartmentNameIdRequest, List<TrainingCrewDto>>
    {
        private readonly ISchoolManagementRepository<TrainingCrew> _TrainingCrewRepository;

        private readonly IMapper _mapper;
        public GetTrainingCrewPresentListByDepartmentNameIdRequestHandler(ISchoolManagementRepository<TrainingCrew> TrainingCrewRepository, IMapper mapper)
        {
            _TrainingCrewRepository = TrainingCrewRepository;
            _mapper = mapper;
        }

        public async Task<List<TrainingCrewDto>> Handle(GetTrainingCrewPresentListByDepartmentNameIdRequest request, CancellationToken cancellationToken)
        {
             var TrainingCrewDtos = new List<TrainingCrewDto>();

            if (request.DepartmentNameId == 0)
            {
              IQueryable<TrainingCrew> TrainingCrews = _TrainingCrewRepository.FilterWithInclude(x => x.OfficersStatusId != 4 && x.PresentBilletId == 1, "Rank", "OfficersStatus", "DepartmentName", "SailorRank").OrderBy(x => x.EmployeeTypeId).ThenBy(x => x.Pno);
              TrainingCrewDtos = _mapper.Map<List<TrainingCrewDto>>(TrainingCrews);
            }
            else
            {
              IQueryable<TrainingCrew> TrainingCrews = _TrainingCrewRepository.FilterWithInclude(x => x.DepartmentNameId == request.DepartmentNameId && x.OfficersStatusId != 4, "Rank", "OfficersStatus", "DepartmentName", "SailorRank").OrderBy(x => x.EmployeeTypeId).ThenBy(x => x.Pno);

              TrainingCrewDtos = _mapper.Map<List<TrainingCrewDto>>(TrainingCrews);
            }
            return TrainingCrewDtos;
        }

    }
}
