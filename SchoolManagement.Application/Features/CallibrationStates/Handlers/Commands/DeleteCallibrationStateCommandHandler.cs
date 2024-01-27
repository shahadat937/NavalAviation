using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.CallibrationStates.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.CallibrationStates.Handlers.Commands
{
    public class DeleteCallibrationStateCommandHandler : IRequestHandler<DeleteCallibrationStateCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteCallibrationStateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteCallibrationStateCommand request, CancellationToken cancellationToken)
        {
            var CallibrationState = await _unitOfWork.Repository<CallibrationState>().Get(request.CallibrationStateId);

            if (CallibrationState == null)
                throw new NotFoundException(nameof(CallibrationState), request.CallibrationStateId);

            await _unitOfWork.Repository<CallibrationState>().Delete(CallibrationState);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
