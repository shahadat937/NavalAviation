using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Acceptances.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.CoursePlans.Handlers.Commands
{
    public class ApprovedAcceptanceCommandHandler : IRequestHandler<ApprovedAcceptanceCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ApprovedAcceptanceCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(ApprovedAcceptanceCommand request, CancellationToken cancellationToken)
        {
            var CoursePlan = await _unitOfWork.Repository<Acceptance>().Get(request.AcceptanceId);
            CoursePlan.VerificationCompletStatus = 1;

            if (CoursePlan == null)
                throw new NotFoundException(nameof(CoursePlan), request.AcceptanceId);

            await _unitOfWork.Repository<Acceptance>().Update(CoursePlan);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
