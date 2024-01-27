using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.RequiredSparesForMaintenance.Validators;
using SchoolManagement.Application.Features.RequiredSparesForMaintenances.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.RequiredSparesForMaintenances.Handlers.Commands
{
    public class CreateRequiredSparesForMaintenanceCommandHandler : IRequestHandler<CreateRequiredSparesForMaintenanceCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateRequiredSparesForMaintenanceCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateRequiredSparesForMaintenanceCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateRequiredSparesForMaintenanceDtoValidator();
            var validationResult = await validator.ValidateAsync(request.RequiredSparesForMaintenanceDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var RequiredSparesForMaintenance = _mapper.Map<RequiredSparesForMaintenance>(request.RequiredSparesForMaintenanceDto);
                RequiredSparesForMaintenance.VerificationCompletStatus = 0;
                RequiredSparesForMaintenance = await _unitOfWork.Repository<RequiredSparesForMaintenance>().Add(RequiredSparesForMaintenance);
               
                    await _unitOfWork.Save();
                
               


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = RequiredSparesForMaintenance.RequiredSparesForMaintenanceId;
            }

            return response;
        }
    }
}
