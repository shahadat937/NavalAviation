using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.MaintenanceType.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.MaintenanceTypes.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;

namespace SchoolManagement.Application.Features.MaintenanceTypes.Handlers.Commands
{
    public class UpdateMaintenanceTypeCommandHandler : IRequestHandler<UpdateMaintenanceTypeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateMaintenanceTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateMaintenanceTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateMaintenanceTypeDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.MaintenanceTypeDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var MaintenanceType = await _unitOfWork.Repository<MaintenanceType>().Get(request.MaintenanceTypeDto.MaintenanceTypeId);

            if (MaintenanceType is null)
                throw new NotFoundException(nameof(MaintenanceType), request.MaintenanceTypeDto.MaintenanceTypeId);

            _mapper.Map(request.MaintenanceTypeDto, MaintenanceType);

            await _unitOfWork.Repository<MaintenanceType>().Update(MaintenanceType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
