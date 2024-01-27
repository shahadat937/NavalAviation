using AutoMapper;
using SchoolManagement.Application.DTOs.EmployeeType.Validators;
using SchoolManagement.Application.Features.EmployeeTypes.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.EmployeeTypes.Handlers.Commands
{
    public class CreateEmployeeTypeCommandHandler : IRequestHandler<CreateEmployeeTypeCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateEmployeeTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateEmployeeTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateEmployeeTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.EmployeeTypeDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var EmployeeTypes = _mapper.Map<EmployeeType>(request.EmployeeTypeDto);

                EmployeeTypes = await _unitOfWork.Repository<EmployeeType>().Add(EmployeeTypes);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = EmployeeTypes.EmployeeTypeId;
            }

            return response;
        }
    }
}
