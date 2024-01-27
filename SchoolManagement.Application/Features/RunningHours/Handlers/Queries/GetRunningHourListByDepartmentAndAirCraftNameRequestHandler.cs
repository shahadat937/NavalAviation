using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.RunningHour;
using SchoolManagement.Application.Features.RunningHours.Requests.Queries;

namespace SchoolManagement.Application.Features.RunningHours.Handlers.Queries
{
    public class GetRunningHourListByDepartmentAndAirCraftNameRequestHandler : IRequestHandler<GetRunningHourListByDepartmentAndAirCraftNameRequest, List<RunningHourDto>>
    {
        private readonly ISchoolManagementRepository<RunningHour> _RunningHourRepository;

        private readonly IMapper _mapper;
        public GetRunningHourListByDepartmentAndAirCraftNameRequestHandler(ISchoolManagementRepository<RunningHour> RunningHourRepository, IMapper mapper)
        {
            _RunningHourRepository = RunningHourRepository;
            _mapper = mapper;
        }

        public async Task<List<RunningHourDto>> Handle(GetRunningHourListByDepartmentAndAirCraftNameRequest request, CancellationToken cancellationToken)
        {
            IQueryable<RunningHour> RunningHours = _RunningHourRepository.FilterWithInclude(x => x.AirCraftNameId == request.AirCraftNameId && x.DepartmentNameId == request.DepartmentNameId , "AirCraftName");

            var RunningHourDtos = _mapper.Map<List<RunningHourDto>>(RunningHours);

            return RunningHourDtos;
        }

    }
}
