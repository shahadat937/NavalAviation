using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Trades.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.Trades.Handlers.Commands
{
    public class DeleteTradeCommandHandler : IRequestHandler<DeleteTradeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteTradeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteTradeCommand request, CancellationToken cancellationToken)
        {
            var Trade = await _unitOfWork.Repository<Trade>().Get(request.TradeId);

            if (Trade == null)
                throw new NotFoundException(nameof(Trade), request.TradeId);

            await _unitOfWork.Repository<Trade>().Delete(Trade);
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
