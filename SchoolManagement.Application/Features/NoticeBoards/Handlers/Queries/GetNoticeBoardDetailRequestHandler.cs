using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.NoticeBoards;
using SchoolManagement.Application.Features.NoticeBoards.Requests.Queries;

namespace SchoolManagement.Application.Features.NoticeBoards.Handlers.Queries
{
    public class GetNoticeBoardDetailRequestHandler : IRequestHandler<GetNoticeBoardDetailRequest, NoticeBoardDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.NoticeBoard> _NoticeBoardRepository;
        public GetNoticeBoardDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.NoticeBoard> NoticeBoardRepository, IMapper mapper)
        {
            _NoticeBoardRepository = NoticeBoardRepository;
            _mapper = mapper;
        }
        public async Task<NoticeBoardDto> Handle(GetNoticeBoardDetailRequest request, CancellationToken cancellationToken)
        {
            var NoticeBoard =  _NoticeBoardRepository.FinedOneInclude(x => x.NoticeBoardId == request.NoticeBoardId, "DepartmentName");
            return _mapper.Map<NoticeBoardDto>(NoticeBoard);
        }
    }
}
