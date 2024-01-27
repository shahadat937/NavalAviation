using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.AcStatuses.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.AcStatuses.Handlers.Commands
{
    public class DeleteAcStatusCommandHandler : IRequestHandler<DeleteAcStatusCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteAcStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteAcStatusCommand request, CancellationToken cancellationToken)
        {
            var AcStatus = await _unitOfWork.Repository<AcStatus>().Get(request.AcStatusId);

            if (AcStatus == null)
                throw new NotFoundException(nameof(AcStatus), request.AcStatusId);

            await _unitOfWork.Repository<AcStatus>().Delete(AcStatus);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
