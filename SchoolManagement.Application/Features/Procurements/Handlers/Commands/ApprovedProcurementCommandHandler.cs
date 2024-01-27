using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Procurements.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.CoursePlans.Handlers.Commands
{
    public class ApprovedProcurementCommandHandler : IRequestHandler<ApprovedProcurementCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ApprovedProcurementCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(ApprovedProcurementCommand request, CancellationToken cancellationToken)
        {
            var CoursePlan = await _unitOfWork.Repository<Procurement>().Get(request.ProcurementId);
            CoursePlan.VerificationCompletStatus = 1;

            if (CoursePlan == null)
                throw new NotFoundException(nameof(CoursePlan), request.ProcurementId);

            await _unitOfWork.Repository<Procurement>().Update(CoursePlan);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
