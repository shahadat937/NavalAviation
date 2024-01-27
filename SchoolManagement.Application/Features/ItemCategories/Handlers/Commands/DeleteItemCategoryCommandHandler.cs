using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ItemCategories.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.ItemCategories.Handlers.Commands
{
    public class DeleteItemCategoryCommandHandler : IRequestHandler<DeleteItemCategoryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteItemCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteItemCategoryCommand request, CancellationToken cancellationToken)
        {
            var ItemCategory = await _unitOfWork.Repository<ItemCategory>().Get(request.ItemCategoryId);

            if (ItemCategory == null)
                throw new NotFoundException(nameof(ItemCategory), request.ItemCategoryId);

            await _unitOfWork.Repository<ItemCategory>().Delete(ItemCategory);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
