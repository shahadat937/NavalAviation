using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.StockTransferNsds.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.StockTransferNsds.Handlers.Commands
{
    public class DeleteStockTransferNsdCommandHandler : IRequestHandler<DeleteStockTransferNsdCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteStockTransferNsdCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteStockTransferNsdCommand request, CancellationToken cancellationToken)
        {
            var StockTransferNsd = await _unitOfWork.Repository<StockTransferNsd>().Get(request.StockTransferNsdId);

            if (StockTransferNsd == null)
                throw new NotFoundException(nameof(StockTransferNsd), request.StockTransferNsdId);

            await _unitOfWork.Repository<StockTransferNsd>().Delete(StockTransferNsd);
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
