using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.ReminderType.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ReminderTypes.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;

namespace SchoolManagement.Application.Features.ReminderTypes.Handlers.Commands
{
    public class UpdateReminderTypeCommandHandler : IRequestHandler<UpdateReminderTypeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateReminderTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateReminderTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateReminderTypeDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.ReminderTypeDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var ReminderType = await _unitOfWork.Repository<ReminderType>().Get(request.ReminderTypeDto.ReminderTypeId);

            if (ReminderType is null)
                throw new NotFoundException(nameof(ReminderType), request.ReminderTypeDto.ReminderTypeId);

            _mapper.Map(request.ReminderTypeDto, ReminderType);

            await _unitOfWork.Repository<ReminderType>().Update(ReminderType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
