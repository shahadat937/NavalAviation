using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.RetirementType.Validators;
using SchoolManagement.Application.Features.RetirementTypes.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.RetirementTypes.Handlers.Commands
{
    public class CreateRetirementTypeCommandHandler : IRequestHandler<CreateRetirementTypeCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateRetirementTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateRetirementTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateRetirementTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.RetirementTypeDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var RetirementType = _mapper.Map<RetirementType>(request.RetirementTypeDto);

                RetirementType = await _unitOfWork.Repository<RetirementType>().Add(RetirementType);
               
                    await _unitOfWork.Save();
                
               


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = RetirementType.RetirementTypeId;
            }

            return response;
        }
    }
}
