using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.MaintenenceState.Validators;
using SchoolManagement.Application.Features.MaintenenceStates.Requests.Commands;
using SchoolManagement.Application.Features.MaintenenceStates.Requests.Commands;
using SchoolManagement.Application.DTOs.MaintenenceState.Validators;

namespace SchoolManagement.Application.Features.MaintenenceStates.Handlers.Commands
{
    public class UpdatMaintenenceStateeCommandHandler : IRequestHandler<UpdateMaintenenceStateCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdatMaintenenceStateeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateMaintenenceStateCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateMaintenenceStateDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.MaintenenceStateDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var MaintenenceState = await _unitOfWork.Repository<MaintenenceState>().Get(request.MaintenenceStateDto.MaintenenceStateId);

            if (MaintenenceState is null)
                throw new NotFoundException(nameof(MaintenenceState), request.MaintenenceStateDto.MaintenenceStateId);

            _mapper.Map(request.MaintenenceStateDto, MaintenenceState);
            MaintenenceState.LastDateofMaintenence = MaintenenceState.LastDateofMaintenence.Value.AddDays(1.0);
            MaintenenceState.NextDueDate = MaintenenceState.NextDueDate.Value.AddDays(1.0);

            await _unitOfWork.Repository<MaintenenceState>().Update(MaintenenceState);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
