using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.MaintenanceSchedule;
using SchoolManagement.Application.Features.MaintenanceSchedules.Requests.Queries;

namespace SchoolManagement.Application.Features.MaintenanceSchedules.Handlers.Queries
{
    public class GetMaintenanceScheduleListByDateRangeRequestHandler : IRequestHandler<GetMaintenanceScheduleListByDateRangeRequest, List<MaintenanceScheduleListDto>>
    {
        private readonly ISchoolManagementRepository<MaintenanceSchedule> _MaintenanceScheduleRepository;
        private readonly ISchoolManagementRepository<MaintenancePlanning> _MaintenancePlanningRepository;

        private readonly IMapper _mapper;
        public GetMaintenanceScheduleListByDateRangeRequestHandler(ISchoolManagementRepository<MaintenanceSchedule> MaintenanceScheduleRepository, ISchoolManagementRepository<MaintenancePlanning> MaintenancePlanningRepository, IMapper mapper)
        {
            _MaintenanceScheduleRepository = MaintenanceScheduleRepository;
            _MaintenancePlanningRepository = MaintenancePlanningRepository;
            _mapper = mapper;
        }

        public async Task<List<MaintenanceScheduleListDto>> Handle(GetMaintenanceScheduleListByDateRangeRequest request, CancellationToken cancellationToken)
        {
            var maintenancePlanning = _MaintenancePlanningRepository.FinedOneInclude(x => x.MaintenancePlanningId == request.MaintenancePlanningId);

            if(maintenancePlanning.MaintenanceCategoryId == 2 || maintenancePlanning.MaintenanceCategoryId == 36)
            {
              DateTime startDate, endDate;
              startDate = Convert.ToDateTime(maintenancePlanning.LastInspDate);
              endDate = startDate.AddDays(Convert.ToDouble(maintenancePlanning.ReportCalculationDay));

      
              List<MaintenanceScheduleListDto> maintenanceScheduleList = new List<MaintenanceScheduleListDto>();

              int i = 1;
              for (startDate = Convert.ToDateTime(maintenancePlanning.LastInspDate); startDate <= Convert.ToDateTime(endDate); startDate = startDate.AddDays(request.DiffBetween))
              {
                var maintanenceSchedule = new MaintenanceScheduleListDto()
                {
                  Serial = i,
                  Name = Convert.ToString("No. "+ i + " Schedule"),
                  LastInspDate = startDate.AddDays(request.DiffBetween)
                };

                i++;
              maintenanceScheduleList.Add(maintanenceSchedule);
              }
              return maintenanceScheduleList;
            }else if(maintenancePlanning.MaintenanceCategoryId == 3 || maintenancePlanning.MaintenanceCategoryId == 37)
            {

              double? startOhTime, endOhTime;
              startOhTime = Convert.ToDouble(maintenancePlanning.LastInspectionOH);
              endOhTime = startOhTime + (Convert.ToDouble(maintenancePlanning.ReportCalculationDay));

      
              List<MaintenanceScheduleListDto> maintenanceScheduleList = new List<MaintenanceScheduleListDto>();

              int i = 1;
              for (startOhTime = Convert.ToDouble(maintenancePlanning.LastInspectionOH); startOhTime <= endOhTime; startOhTime += request.DiffBetween)
              {
                var maintanenceSchedule = new MaintenanceScheduleListDto()
                {
                  Serial = i,
                  Name = Convert.ToString("No. "+ i + " Schedule"),
                  LastInspectionOH = Math.Round((decimal)startOhTime, 2).ToString()
                };

                i++;
              maintenanceScheduleList.Add(maintanenceSchedule);
              }
              return maintenanceScheduleList;
            }else if(maintenancePlanning.MaintenanceCategoryId == 25 || maintenancePlanning.MaintenanceCategoryId == 38)
            {

              double? startFhTime, endFhTime;
              startFhTime = Convert.ToDouble(maintenancePlanning.LastInspectionFH);
              endFhTime = startFhTime + (Convert.ToDouble(maintenancePlanning.ReportCalculationDay));

      
              List<MaintenanceScheduleListDto> maintenanceScheduleList = new List<MaintenanceScheduleListDto>();

              int i = 1;
              for (startFhTime = Convert.ToDouble(maintenancePlanning.LastInspectionFH); startFhTime <= endFhTime; startFhTime += request.DiffBetween)
              {
                var maintanenceSchedule = new MaintenanceScheduleListDto()
                {
                  Serial = i,
                  Name = Convert.ToString("No. "+ i + " Schedule"),
                  LastInspectionFH =  Math.Round((decimal)startFhTime, 2).ToString()
                };

                i++;
              maintenanceScheduleList.Add(maintanenceSchedule);
              }
              return maintenanceScheduleList;
            }
             return null;
        }

    }
}
