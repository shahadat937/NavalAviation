using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.UserTransferBackups.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.UserTransferBackups.Handlers.Commands
{
    public class DeleteUserTransferBackupCommandHandler : IRequestHandler<DeleteUserTransferBackupCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteUserTransferBackupCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteUserTransferBackupCommand request, CancellationToken cancellationToken)
        {
            var UserTransferBackup = await _unitOfWork.Repository<UserTransferBackup>().Get(request.Id);

            if (UserTransferBackup == null)
                throw new NotFoundException(nameof(UserTransferBackup), request.Id);

            await _unitOfWork.Repository<UserTransferBackup>().Delete(UserTransferBackup);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
