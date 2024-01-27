using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.MaintenanceSchedules.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.MaintenanceSchedules.Handlers.Commands
{
    public class ApprovedMaintenanceScheduleCommandHandler : IRequestHandler<ApprovedMaintenanceScheduleCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ApprovedMaintenanceScheduleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(ApprovedMaintenanceScheduleCommand request, CancellationToken cancellationToken)
        {
            var MaintenanceSchedule = await _unitOfWork.Repository<MaintenanceSchedule>().Get(request.MaintenanceScheduleId);
            MaintenanceSchedule.VerificationCompletStatus = 1;

            if (MaintenanceSchedule == null)
                throw new NotFoundException(nameof(MaintenanceSchedule), request.MaintenanceScheduleId);

            await _unitOfWork.Repository<MaintenanceSchedule>().Update(MaintenanceSchedule);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
