using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.AirCraftFlying;
using SchoolManagement.Application.Features.AirCraftFlyings.Requests.Queries;
using System.Globalization;
using SchoolManagement.Application.Helpers;

namespace SchoolManagement.Application.Features.AirCraftFlyings.Handlers.Queries
{
    public class GetAirCraftFlyingListForDashboardRequestHandler : IRequestHandler<GetAirCraftFlyingListForDashboardRequest, List<AirCraftFlyingDto>>
    {
        private readonly ISchoolManagementRepository<AirCraftFlying> _AirCraftFlyingRepository;

        private readonly IMapper _mapper;
        public GetAirCraftFlyingListForDashboardRequestHandler(ISchoolManagementRepository<AirCraftFlying> AirCraftFlyingRepository, IMapper mapper)
        {
            _AirCraftFlyingRepository = AirCraftFlyingRepository;
            _mapper = mapper;
        }

        public async Task<List<AirCraftFlyingDto>> Handle(GetAirCraftFlyingListForDashboardRequest request, CancellationToken cancellationToken)
        {
            IQueryable<AirCraftFlying> AirCraftFlyings = _AirCraftFlyingRepository.FilterWithInclude(x => x.IsActive==true && x.DepartmentNameId == (request.DepartmentId != 0 ? request.DepartmentId : x.DepartmentNameId) && x.Date.Value.Date == DateTime.Today, "DepartmentName", "AirCraftName");
            var totalCount = AirCraftFlyings.Count();  
            AirCraftFlyings = AirCraftFlyings.OrderByDescending(x => x.Date); 
            var AirCraftFlyingDtos = _mapper.Map<List<AirCraftFlyingDto>>(AirCraftFlyings);

            var aircraftFlyingDto = new List<AirCraftFlyingDto>();
            var aircraftFlyingDtoReturn = new List<AirCraftFlyingDto>();

           foreach (var item in AirCraftFlyingDtos)
            {
              // Startup Time Conversion

              string input = item.StartUp;

              if(!(String.IsNullOrEmpty(input)))
              {       
                var timeFromInput = DateTime.ParseExact(input, "H:m", null, DateTimeStyles.None);

                string timeIn12HourFormatForDisplay = timeFromInput.ToString("hh:mm tt",CultureInfo.InvariantCulture);


          //Time Calculation
                
                TimeSpan currentTime =TimeSpan.Parse(DateTime.Now.ToString("HH:mm"));
                TimeSpan startup = TimeSpan.Parse(item.StartUp);
                TimeSpan endTime = TimeSpan.Parse(item.Endurance);

                // Running Hour and Rest Hour Calculation
                  var runningTime = currentTime - startup;
                  var restTime = endTime - currentTime;
                  item.RunningHour = runningTime;
                  item.RestHour = restTime;

                // Running hour and rest hour percentage
                  var duration = endTime - startup;
                  var runningPercentage = (runningTime * 100) / duration;

                  var restPercentage = (100 - runningPercentage);

                  item.RunningPercentage = Math.Round(runningPercentage,0);
                  item.RestPercentage = Math.Round(restPercentage,0);
                  item.StartUp = timeIn12HourFormatForDisplay;

                  aircraftFlyingDto.Add(item);
                }

                
            }
            //aircraftFlyingDtoReturn = aircraftFlyingDto.Where(x=>x.RunningPercentage>=0 && x.RunningPercentage <=100 && x.RestPercentage>=0 && x.RunningPercentage>=0).ToList();
            return aircraftFlyingDto;
        }

    }
}
