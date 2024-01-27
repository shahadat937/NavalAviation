using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ItemDetails.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.CoursePlans.Handlers.Commands
{
    public class ApprovedItemDetailCommandHandler : IRequestHandler<ApprovedItemDetailCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ApprovedItemDetailCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(ApprovedItemDetailCommand request, CancellationToken cancellationToken)
        {
            var CoursePlan = await _unitOfWork.Repository<ItemDetail>().Get(request.ItemDetailId);
            CoursePlan.VerificationCompletStatus = 1;

            if (CoursePlan == null)
                throw new NotFoundException(nameof(CoursePlan), request.ItemDetailId);

            await _unitOfWork.Repository<ItemDetail>().Update(CoursePlan);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
