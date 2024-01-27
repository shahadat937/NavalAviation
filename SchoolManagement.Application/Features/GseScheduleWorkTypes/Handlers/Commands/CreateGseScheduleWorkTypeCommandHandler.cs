using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.GseScheduleWorkType.Validators;
using SchoolManagement.Application.Features.GseScheduleWorkTypes.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.GseScheduleWorkTypes.Handlers.Commands
{
    public class CreateGseScheduleWorkTypeCommandHandler : IRequestHandler<CreateGseScheduleWorkTypeCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateGseScheduleWorkTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateGseScheduleWorkTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateGseScheduleWorkTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.GseScheduleWorkTypeDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var GseScheduleWorkType = _mapper.Map<GseScheduleWorkType>(request.GseScheduleWorkTypeDto);

                GseScheduleWorkType = await _unitOfWork.Repository<GseScheduleWorkType>().Add(GseScheduleWorkType);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = GseScheduleWorkType.GseScheduleWorkTypeId;
            }

            return response;
        }
    }
}
