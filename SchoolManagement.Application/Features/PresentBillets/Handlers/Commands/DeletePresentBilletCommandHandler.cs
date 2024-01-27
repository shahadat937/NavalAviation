using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.PresentBillets.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.PresentBillets.Handlers.Commands
{
    public class DeletePresentBilletCommandHandler : IRequestHandler<DeletePresentBilletCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeletePresentBilletCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeletePresentBilletCommand request, CancellationToken cancellationToken)
        {
            var PresentBillet = await _unitOfWork.Repository<PresentBillet>().Get(request.PresentBilletId);

            if (PresentBillet == null)
                throw new NotFoundException(nameof(PresentBillet), request.PresentBilletId);

            await _unitOfWork.Repository<PresentBillet>().Delete(PresentBillet);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
