using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Ranks.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.Ranks.Handlers.Commands
{
    public class DeleteRankCommandHandler : IRequestHandler<DeleteRankCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteRankCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteRankCommand request, CancellationToken cancellationToken)
        {
            var Rank = await _unitOfWork.Repository<Rank>().Get(request.RankId);

            if (Rank == null)
                throw new NotFoundException(nameof(Rank), request.RankId);

            await _unitOfWork.Repository<Rank>().Delete(Rank);
            try
            {
                await _unitOfWork.Save();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
            //await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
