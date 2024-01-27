using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.GseMaintenance.Validators;
using SchoolManagement.Application.Features.GseMaintenances.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.GseMaintenances.Handlers.Commands
{
    public class CreateGseMaintenanceCommandHandler : IRequestHandler<CreateGseMaintenanceCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateGseMaintenanceCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateGseMaintenanceCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateGseMaintenanceDtoValidator();
            var validationResult = await validator.ValidateAsync(request.GseMaintenanceDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var GseMaintenance = _mapper.Map<GseMaintenance>(request.GseMaintenanceDto);

                GseMaintenance = await _unitOfWork.Repository<GseMaintenance>().Add(GseMaintenance);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = GseMaintenance.GseMaintenanceId;
            }

            return response;
        }
    }
}
