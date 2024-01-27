using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.NoticeBoards.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.NoticeBoards.Handlers.Queries
{ 
    public class GetTodayNoticeBoardSpRequestHandler : IRequestHandler<GetTodayNoticeBoardSpRequest, object>
    {

        private readonly ISchoolManagementRepository<NoticeBoard> _NoticeBoardRepository;

        private readonly IMapper _mapper;

        public GetTodayNoticeBoardSpRequestHandler(ISchoolManagementRepository<NoticeBoard> NoticeBoardRepository, IMapper mapper)
        {
            _NoticeBoardRepository = NoticeBoardRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetTodayNoticeBoardSpRequest request, CancellationToken cancellationToken)
        {
           // object obj = new object();
            var spQuery = String.Format("exec [spGetTodayNoticeBoardData] {0}", request.DepartmentId);

            DataTable dataTable = _NoticeBoardRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
