using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.MaintenanceSchedules.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.MaintenanceSchedules.Handlers.Commands
{
    public class DeleteMaintenanceScheduleCommandHandler : IRequestHandler<DeleteMaintenanceScheduleCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteMaintenanceScheduleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteMaintenanceScheduleCommand request, CancellationToken cancellationToken)
        {
            var MaintenanceSchedule = await _unitOfWork.Repository<MaintenanceSchedule>().Get(request.MaintenanceScheduleId);

            if (MaintenanceSchedule == null)
                throw new NotFoundException(nameof(MaintenanceSchedule), request.MaintenanceScheduleId);

            await _unitOfWork.Repository<MaintenanceSchedule>().Delete(MaintenanceSchedule);
            try
            {
                await _unitOfWork.Save();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
            //await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
