using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Shops.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;

namespace SchoolManagement.Application.Features.Shops.Handlers.Commands
{
    public class DeleteShopCommandHandler : IRequestHandler<DeleteShopCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteShopCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteShopCommand request, CancellationToken cancellationToken)
        {
            var Shop = await _unitOfWork.Repository<Shop>().Get(request.ShopId);

            if (Shop == null)
                throw new NotFoundException(nameof(Shop), request.ShopId);

            await _unitOfWork.Repository<Shop>().Delete(Shop);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
