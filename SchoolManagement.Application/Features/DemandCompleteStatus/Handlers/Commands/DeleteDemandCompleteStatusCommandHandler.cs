using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.DemandCompleteStatuses.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.DemandCompleteStatuses.Handlers.Commands
{
    public class DeleteDemandCompleteStatusCommandHandler : IRequestHandler<DeleteDemandCompleteStatusCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteDemandCompleteStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteDemandCompleteStatusCommand request, CancellationToken cancellationToken)
        {
            var DemandCompleteStatus = await _unitOfWork.Repository<DemandCompleteStatus>().Get(request.DemandCompleteStatusId);

            if (DemandCompleteStatus == null)
                throw new NotFoundException(nameof(DemandCompleteStatus), request.DemandCompleteStatusId);

            await _unitOfWork.Repository<DemandCompleteStatus>().Delete(DemandCompleteStatus);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
