using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ItemStors.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.CoursePlans.Handlers.Commands
{
    public class ApprovedItemStorCommandHandler : IRequestHandler<ApprovedItemStorCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ApprovedItemStorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(ApprovedItemStorCommand request, CancellationToken cancellationToken)
        {
            var CoursePlan = await _unitOfWork.Repository<ItemStor>().Get(request.ItemStorId);
            CoursePlan.VerificationCompletStatus = 1;

            if (CoursePlan == null)
                throw new NotFoundException(nameof(CoursePlan), request.ItemStorId);

            await _unitOfWork.Repository<ItemStor>().Update(CoursePlan);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
