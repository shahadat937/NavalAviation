using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.DemandCompleteStatuses.Validators;
using SchoolManagement.Application.Features.DemandCompleteStatuses.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.DemandCompleteStatuses.Handlers.Commands
{
    public class CreateDemandCompleteStatusCommandHandler : IRequestHandler<CreateDemandCompleteStatusCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateDemandCompleteStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateDemandCompleteStatusCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateDemandCompleteStatusDtoValidator();
            var validationResult = await validator.ValidateAsync(request.DemandCompleteStatusDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var DemandCompleteStatus = _mapper.Map<DemandCompleteStatus>(request.DemandCompleteStatusDto);

                DemandCompleteStatus = await _unitOfWork.Repository<DemandCompleteStatus>().Add(DemandCompleteStatus);

                try
                {
                    await _unitOfWork.Save();
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex);
                }


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = DemandCompleteStatus.DemandCompleteStatusId;
            }

            return response;
        }
    }
}
