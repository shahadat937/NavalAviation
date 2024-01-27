using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.RunningHour.Validators;
using SchoolManagement.Application.Features.RunningHours.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.RunningHours.Handlers.Commands
{
    public class CreateRunningHourCommandHandler : IRequestHandler<CreateRunningHourCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateRunningHourCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateRunningHourCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateRunningHourDtoValidator();
            var validationResult = await validator.ValidateAsync(request.RunningHourDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var RunningHour = _mapper.Map<RunningHour>(request.RunningHourDto);

                RunningHour = await _unitOfWork.Repository<RunningHour>().Add(RunningHour);
               
                    await _unitOfWork.Save();
                
               


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = RunningHour.RunningHourId;
            }

            return response;
        }
    }
}
