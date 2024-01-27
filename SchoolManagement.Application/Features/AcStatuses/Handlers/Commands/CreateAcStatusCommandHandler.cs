using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.AcStatus.Validators;
using SchoolManagement.Application.Features.AcStatuses.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.AcStatuses.Handlers.Commands
{
    public class CreateAcStatusCommandHandler : IRequestHandler<CreateAcStatusCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateAcStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateAcStatusCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateAcStatusDtoValidator();
            var validationResult = await validator.ValidateAsync(request.AcStatusDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var AcStatus = _mapper.Map<AcStatus>(request.AcStatusDto);
                if(AcStatus.StatusId != 1)
                {
                    AcStatus.AircraftStatusCheck = 0;
                }
                else
                {
                  AcStatus.AircraftStatusCheck = 1;
                }

                AcStatus = await _unitOfWork.Repository<AcStatus>().Add(AcStatus);
                AcStatus.PlannedDate = AcStatus.PlannedDate.Value.AddDays(1.0);
                await _unitOfWork.Save();

                var AircraftNameOnAcStatus =  await _unitOfWork.Repository<AirCraftName>().Get(request.AcStatusDto.AirCraftNameId);
                AircraftNameOnAcStatus.AircraftStatus = request.AcStatusDto.StatusId;

                await _unitOfWork.Repository<AirCraftName>().Update(AircraftNameOnAcStatus);
                await _unitOfWork.Save();


        response.Success = true;
                response.Message = "Creation Successful";
                response.Id = AcStatus.AcStatusId;
            }

            return response;
        }
    }
}
