using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Statuses.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.Statuses.Handlers.Commands
{
    public class DeleteStatusCommandHandler : IRequestHandler<DeleteStatusCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteStatusCommand request, CancellationToken cancellationToken)
        {
            var Status = await _unitOfWork.Repository<Status>().Get(request.StatusId);

            if (Status == null)
                throw new NotFoundException(nameof(Status), request.StatusId);

            await _unitOfWork.Repository<Status>().Delete(Status);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
