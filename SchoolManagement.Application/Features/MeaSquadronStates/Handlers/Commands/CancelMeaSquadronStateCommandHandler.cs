using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.MeaSquadronStates.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.MeaSquadronStates.Handlers.Commands
{
    public class CancelMeaSquadronStateCommandHandler : IRequestHandler<CancelMeaSquadronStateCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CancelMeaSquadronStateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CancelMeaSquadronStateCommand request, CancellationToken cancellationToken)
        {
            var MeaSquadronState = await _unitOfWork.Repository<MeaSquadronState>().Get(request.MeaSquadronStateId);
            MeaSquadronState.JobStatus = 0;

            if (MeaSquadronState == null)
                throw new NotFoundException(nameof(MeaSquadronState), request.MeaSquadronStateId);

            await _unitOfWork.Repository<MeaSquadronState>().Update(MeaSquadronState);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
