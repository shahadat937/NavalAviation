using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.DemandType.Validators;
using SchoolManagement.Application.Features.DemandTypes.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.DemandTypes.Handlers.Commands
{
    public class CreateDemandTypeCommandHandler : IRequestHandler<CreateDemandTypeCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateDemandTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateDemandTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateDemandTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.DemandTypeDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var DemandType = _mapper.Map<DemandType>(request.DemandTypeDto);

                DemandType = await _unitOfWork.Repository<DemandType>().Add(DemandType);
               
                    await _unitOfWork.Save();
                
               


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = DemandType.DemandTypeId;
            }

            return response;
        }
    }
}
