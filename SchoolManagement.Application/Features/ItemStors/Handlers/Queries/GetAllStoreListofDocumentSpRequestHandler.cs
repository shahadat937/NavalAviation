using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.ItemStors.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.ItemStors.Handlers.Queries
{
    public class GetAllStoreListofDocumentSpRequestHandler : IRequestHandler<GetAllStoreListofDocumentSpRequest, object>
    {

        private readonly ISchoolManagementRepository<ItemStor> _studentInfoByTraineeIdRepository;

        private readonly IMapper _mapper;

        public GetAllStoreListofDocumentSpRequestHandler(ISchoolManagementRepository<ItemStor> studentInfoByTraineeIdRepository, IMapper mapper)
        {
            _studentInfoByTraineeIdRepository = studentInfoByTraineeIdRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetAllStoreListofDocumentSpRequest request, CancellationToken cancellationToken)
        {
           // object obj = new object();
            var spQuery = String.Format("exec [spGetAllStoreListofDocument] {0}", request.ItemStorId);

            DataTable dataTable = _studentInfoByTraineeIdRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
