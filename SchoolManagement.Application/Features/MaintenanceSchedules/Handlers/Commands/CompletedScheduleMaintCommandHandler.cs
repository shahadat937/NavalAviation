using System;
using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.MaintenanceSchedule.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.MaintenanceSchedules.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using Microsoft.VisualBasic;

namespace SchoolManagement.Application.Features.MaintenanceSchedules.Handlers.Commands
{
    public class CompletedScheduleMaintCommandHandler : IRequestHandler<CompletedScheduleMaintCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
     
        public CompletedScheduleMaintCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CompletedScheduleMaintCommand request, CancellationToken cancellationToken)
        {
            var MaintenanceSchedule = await _unitOfWork.Repository<MaintenanceSchedule>().Get(request.CompletedScheduleMaintDto.MaintenanceScheduleId);

            if (MaintenanceSchedule is null)
                throw new NotFoundException(nameof(MaintenanceSchedule), request.CompletedScheduleMaintDto.MaintenanceScheduleId);

            /////// File Upload //////////

            string uniqueFileName = null;

            if (request.CompletedScheduleMaintDto.Doc != null)
            {

              var fileName = Path.GetFileName(request.CompletedScheduleMaintDto.Doc.FileName);
              uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
              var a = Directory.GetCurrentDirectory();
              var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Content\\files\\maintenance-schedules", uniqueFileName);
              using (var fileSteam = new FileStream(filePath, FileMode.Create))
              {
                await request.CompletedScheduleMaintDto.Doc.CopyToAsync(fileSteam);
              }


            }
            _mapper.Map(request.CompletedScheduleMaintDto, MaintenanceSchedule);
            //MaintenanceSchedule.StartInspDate = MaintenanceSchedule.StartInspDate.Value.AddDays(1.0);
            if(request.CompletedScheduleMaintDto.CompletedStatus == 0)
            {
              MaintenanceSchedule.CompletedDate =null;
            }
            else
            {
              MaintenanceSchedule.CompletedDate = MaintenanceSchedule.CompletedDate.Value.AddDays(1.0);
            }

            MaintenanceSchedule.InspCompleteStatus = request.CompletedScheduleMaintDto.CompletedStatus;
            MaintenanceSchedule.ProgressBar = request.CompletedScheduleMaintDto.ProgressBar;

            MaintenanceSchedule.MaintenanceDocument = request.CompletedScheduleMaintDto.Doc != null ? "files/maintenance-schedules/" + uniqueFileName : MaintenanceSchedule.MaintenanceDocument.Replace("https://localhost:44395/Content/", String.Empty);
            await _unitOfWork.Repository<MaintenanceSchedule>().Update(MaintenanceSchedule);
            await _unitOfWork.Save();

            if (request.CompletedScheduleMaintDto.CompletedStatus == 1)
            {
              MaintenanceSchedule.ExtensionGiven = ((MaintenanceSchedule.CompletedDate - MaintenanceSchedule.EndInspDate).Value.Days).ToString();
              await _unitOfWork.Repository<MaintenanceSchedule>().Update(MaintenanceSchedule);
              await _unitOfWork.Save();

              var MaintenancePlanning = await _unitOfWork.Repository<MaintenancePlanning>().Get((int)MaintenanceSchedule.MaintenancePlanningId);
              var MaintenanceSubCategory = await _unitOfWork.Repository<MaintenanceSubCategory>().Get((int)MaintenancePlanning.MaintenanceSubCategoryId);

              if (MaintenancePlanning.MaintenanceCategoryId == 2 || MaintenancePlanning.MaintenanceCategoryId == 36)
              {
                MaintenancePlanning.LastInspDate = MaintenanceSchedule.CompletedDate;
                MaintenancePlanning.NestInspDate = MaintenanceSchedule.CompletedDate.Value.AddDays((double)MaintenanceSubCategory.TotalDaysCount);
        }
              else if (MaintenancePlanning.MaintenanceCategoryId == 3 || MaintenancePlanning.MaintenanceCategoryId == 37)
              {
                MaintenancePlanning.LastInspectionOH = (Convert.ToDouble(MaintenancePlanning.LastInspectionOH) + MaintenanceSubCategory.TotalDaysCount).ToString();
                MaintenancePlanning.NextInspectionOH = (Convert.ToDouble(MaintenancePlanning.NextInspectionOH) + MaintenanceSubCategory.TotalDaysCount).ToString();
              }
              else if (MaintenancePlanning.MaintenanceCategoryId == 25 || MaintenancePlanning.MaintenanceCategoryId == 38)
              {
                MaintenancePlanning.LastInspectionFH = (Convert.ToDouble(MaintenancePlanning.LastInspectionFH) + MaintenanceSubCategory.TotalDaysCount).ToString();
                MaintenancePlanning.NextInspectionFH = (Convert.ToDouble(MaintenancePlanning.NextInspectionFH) + MaintenanceSubCategory.TotalDaysCount).ToString();
              }
              

              await _unitOfWork.Repository<MaintenancePlanning>().Update(MaintenancePlanning);
              await _unitOfWork.Save();
            }
      
            

            return Unit.Value;
        }
    }
}
