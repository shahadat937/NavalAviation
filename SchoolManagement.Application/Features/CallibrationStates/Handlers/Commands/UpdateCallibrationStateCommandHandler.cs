using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.CallibrationState.Validators;
using SchoolManagement.Application.Features.CallibrationStates.Requests.Commands;

namespace SchoolManagement.Application.Features.CallibrationStates.Handlers.Commands
{
    public class UpdateCallibrationStateCommandHandler : IRequestHandler<UpdateCallibrationStateCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCallibrationStateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCallibrationStateCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCallibrationStateDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.CallibrationStateDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var CallibrationState = await _unitOfWork.Repository<CallibrationState>().Get(request.CallibrationStateDto.CallibrationStateId);

            if (CallibrationState is null)
                throw new NotFoundException(nameof(CallibrationState), request.CallibrationStateDto.CallibrationStateId);

            _mapper.Map(request.CallibrationStateDto, CallibrationState);
            CallibrationState.LastDateofCalibrated = CallibrationState.LastDateofCalibrated.Value.AddDays(1.0);
            CallibrationState.NextDueDate = CallibrationState.NextDueDate.Value.AddDays(1.0);

            await _unitOfWork.Repository<CallibrationState>().Update(CallibrationState);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
