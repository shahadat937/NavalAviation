using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.MeaSquadronStates.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.MeaSquadronStates.Handlers.Commands
{
    public class DeleteMeaSquadronStateCommandHandler : IRequestHandler<DeleteMeaSquadronStateCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteMeaSquadronStateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteMeaSquadronStateCommand request, CancellationToken cancellationToken)
        {
            var MeaSquadronState = await _unitOfWork.Repository<MeaSquadronState>().Get(request.MeaSquadronStateId);

            if (MeaSquadronState == null)
                throw new NotFoundException(nameof(MeaSquadronState), request.MeaSquadronStateId);

            await _unitOfWork.Repository<MeaSquadronState>().Delete(MeaSquadronState);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
