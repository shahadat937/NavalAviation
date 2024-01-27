using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Demands.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.Demands.Handlers.Commands
{
    public class ApprovedDemandCommandHandler : IRequestHandler<ApprovedDemandCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ApprovedDemandCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(ApprovedDemandCommand request, CancellationToken cancellationToken)
        {
            var Demands = await _unitOfWork.Repository<Demand>().Get(request.DemandId);
              Demands.VerificationCompletStatus = 1;

            if (Demands == null)
                throw new NotFoundException(nameof(Demands), request.DemandId);

            await _unitOfWork.Repository<Demand>().Update(Demands);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
