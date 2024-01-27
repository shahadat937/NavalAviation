using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.NoticeBoards.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.NoticeBoards.Handlers.Queries
{
    public class GetSelectedNoticeBoardRequestHandler : IRequestHandler<GetSelectedNoticeBoardRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<NoticeBoard> _NoticeBoardRepository;


        public GetSelectedNoticeBoardRequestHandler(ISchoolManagementRepository<NoticeBoard> NoticeBoardRepository)
        {
            _NoticeBoardRepository = NoticeBoardRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedNoticeBoardRequest request, CancellationToken cancellationToken)
        {
            ICollection<NoticeBoard> codeValues = await _NoticeBoardRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Event,
                Value = x.NoticeBoardId
            }).ToList();
            return selectModels;
        }
    }
}
