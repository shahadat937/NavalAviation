using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.GseMaintenanceScheduleName.Validators;
using SchoolManagement.Application.Features.GseMaintenanceScheduleNames.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.GseMaintenanceScheduleNames.Handlers.Commands
{
    public class CreateGseMaintenanceScheduleNameCommandHandler : IRequestHandler<CreateGseMaintenanceScheduleNameCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateGseMaintenanceScheduleNameCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateGseMaintenanceScheduleNameCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateGseMaintenanceScheduleNameDtoValidator();
            var validationResult = await validator.ValidateAsync(request.GseMaintenanceScheduleNameDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var GseMaintenanceScheduleName = _mapper.Map<GseMaintenanceScheduleName>(request.GseMaintenanceScheduleNameDto);

                GseMaintenanceScheduleName = await _unitOfWork.Repository<GseMaintenanceScheduleName>().Add(GseMaintenanceScheduleName);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = GseMaintenanceScheduleName.GseMaintenanceScheduleNameId;
            }

            return response;
        }
    }
}
