using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ItemStatuses.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.ItemStatuses.Handlers.Commands
{
    public class DeleteItemStatusCommandHandler : IRequestHandler<DeleteItemStatusCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteItemStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteItemStatusCommand request, CancellationToken cancellationToken)
        {
            var ItemStatus = await _unitOfWork.Repository<ItemStatus>().Get(request.ItemStatusId);

            if (ItemStatus == null)
                throw new NotFoundException(nameof(ItemStatus), request.ItemStatusId);

            await _unitOfWork.Repository<ItemStatus>().Delete(ItemStatus);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
