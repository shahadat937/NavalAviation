using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.GseScheduleWorkType.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.GseScheduleWorkTypes.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;

namespace SchoolManagement.Application.Features.GseScheduleWorkTypes.Handlers.Commands
{
    public class UpdateGseScheduleWorkTypeCommandHandler : IRequestHandler<UpdateGseScheduleWorkTypeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateGseScheduleWorkTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateGseScheduleWorkTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateGseScheduleWorkTypeDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.GseScheduleWorkTypeDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var GseScheduleWorkType = await _unitOfWork.Repository<GseScheduleWorkType>().Get(request.GseScheduleWorkTypeDto.GseScheduleWorkTypeId);

            if (GseScheduleWorkType is null)
                throw new NotFoundException(nameof(GseScheduleWorkType), request.GseScheduleWorkTypeDto.GseScheduleWorkTypeId);

            _mapper.Map(request.GseScheduleWorkTypeDto, GseScheduleWorkType);

            await _unitOfWork.Repository<GseScheduleWorkType>().Update(GseScheduleWorkType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
