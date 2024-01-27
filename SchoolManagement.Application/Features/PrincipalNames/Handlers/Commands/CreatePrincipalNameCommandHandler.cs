using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.PrincipalName.Validators;
using SchoolManagement.Application.Features.PrincipalNames.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.PrincipalNames.Handlers.Commands
{
    public class CreatePrincipalNameCommandHandler : IRequestHandler<CreatePrincipalNameCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreatePrincipalNameCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreatePrincipalNameCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreatePrincipalNameDtoValidator();
            var validationResult = await validator.ValidateAsync(request.PrincipalNameDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var PrincipalName = _mapper.Map<PrincipalName>(request.PrincipalNameDto);

                PrincipalName = await _unitOfWork.Repository<PrincipalName>().Add(PrincipalName);
               
                    await _unitOfWork.Save();
                
               


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = PrincipalName.PrincipalNameId;
            }

            return response;
        }
    }
}
