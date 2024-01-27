using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.NoticeBoards.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.NoticeBoards.Handlers.Commands
{
    public class DeleteNoticeBoardCommandHandler : IRequestHandler<DeleteNoticeBoardCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteNoticeBoardCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteNoticeBoardCommand request, CancellationToken cancellationToken)
        {
            var NoticeBoard = await _unitOfWork.Repository<NoticeBoard>().Get(request.NoticeBoardId);

            if (NoticeBoard == null)
                throw new NotFoundException(nameof(NoticeBoard), request.NoticeBoardId);

            await _unitOfWork.Repository<NoticeBoard>().Delete(NoticeBoard);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
