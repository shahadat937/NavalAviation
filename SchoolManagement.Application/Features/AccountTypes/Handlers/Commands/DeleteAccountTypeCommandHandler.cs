using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.AccountTypes.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.AccountTypes.Handlers.Commands
{
    public class DeleteAccountTypeCommandHandler : IRequestHandler<DeleteAccountTypeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteAccountTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteAccountTypeCommand request, CancellationToken cancellationToken)
        {
            var AccountType = await _unitOfWork.Repository<AccountType>().Get(request.AccountTypeId);

            if (AccountType == null)
                throw new NotFoundException(nameof(AccountType), request.AccountTypeId);

            await _unitOfWork.Repository<AccountType>().Delete(AccountType);
            try
            {
                await _unitOfWork.Save();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
            //await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
