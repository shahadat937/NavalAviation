using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.Trade.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Trades.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;

namespace SchoolManagement.Application.Features.Trades.Handlers.Commands
{
    public class UpdateTradeCommandHandler : IRequestHandler<UpdateTradeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateTradeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateTradeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateTradeDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.TradeDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var Trade = await _unitOfWork.Repository<Trade>().Get(request.TradeDto.TradeId);

            if (Trade is null)
                throw new NotFoundException(nameof(Trade), request.TradeDto.TradeId);

            _mapper.Map(request.TradeDto, Trade);

            await _unitOfWork.Repository<Trade>().Update(Trade);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
