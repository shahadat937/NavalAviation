using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.TrainingCrew.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.TrainingCrews.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;

namespace SchoolManagement.Application.Features.TrainingCrews.Handlers.Commands
{
    public class UpdateTrainingCrewCommandHandler : IRequestHandler<UpdateTrainingCrewCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateTrainingCrewCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateTrainingCrewCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateTrainingCrewDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.TrainingCrewDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var TrainingCrew = await _unitOfWork.Repository<TrainingCrew>().Get(request.TrainingCrewDto.TrainingCrewId);

            if (TrainingCrew is null)
                throw new NotFoundException(nameof(TrainingCrew), request.TrainingCrewDto.TrainingCrewId);

            _mapper.Map(request.TrainingCrewDto, TrainingCrew);
            TrainingCrew.DateOfJoin = TrainingCrew.DateOfJoin.Value.AddDays(1.0);

            await _unitOfWork.Repository<TrainingCrew>().Update(TrainingCrew);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
