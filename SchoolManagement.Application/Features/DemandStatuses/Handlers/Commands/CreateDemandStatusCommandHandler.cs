using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.DemandStatus.Validators;
using SchoolManagement.Application.Features.DemandStatuses.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.DemandStatuses.Handlers.Commands
{
    public class CreateDemandStatusCommandHandler : IRequestHandler<CreateDemandStatusCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateDemandStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateDemandStatusCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateDemandStatusDtoValidator();
            var validationResult = await validator.ValidateAsync(request.DemandStatusDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var DemandStatus = _mapper.Map<DemandStatus>(request.DemandStatusDto);

                DemandStatus = await _unitOfWork.Repository<DemandStatus>().Add(DemandStatus);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = DemandStatus.DemandStatusId;
            }

            return response;
        }
    }
}
