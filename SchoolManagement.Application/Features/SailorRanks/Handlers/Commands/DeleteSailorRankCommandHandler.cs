using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.SailorRanks.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;

namespace SchoolManagement.Application.Features.SailorRanks.Handlers.Commands
{
    public class DeleteSailorRankCommandHandler : IRequestHandler<DeleteSailorRankCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteSailorRankCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteSailorRankCommand request, CancellationToken cancellationToken)
        {
            var SailorRanks = await _unitOfWork.Repository<SailorRank>().Get(request.SailorRankId);

            if (SailorRanks == null)
                throw new NotFoundException(nameof(SailorRank), request.SailorRankId);

            await _unitOfWork.Repository<SailorRank>().Delete(SailorRanks);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
