using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.MaintenancePlanningStatus.Validators;
using SchoolManagement.Application.Features.MaintenancePlanningStatuses.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.MaintenancePlanningStatuses.Handlers.Commands
{
    public class CreateMaintenancePlanningStatusCommandHandler : IRequestHandler<CreateMaintenancePlanningStatusCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateMaintenancePlanningStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateMaintenancePlanningStatusCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateMaintenancePlanningStatusDtoValidator();
            var validationResult = await validator.ValidateAsync(request.MaintenancePlanningStatusDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var MaintenancePlanningStatus = _mapper.Map<MaintenancePlanningStatus>(request.MaintenancePlanningStatusDto);

                MaintenancePlanningStatus = await _unitOfWork.Repository<MaintenancePlanningStatus>().Add(MaintenancePlanningStatus);

                
                    await _unitOfWork.Save();
                


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = MaintenancePlanningStatus.MaintenancePlanningStatusId;
            }

            return response;
        }
    }
}
