using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.DailyAirworthinessFrom;
using SchoolManagement.Application.Features.DailyAirworthinessFroms.Requests.Queries;

namespace SchoolManagement.Application.Features.DailyAirworthinessFroms.Handlers.Queries
{
    public class GetDailyAirworthinessFromListByDepartmentNameIdRequestHandler : IRequestHandler<GetDailyAirworthinessFromListByDepartmentNameIdRequest, List<DailyAirworthinessFromDto>>
    {
        private readonly ISchoolManagementRepository<DailyAirworthinessFrom> _DailyAirworthinessFromRepository;

        private readonly IMapper _mapper;
        public GetDailyAirworthinessFromListByDepartmentNameIdRequestHandler(ISchoolManagementRepository<DailyAirworthinessFrom> DailyAirworthinessFromRepository, IMapper mapper)
        {
            _DailyAirworthinessFromRepository = DailyAirworthinessFromRepository;
            _mapper = mapper;
        }

        public async Task<List<DailyAirworthinessFromDto>> Handle(GetDailyAirworthinessFromListByDepartmentNameIdRequest request, CancellationToken cancellationToken)
        {
            IQueryable<DailyAirworthinessFrom> DailyAirworthinessFroms = _DailyAirworthinessFromRepository.FilterWithInclude(x => x.DepartmentNameId == request.DepartmentNameId && x.DocType == request.DocType , "DepartmentName", "AirCraftName", "DailyAirworthinessFromCategory");
            var totalCount = DailyAirworthinessFroms.Count();
            DailyAirworthinessFroms = DailyAirworthinessFroms.OrderByDescending(x => x.DailyAirworthinessFromId);
            var DailyAirworthinessFromDtos = _mapper.Map<List<DailyAirworthinessFromDto>>(DailyAirworthinessFroms);

            return DailyAirworthinessFromDtos;
        }

    }
}
