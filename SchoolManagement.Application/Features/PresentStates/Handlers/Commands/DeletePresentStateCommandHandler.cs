using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.PresentStates.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.PresentStates.Handlers.Commands
{
    public class DeletePresentStateCommandHandler : IRequestHandler<DeletePresentStateCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeletePresentStateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeletePresentStateCommand request, CancellationToken cancellationToken)
        {
            var PresentState = await _unitOfWork.Repository<PresentState>().Get(request.PresentStateId);

            if (PresentState == null)
                throw new NotFoundException(nameof(PresentState), request.PresentStateId);

            await _unitOfWork.Repository<PresentState>().Delete(PresentState);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
