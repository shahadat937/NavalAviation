using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.MaintenancePlanningStatuses.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.MaintenancePlanningStatuses.Handlers.Commands
{
    public class DeleteMaintenancePlanningStatusCommandHandler : IRequestHandler<DeleteMaintenancePlanningStatusCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteMaintenancePlanningStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteMaintenancePlanningStatusCommand request, CancellationToken cancellationToken)
        {
            var MaintenancePlanningStatus = await _unitOfWork.Repository<MaintenancePlanningStatus>().Get(request.MaintenancePlanningStatusId);

            if (MaintenancePlanningStatus == null)
                throw new NotFoundException(nameof(MaintenancePlanningStatus), request.MaintenancePlanningStatusId);

            await _unitOfWork.Repository<MaintenancePlanningStatus>().Delete(MaintenancePlanningStatus);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
