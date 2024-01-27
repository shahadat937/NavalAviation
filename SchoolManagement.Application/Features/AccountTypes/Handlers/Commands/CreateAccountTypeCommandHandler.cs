using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.AccountType.Validators;
using SchoolManagement.Application.Features.AccountTypes.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.AccountTypes.Handlers.Commands
{
    public class CreateAccountTypeCommandHandler : IRequestHandler<CreateAccountTypeCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateAccountTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateAccountTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateAccountTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.AccountTypeDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var AccountType = _mapper.Map<AccountType>(request.AccountTypeDto);

                AccountType = await _unitOfWork.Repository<AccountType>().Add(AccountType);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = AccountType.AccountTypeId;
            }

            return response;
        }
    }
}
