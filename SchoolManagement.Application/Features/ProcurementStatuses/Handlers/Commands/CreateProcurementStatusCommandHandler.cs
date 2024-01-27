using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ProcurementStatus.Validators;
using SchoolManagement.Application.Features.ProcurementStatuses.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.ProcurementStatuses.Handlers.Commands
{
    public class CreateProcurementStatusCommandHandler : IRequestHandler<CreateProcurementStatusCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateProcurementStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateProcurementStatusCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateProcurementStatusDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ProcurementStatusDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var ProcurementStatus = _mapper.Map<ProcurementStatus>(request.ProcurementStatusDto);

                ProcurementStatus = await _unitOfWork.Repository<ProcurementStatus>().Add(ProcurementStatus);
               
                    await _unitOfWork.Save();
                
               


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = ProcurementStatus.ProcurementStatusId;
            }

            return response;
        }
    }
}
