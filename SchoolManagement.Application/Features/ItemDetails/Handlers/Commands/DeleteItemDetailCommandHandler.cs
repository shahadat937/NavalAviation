using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ItemDetails.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.ItemDetails.Handlers.Commands
{
    public class DeleteItemDetailCommandHandler : IRequestHandler<DeleteItemDetailCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteItemDetailCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteItemDetailCommand request, CancellationToken cancellationToken)
        {
            var ItemDetail = await _unitOfWork.Repository<ItemDetail>().Get(request.ItemDetailId);

            if (ItemDetail == null)
                throw new NotFoundException(nameof(ItemDetail), request.ItemDetailId);

            await _unitOfWork.Repository<ItemDetail>().Delete(ItemDetail);
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
