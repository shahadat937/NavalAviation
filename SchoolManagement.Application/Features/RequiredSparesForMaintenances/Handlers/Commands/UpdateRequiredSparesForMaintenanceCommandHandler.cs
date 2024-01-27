using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.RequiredSparesForMaintenance.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.RequiredSparesForMaintenances.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;

namespace SchoolManagement.Application.Features.RequiredSparesForMaintenances.Handlers.Commands
{
    public class UpdateRequiredSparesForMaintenanceCommandHandler : IRequestHandler<UpdateRequiredSparesForMaintenanceCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateRequiredSparesForMaintenanceCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateRequiredSparesForMaintenanceCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateRequiredSparesForMaintenanceDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.RequiredSparesForMaintenanceDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var RequiredSparesForMaintenance = await _unitOfWork.Repository<RequiredSparesForMaintenance>().Get(request.RequiredSparesForMaintenanceDto.RequiredSparesForMaintenanceId);

            if (RequiredSparesForMaintenance is null)
                throw new NotFoundException(nameof(RequiredSparesForMaintenance), request.RequiredSparesForMaintenanceDto.RequiredSparesForMaintenanceId);

            _mapper.Map(request.RequiredSparesForMaintenanceDto, RequiredSparesForMaintenance);

            await _unitOfWork.Repository<RequiredSparesForMaintenance>().Update(RequiredSparesForMaintenance);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
