using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.DepartmentName.Validators;
using SchoolManagement.Application.Features.DepartmentNames.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.DepartmentNames.Handlers.Commands
{
    public class CreateDepartmentNameCommandHandler : IRequestHandler<CreateDepartmentNameCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateDepartmentNameCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateDepartmentNameCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateDepartmentNameDtoValidator();
            var validationResult = await validator.ValidateAsync(request.DepartmentNameDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var DepartmentName = _mapper.Map<DepartmentName>(request.DepartmentNameDto);

                DepartmentName = await _unitOfWork.Repository<DepartmentName>().Add(DepartmentName);
               
                    await _unitOfWork.Save();
                
               


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = DepartmentName.DepartmentNameId;
            }

            return response;
        }
    }
}
