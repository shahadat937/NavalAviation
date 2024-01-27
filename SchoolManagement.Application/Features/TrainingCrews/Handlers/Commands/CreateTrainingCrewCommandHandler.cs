using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.TrainingCrew.Validators;
using SchoolManagement.Application.Features.TrainingCrews.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.TrainingCrews.Handlers.Commands
{
    public class CreateTrainingCrewCommandHandler : IRequestHandler<CreateTrainingCrewCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateTrainingCrewCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateTrainingCrewCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateTrainingCrewDtoValidator();
            var validationResult = await validator.ValidateAsync(request.TrainingCrewDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var TrainingCrew = _mapper.Map<TrainingCrew>(request.TrainingCrewDto);

                TrainingCrew = await _unitOfWork.Repository<TrainingCrew>().Add(TrainingCrew);
                TrainingCrew.DateOfJoin = TrainingCrew.DateOfJoin.Value.AddDays(1.0);

        try
        {
          await _unitOfWork.Save();

        }
        catch (Exception ex)
        {
          Console.WriteLine(ex.ToString());
        }
                
               


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = TrainingCrew.TrainingCrewId;
            }

            return response;
        }
    }
}
