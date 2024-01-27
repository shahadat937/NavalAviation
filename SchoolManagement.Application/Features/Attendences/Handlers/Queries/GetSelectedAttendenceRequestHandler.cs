using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.Attendences.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.Attendences.Handlers.Queries
{
    public class GetSelectedAttendenceRequestHandler : IRequestHandler<GetSelectedAttendenceRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<Attendence> _AttendenceRepository;


        public GetSelectedAttendenceRequestHandler(ISchoolManagementRepository<Attendence> AttendenceRepository)
        {
            _AttendenceRepository = AttendenceRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedAttendenceRequest request, CancellationToken cancellationToken)
        {
            ICollection<Attendence> codeValues = await _AttendenceRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.AttendenceDate,
                Value = x.AttendenceId
            }).ToList();
            return selectModels;
        }
    }
}
