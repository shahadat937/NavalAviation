using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ItemTypes.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.ItemTypes.Handlers.Commands
{
    public class DeleteItemTypeCommandHandler : IRequestHandler<DeleteItemTypeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteItemTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteItemTypeCommand request, CancellationToken cancellationToken)
        {
            var ItemType = await _unitOfWork.Repository<ItemType>().Get(request.ItemTypeId);

            if (ItemType == null)
                throw new NotFoundException(nameof(ItemType), request.ItemTypeId);

            await _unitOfWork.Repository<ItemType>().Delete(ItemType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
