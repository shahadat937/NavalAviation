using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.FiscalYears.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.FiscalYears.Handlers.Commands
{
    public class DeleteFiscalYearCommandHandler : IRequestHandler<DeleteFiscalYearCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteFiscalYearCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteFiscalYearCommand request, CancellationToken cancellationToken)
        {
            var FiscalYear = await _unitOfWork.Repository<FiscalYear>().Get(request.FiscalYearId);

            if (FiscalYear == null)
                throw new NotFoundException(nameof(FiscalYear), request.FiscalYearId);

            await _unitOfWork.Repository<FiscalYear>().Delete(FiscalYear);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
