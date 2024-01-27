using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.LifeLimitItemRunningHour.Validators;
using SchoolManagement.Application.Features.LifeLimitItemRunningHours.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.LifeLimitItemRunningHours.Handlers.Commands
{
    public class CreateLifeLimitItemRunningHourCommandHandler : IRequestHandler<CreateLifeLimitItemRunningHourCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateLifeLimitItemRunningHourCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateLifeLimitItemRunningHourCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateLifeLimitItemRunningHourDtoValidator();
            var validationResult = await validator.ValidateAsync(request.LifeLimitItemRunningHourDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var LifeLimitItemRunningHour = _mapper.Map<LifeLimitItemRunningHour>(request.LifeLimitItemRunningHourDto);

                LifeLimitItemRunningHour = await _unitOfWork.Repository<LifeLimitItemRunningHour>().Add(LifeLimitItemRunningHour);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = LifeLimitItemRunningHour.LifeLimitItemRunningHourId;
            }

            return response;
        }
    }
}
