using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.MaintenancePlanningStatuses.Requests.Commands;
using SchoolManagement.Application.DTOs.MaintenancePlanningStatus.Validators;

namespace SchoolManagement.Application.Features.MaintenancePlanningStatuses.Handlers.Commands
{
    public class UpdateMaintenancePlanningStatusCommandHandler : IRequestHandler<UpdateMaintenancePlanningStatusCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateMaintenancePlanningStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateMaintenancePlanningStatusCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateMaintenancePlanningStatusDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.MaintenancePlanningStatusDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var MaintenancePlanningStatus = await _unitOfWork.Repository<MaintenancePlanningStatus>().Get(request.MaintenancePlanningStatusDto.MaintenancePlanningStatusId);

            if (MaintenancePlanningStatus is null)
                throw new NotFoundException(nameof(MaintenancePlanningStatus), request.MaintenancePlanningStatusDto.MaintenancePlanningStatusId);

            _mapper.Map(request.MaintenancePlanningStatusDto, MaintenancePlanningStatus);

            await _unitOfWork.Repository<MaintenancePlanningStatus>().Update(MaintenancePlanningStatus);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
