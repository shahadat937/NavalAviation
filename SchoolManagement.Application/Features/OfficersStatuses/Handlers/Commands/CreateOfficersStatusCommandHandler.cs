using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.OfficersStatus.Validators;
using SchoolManagement.Application.Features.OfficersStatuses.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.OfficersStatuses.Handlers.Commands
{
    public class CreateOfficersStatusCommandHandler : IRequestHandler<CreateOfficersStatusCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateOfficersStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateOfficersStatusCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateOfficersStatusDtoValidator();
            var validationResult = await validator.ValidateAsync(request.OfficersStatusDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var OfficersStatus = _mapper.Map<OfficersStatus>(request.OfficersStatusDto);

                OfficersStatus = await _unitOfWork.Repository<OfficersStatus>().Add(OfficersStatus);
               
                    await _unitOfWork.Save();
                
               


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = OfficersStatus.OfficersStatusId;
            }

            return response;
        }
    }
}
