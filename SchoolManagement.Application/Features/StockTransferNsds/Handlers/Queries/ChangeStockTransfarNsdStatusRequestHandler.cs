using SchoolManagement.Application.Features.StockTransferNsds.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.StockTransferNsd;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.StockTransferNsds.Handlers.Queries
{
    public class ChangeStockTransfarNsdStatusRequestHandler : IRequestHandler<ChangeStockTransfarNsdStatusRequest, Unit>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ChangeStockTransfarNsdStatusRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
          _unitOfWork = unitOfWork;
          _mapper = mapper;
        }

        public async Task<Unit> Handle(ChangeStockTransfarNsdStatusRequest request, CancellationToken cancellationToken)
        {
            var targetData = await _unitOfWork.Repository<StockTransferNsd>().Get(request.StockTransferNsdId);

            targetData.Status = request.status;

            await _unitOfWork.Repository<StockTransferNsd>().Update(targetData);
            await _unitOfWork.Save();
            return Unit.Value;
        }
    }
}
