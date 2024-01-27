using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.AccountType.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.AccountTypes.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;

namespace SchoolManagement.Application.Features.AccountTypes.Handlers.Commands
{
    public class UpdateAccountTypeCommandHandler : IRequestHandler<UpdateAccountTypeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateAccountTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateAccountTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateAccountTypeDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.AccountTypeDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var AccountType = await _unitOfWork.Repository<AccountType>().Get(request.AccountTypeDto.AccountTypeId);

            if (AccountType is null)
                throw new NotFoundException(nameof(AccountType), request.AccountTypeDto.AccountTypeId);

            _mapper.Map(request.AccountTypeDto, AccountType);

            await _unitOfWork.Repository<AccountType>().Update(AccountType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
