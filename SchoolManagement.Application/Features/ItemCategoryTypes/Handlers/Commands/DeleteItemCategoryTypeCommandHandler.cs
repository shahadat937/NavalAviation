using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ItemCategoryTypes.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.ItemCategoryTypes.Handlers.Commands
{
    public class DeleteItemCategoryTypeCommandHandler : IRequestHandler<DeleteItemCategoryTypeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteItemCategoryTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteItemCategoryTypeCommand request, CancellationToken cancellationToken)
        {
            var ItemCategoryType = await _unitOfWork.Repository<ItemCategoryType>().Get(request.ItemCategoryTypeId);

            if (ItemCategoryType == null)
                throw new NotFoundException(nameof(ItemCategoryType), request.ItemCategoryTypeId);

            await _unitOfWork.Repository<ItemCategoryType>().Delete(ItemCategoryType);
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
