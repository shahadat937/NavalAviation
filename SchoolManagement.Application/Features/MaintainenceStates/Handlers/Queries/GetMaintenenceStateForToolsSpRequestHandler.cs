using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.ItemStors.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.ItemStors.Handlers.Queries
{
    public class GetMaintenenceStateForToolsSpRequestHandler : IRequestHandler<GetMaintenenceStateForToolsSpRequest, object>
    {

        private readonly ISchoolManagementRepository<ItemStor> _studentInfoByTraineeIdRepository;

        private readonly IMapper _mapper;

        public GetMaintenenceStateForToolsSpRequestHandler(ISchoolManagementRepository<ItemStor> studentInfoByTraineeIdRepository, IMapper mapper)
        {
            _studentInfoByTraineeIdRepository = studentInfoByTraineeIdRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetMaintenenceStateForToolsSpRequest request, CancellationToken cancellationToken)
        {
           // object obj = new object();
            var spQuery = String.Format("exec [spGetMaintenenceStateForTools] {0}", request.DepartmentNameId);

            DataTable dataTable = _studentInfoByTraineeIdRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
