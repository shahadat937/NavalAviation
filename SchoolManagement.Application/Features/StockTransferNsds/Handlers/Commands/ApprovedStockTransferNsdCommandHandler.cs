using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.StockTransferNsds.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.StockTransferNsds.Handlers.Commands
{
    public class ApprovedStockTransferNsdCommandHandler : IRequestHandler<ApprovedStockTransferNsdCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ApprovedStockTransferNsdCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(ApprovedStockTransferNsdCommand request, CancellationToken cancellationToken)
        {
            var StockTransferNsd = await _unitOfWork.Repository<StockTransferNsd>().Get(request.StockTransferNsdId);
            StockTransferNsd.VerificationCompletStatus = 1;

            if (StockTransferNsd == null)
                throw new NotFoundException(nameof(StockTransferNsd), request.StockTransferNsdId);

            await _unitOfWork.Repository<StockTransferNsd>().Update(StockTransferNsd);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
