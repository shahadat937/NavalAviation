using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.TrainingCrew;
using SchoolManagement.Application.Features.TrainingCrews.Requests.Queries;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.TrainingCrews.Handlers.Queries
{
    public class GetTrainingCrewListByDepartmentNameIdSailorRequestHandler : IRequestHandler<GetTrainingCrewListByDepartmentNameIdSailorRequest, List<TrainingCrewDto>>
    {
        private readonly ISchoolManagementRepository<TrainingCrew> _TrainingCrewRepository;

        private readonly IMapper _mapper;
        public GetTrainingCrewListByDepartmentNameIdSailorRequestHandler(ISchoolManagementRepository<TrainingCrew> TrainingCrewRepository, IMapper mapper)
        {
            _TrainingCrewRepository = TrainingCrewRepository;
            _mapper = mapper;
        }
    public async Task<List<TrainingCrewDto>> Handle(GetTrainingCrewListByDepartmentNameIdSailorRequest request, CancellationToken cancellationToken)
    {


      IQueryable<TrainingCrew> TrainingCrews = _TrainingCrewRepository.FilterWithInclude(x => (x.Pno.Contains(request.Text) || x.Name.Contains(request.Text) || String.IsNullOrEmpty(request.Text)), "Rank", "OfficersStatus", "DepartmentName", "SailorRank").Where(x => x.DepartmentNameId == (request.DepartmentNameId != 0 ? request.DepartmentNameId : x.DepartmentNameId) && x.EmployeeTypeId == request.EmployeeTypeId).OrderBy(x =>x.Pno);
      var totalCount = TrainingCrews.Count();
      //var TrainingCrew = TrainingCrews.OrderBy(x => Convert.ToInt32(x.Pno));
      //TrainingCrews = TrainingCrews.OrderBy(x => x.SailorRank.Remarks).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);
      //.OrderBy(x => x.SailorRank.Remarks);
      var TrainingCrewDtos = _mapper.Map<List<TrainingCrewDto>>(TrainingCrews);
      //var result = new PagedResult<TrainingCrewDto>(TrainingCrewDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

      return TrainingCrewDtos;
    }

    //public async Task<List<TrainingCrewDto>> Handle(GetTrainingCrewListByDepartmentNameIdSailorRequest request, CancellationToken cancellationToken)
    //{
    //    IQueryable<TrainingCrew> TrainingCrews = _TrainingCrewRepository.FilterWithInclude(x => x.DepartmentNameId == (request.DepartmentNameId != 0 ? request.DepartmentNameId : x.DepartmentNameId) && x.EmployeeTypeId == request.EmployeeTypeId , "Rank", "OfficersStatus", "DepartmentName", "SailorRank").OrderBy(x=>x.SailorRank.Remarks);

    //    var TrainingCrewDtos = _mapper.Map<List<TrainingCrewDto>>(TrainingCrews);

    //    return TrainingCrewDtos;
    //}

  }
}
