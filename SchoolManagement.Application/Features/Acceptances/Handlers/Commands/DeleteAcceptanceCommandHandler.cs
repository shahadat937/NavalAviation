using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Acceptances.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.Acceptances.Handlers.Commands
{
    public class DeleteAcceptanceCommandHandler : IRequestHandler<DeleteAcceptanceCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteAcceptanceCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteAcceptanceCommand request, CancellationToken cancellationToken)
        {
            var Acceptance = await _unitOfWork.Repository<Acceptance>().Get(request.AcceptanceId);

            if (Acceptance == null)
                throw new NotFoundException(nameof(Acceptance), request.AcceptanceId);

            await _unitOfWork.Repository<Acceptance>().Delete(Acceptance);
            await _unitOfWork.Save();

            var Procurements = await _unitOfWork.Repository<Procurement>().Get((int)Acceptance.ProcurementId);

            Procurements.ProcurementCompleteStatus = 0;

            var procSftQty = Procurements.SftQty;
            var sftQty = Acceptance.SftQty;
            var remainProcQty = procSftQty - sftQty;
            Procurements.SftQty = remainProcQty;
            

            await _unitOfWork.Repository<Procurement>().Update(Procurements);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
