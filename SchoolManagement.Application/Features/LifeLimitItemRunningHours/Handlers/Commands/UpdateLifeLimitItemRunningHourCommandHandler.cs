using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.LifeLimitItemRunningHour.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.LifeLimitItemRunningHours.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;

namespace SchoolManagement.Application.Features.LifeLimitItemRunningHours.Handlers.Commands
{
    public class UpdateLifeLimitItemRunningHourCommandHandler : IRequestHandler<UpdateLifeLimitItemRunningHourCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateLifeLimitItemRunningHourCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateLifeLimitItemRunningHourCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLifeLimitItemRunningHourDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.LifeLimitItemRunningHourDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var LifeLimitItemRunningHour = await _unitOfWork.Repository<LifeLimitItemRunningHour>().Get(request.LifeLimitItemRunningHourDto.LifeLimitItemRunningHourId);

            if (LifeLimitItemRunningHour is null)
                throw new NotFoundException(nameof(LifeLimitItemRunningHour), request.LifeLimitItemRunningHourDto.LifeLimitItemRunningHourId);

            _mapper.Map(request.LifeLimitItemRunningHourDto, LifeLimitItemRunningHour);

            await _unitOfWork.Repository<LifeLimitItemRunningHour>().Update(LifeLimitItemRunningHour);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
