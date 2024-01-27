using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ProcurementStatuses.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.ProcurementStatuses.Handlers.Commands
{
    public class DeleteProcurementStatusCommandHandler : IRequestHandler<DeleteProcurementStatusCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteProcurementStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteProcurementStatusCommand request, CancellationToken cancellationToken)
        {
            var ProcurementStatus = await _unitOfWork.Repository<ProcurementStatus>().Get(request.ProcurementStatusId);

            if (ProcurementStatus == null)
                throw new NotFoundException(nameof(ProcurementStatus), request.ProcurementStatusId);

            await _unitOfWork.Repository<ProcurementStatus>().Delete(ProcurementStatus);
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
