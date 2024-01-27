using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.TrainingCrew.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.TrainingCrews.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.TrainingCrews.Handlers.Commands
{
    public class ChangeTrainingCrewStatusCommandHandler : IRequestHandler<ChangeTrainingCrewStatusCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ChangeTrainingCrewStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(ChangeTrainingCrewStatusCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            //var validator = new UpdateTrainingCrewDtoValidator(); 
            //var validationResult = await validator.ValidateAsync(request);

            //if (validationResult.IsValid == false)
            //    throw new ValidationException(validationResult);

            var TrainingCrew = await _unitOfWork.Repository<TrainingCrew>().Get(request.TrainingCrewId);

            if (TrainingCrew is null)
                throw new NotFoundException(nameof(TrainingCrew), request.TrainingCrewId);

              //_mapper.Map(request.TrainingCrewDto, TrainingCrew);
              //TrainingCrew.DateOfJoin = TrainingCrew.DateOfJoin.Value.AddDays(1.0);

              TrainingCrew.OfficersStatusId = request.OfficerStatusId;

            await _unitOfWork.Repository<TrainingCrew>().Update(TrainingCrew);
            await _unitOfWork.Save();

            response.Success = true;
            response.Message = "Status Update Successful";

            return response;
    }
    }
}
