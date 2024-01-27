using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.MaintenancePlannings.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.MaintenancePlannings.Handlers.Commands
{
    public class CompleteStatusMaintenancePlanningCommandHandler : IRequestHandler<CompleteStatusMaintenancePlanningCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CompleteStatusMaintenancePlanningCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CompleteStatusMaintenancePlanningCommand request, CancellationToken cancellationToken)
        {
            var MaintenancePlanning = await _unitOfWork.Repository<MaintenancePlanning>().Get(request.MaintenancePlanningId);
            MaintenancePlanning.CompletStatus = 1;

            if (MaintenancePlanning == null)
                throw new NotFoundException(nameof(MaintenancePlanning), request.MaintenancePlanningId);

            await _unitOfWork.Repository<MaintenancePlanning>().Update(MaintenancePlanning);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
