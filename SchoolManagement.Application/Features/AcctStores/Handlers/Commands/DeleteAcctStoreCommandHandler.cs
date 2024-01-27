using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.AcctStores.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.AcctStores.Handlers.Commands
{
    public class DeleteAcctStoreCommandHandler : IRequestHandler<DeleteAcctStoreCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteAcctStoreCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteAcctStoreCommand request, CancellationToken cancellationToken)
        {
            var AcctStore = await _unitOfWork.Repository<AcctStore>().Get(request.AcctStoreId);

            if (AcctStore == null)
                throw new NotFoundException(nameof(AcctStore), request.AcctStoreId);

            await _unitOfWork.Repository<AcctStore>().Delete(AcctStore);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
