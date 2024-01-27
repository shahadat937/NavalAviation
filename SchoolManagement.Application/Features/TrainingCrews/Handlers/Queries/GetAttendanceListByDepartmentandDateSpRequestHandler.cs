using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.TrainingCrews.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.TrainingCrews.Handlers.Queries
{
    public class GetAttendanceListByDepartmentandDateSpRequestHandler : IRequestHandler<GetAttendanceListByDepartmentandDateSpRequest, object>
    {

        private readonly ISchoolManagementRepository<Attendence> _studentInfoByTraineeIdRepository;

        private readonly IMapper _mapper;
     
        public GetAttendanceListByDepartmentandDateSpRequestHandler(ISchoolManagementRepository<Attendence> studentInfoByTraineeIdRepository, IMapper mapper)
        {
            _studentInfoByTraineeIdRepository = studentInfoByTraineeIdRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetAttendanceListByDepartmentandDateSpRequest request, CancellationToken cancellationToken)
        {
           // object obj = new object();
            var spQuery = String.Format("exec [spGetAttendanceListByDepartmentNameAndDate] '{0}',{1},{2},'{3}'", request.AttendanceDate,request.DepartmentId,request.OfficerStatusId,request.SearchText);

            DataTable dataTable = _studentInfoByTraineeIdRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
