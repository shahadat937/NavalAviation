using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.ItemStors.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.ItemStors.Handlers.Queries
{
    public class GetCalibrationStateListForToolsSpRequestHandler : IRequestHandler<GetCalibrationStateListForToolsSpRequest, object>
    {

        private readonly ISchoolManagementRepository<ItemStor> _studentInfoByTraineeIdRepository;

        private readonly IMapper _mapper;

        public GetCalibrationStateListForToolsSpRequestHandler(ISchoolManagementRepository<ItemStor> studentInfoByTraineeIdRepository, IMapper mapper)
        {
            _studentInfoByTraineeIdRepository = studentInfoByTraineeIdRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetCalibrationStateListForToolsSpRequest request, CancellationToken cancellationToken)
        {
           // object obj = new object();
            var spQuery = String.Format("exec [spGetCalibrationStateListForTools] {0},'{1}'", request.DepartmentNameId,request.SearchText);

            DataTable dataTable = _studentInfoByTraineeIdRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
