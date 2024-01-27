using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.GseMaintenanceScheduleName.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.GseMaintenanceScheduleNames.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;

namespace SchoolManagement.Application.Features.GseMaintenanceScheduleNames.Handlers.Commands
{
    public class UpdateGseMaintenanceScheduleNameCommandHandler : IRequestHandler<UpdateGseMaintenanceScheduleNameCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateGseMaintenanceScheduleNameCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateGseMaintenanceScheduleNameCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateGseMaintenanceScheduleNameDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.GseMaintenanceScheduleNameDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var GseMaintenanceScheduleName = await _unitOfWork.Repository<GseMaintenanceScheduleName>().Get(request.GseMaintenanceScheduleNameDto.GseMaintenanceScheduleNameId);

            if (GseMaintenanceScheduleName is null)
                throw new NotFoundException(nameof(GseMaintenanceScheduleName), request.GseMaintenanceScheduleNameDto.GseMaintenanceScheduleNameId);

            _mapper.Map(request.GseMaintenanceScheduleNameDto, GseMaintenanceScheduleName);

            await _unitOfWork.Repository<GseMaintenanceScheduleName>().Update(GseMaintenanceScheduleName);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
