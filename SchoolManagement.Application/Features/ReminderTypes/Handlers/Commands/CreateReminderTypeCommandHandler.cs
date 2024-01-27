using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ReminderType.Validators;
using SchoolManagement.Application.Features.ReminderTypes.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.ReminderTypes.Handlers.Commands
{
    public class CreateReminderTypeCommandHandler : IRequestHandler<CreateReminderTypeCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateReminderTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateReminderTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateReminderTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ReminderTypeDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var ReminderType = _mapper.Map<ReminderType>(request.ReminderTypeDto);

                ReminderType = await _unitOfWork.Repository<ReminderType>().Add(ReminderType);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = ReminderType.ReminderTypeId;
            }

            return response;
        }
    }
}
