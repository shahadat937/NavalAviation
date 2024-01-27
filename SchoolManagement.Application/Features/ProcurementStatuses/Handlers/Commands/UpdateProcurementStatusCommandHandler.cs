using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.ProcurementStatus.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ProcurementStatuses.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;

namespace SchoolManagement.Application.Features.ProcurementStatuses.Handlers.Commands
{
    public class UpdateProcurementStatusCommandHandler : IRequestHandler<UpdateProcurementStatusCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateProcurementStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateProcurementStatusCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateProcurementStatusDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.ProcurementStatusDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var ProcurementStatus = await _unitOfWork.Repository<ProcurementStatus>().Get(request.ProcurementStatusDto.ProcurementStatusId);

            if (ProcurementStatus is null)
                throw new NotFoundException(nameof(ProcurementStatus), request.ProcurementStatusDto.ProcurementStatusId);

            _mapper.Map(request.ProcurementStatusDto, ProcurementStatus);

            await _unitOfWork.Repository<ProcurementStatus>().Update(ProcurementStatus);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
