using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.RunningHour.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.RunningHours.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;

namespace SchoolManagement.Application.Features.RunningHours.Handlers.Commands
{
    public class UpdateRunningHourCommandHandler : IRequestHandler<UpdateRunningHourCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateRunningHourCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateRunningHourCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateRunningHourDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.RunningHourDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var RunningHour = await _unitOfWork.Repository<RunningHour>().Get(request.RunningHourDto.RunningHourId);

            if (RunningHour is null)
                throw new NotFoundException(nameof(RunningHour), request.RunningHourDto.RunningHourId);

            _mapper.Map(request.RunningHourDto, RunningHour);

            await _unitOfWork.Repository<RunningHour>().Update(RunningHour);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
