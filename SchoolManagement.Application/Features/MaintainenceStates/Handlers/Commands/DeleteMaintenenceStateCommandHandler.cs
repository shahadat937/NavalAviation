using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.MaintenenceStates.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.MaintenenceStates.Handlers.Commands
{
    public class DeleteMaintenenceStateCommandHandler : IRequestHandler<DeleteMaintenenceStateCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteMaintenenceStateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteMaintenenceStateCommand request, CancellationToken cancellationToken)
        {
            var MaintenenceState = await _unitOfWork.Repository<MaintenenceState>().Get(request.MaintenenceStateId);

            if (MaintenenceState == null)
                throw new NotFoundException(nameof(MaintenenceState), request.MaintenenceStateId);

            await _unitOfWork.Repository<MaintenenceState>().Delete(MaintenenceState);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
