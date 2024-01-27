using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Attendence.Validators;
using SchoolManagement.Application.Features.Attendences.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.Attendences.Handlers.Commands
{
    public class CreateAttendenceCommandHandler : IRequestHandler<CreateAttendenceCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateAttendenceCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateAttendenceCommand request, CancellationToken cancellationToken)
        {
          var response = new BaseCommandResponse();

          var attendanceList = request.AttendenceDto;

          foreach (var item in attendanceList.TraineeListForm)
          {
            if (item.AttendanceStatus == null)
            {
              item.AttendanceStatus = false;
            }
          }

          var attendances = attendanceList.TraineeListForm.Select(x => new Attendence()
          {
              DepartmentNameId = x.DepartmentNameId,
              AttendanceStatus = x.AttendanceStatus,
              TrainingCrewId = x.TrainingCrewId,
              OfficersStatusId = x.OfficersStatusId,
              AttendenceDate = DateTime.Now
          });

          await _unitOfWork.Repository<Attendence>().AddRangeAsync(attendances);
          await _unitOfWork.Save();
      
          response.Success = true;
          response.Message = "Creation Successful";
          return response;
        }
    }
}
