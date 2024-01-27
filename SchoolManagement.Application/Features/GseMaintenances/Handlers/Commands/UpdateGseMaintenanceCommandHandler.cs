using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.GseMaintenance.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.GseMaintenances.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;

namespace SchoolManagement.Application.Features.GseMaintenances.Handlers.Commands
{
    public class UpdateGseMaintenanceCommandHandler : IRequestHandler<UpdateGseMaintenanceCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateGseMaintenanceCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateGseMaintenanceCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateGseMaintenanceDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.GseMaintenanceDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var GseMaintenance = await _unitOfWork.Repository<GseMaintenance>().Get(request.GseMaintenanceDto.GseMaintenanceId);

            if (GseMaintenance is null)
                throw new NotFoundException(nameof(GseMaintenance), request.GseMaintenanceDto.GseMaintenanceId);

            _mapper.Map(request.GseMaintenanceDto, GseMaintenance);

            await _unitOfWork.Repository<GseMaintenance>().Update(GseMaintenance);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
