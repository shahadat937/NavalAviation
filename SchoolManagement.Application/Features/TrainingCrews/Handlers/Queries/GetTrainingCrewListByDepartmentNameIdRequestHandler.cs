using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.TrainingCrew;
using SchoolManagement.Application.Features.TrainingCrews.Requests.Queries;

namespace SchoolManagement.Application.Features.TrainingCrews.Handlers.Queries
{
    public class GetTrainingCrewListByDepartmentNameIdRequestHandler : IRequestHandler<GetTrainingCrewListByDepartmentNameIdRequest, List<TrainingCrewDto>>
    {
        private readonly ISchoolManagementRepository<TrainingCrew> _TrainingCrewRepository;

        private readonly IMapper _mapper;
        public GetTrainingCrewListByDepartmentNameIdRequestHandler(ISchoolManagementRepository<TrainingCrew> TrainingCrewRepository, IMapper mapper)
        {
            _TrainingCrewRepository = TrainingCrewRepository;
            _mapper = mapper;
        }
    public async Task<List<TrainingCrewDto>> Handle(GetTrainingCrewListByDepartmentNameIdRequest request, CancellationToken cancellationToken)
    {


      IQueryable<TrainingCrew> TrainingCrews = _TrainingCrewRepository.FilterWithInclude(x => (x.Pno.Contains(request.Text) || x.Name.Contains(request.Text) || String.IsNullOrEmpty(request.Text)), "Rank", "OfficersStatus", "DepartmentName", "SailorRank").Where(x => x.DepartmentNameId == (request.DepartmentNameId != 0 ? request.DepartmentNameId : x.DepartmentNameId) && x.EmployeeTypeId == request.EmployeeTypeId).OrderBy(x => x.Pno);
      var totalCount = TrainingCrews.Count();

      var TrainingCrewDtos = _mapper.Map<List<TrainingCrewDto>>(TrainingCrews);

      return TrainingCrewDtos;
    }

    //public async Task<List<TrainingCrewDto>> Handle(GetTrainingCrewListByDepartmentNameIdRequest request, CancellationToken cancellationToken)
    //{
    //    IQueryable<TrainingCrew> TrainingCrews = _TrainingCrewRepository.FilterWithInclude(x => x.DepartmentNameId == (request.DepartmentNameId != 0 ? request.DepartmentNameId : x.DepartmentNameId) && x.EmployeeTypeId == request.EmployeeTypeId , "Rank", "OfficersStatus", "DepartmentName", "SailorRank").OrderBy(x=>x.Pno);

    //    var TrainingCrewDtos = _mapper.Map<List<TrainingCrewDto>>(TrainingCrews);

    //    return TrainingCrewDtos;
    //}

  }
}
