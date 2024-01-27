using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.PreviousItemStores.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.PreviousItemStores.Handlers.Commands
{
    public class DeletePreviousItemStoreCommandHandler : IRequestHandler<DeletePreviousItemStoreCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeletePreviousItemStoreCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeletePreviousItemStoreCommand request, CancellationToken cancellationToken)
        {
            var PreviousItemStore = await _unitOfWork.Repository<PreviousItemStore>().Get(request.PreviousItemStoreId);

            if (PreviousItemStore == null)
                throw new NotFoundException(nameof(PreviousItemStore), request.PreviousItemStoreId);

            await _unitOfWork.Repository<PreviousItemStore>().Delete(PreviousItemStore);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
