using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.RequiredSparesForMaintenances.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.RequiredSparesForMaintenances.Handlers.Commands
{
    public class ApprovedRequiredSparesForMaintenanceCommandHandler : IRequestHandler<ApprovedRequiredSparesForMaintenanceCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ApprovedRequiredSparesForMaintenanceCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(ApprovedRequiredSparesForMaintenanceCommand request, CancellationToken cancellationToken)
        {
            var RequiredSparesForMaintenance = await _unitOfWork.Repository<RequiredSparesForMaintenance>().Get(request.RequiredSparesForMaintenanceId);
            RequiredSparesForMaintenance.VerificationCompletStatus = 1;

            if (RequiredSparesForMaintenance == null)
                throw new NotFoundException(nameof(RequiredSparesForMaintenance), request.RequiredSparesForMaintenanceId);

            await _unitOfWork.Repository<RequiredSparesForMaintenance>().Update(RequiredSparesForMaintenance);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
