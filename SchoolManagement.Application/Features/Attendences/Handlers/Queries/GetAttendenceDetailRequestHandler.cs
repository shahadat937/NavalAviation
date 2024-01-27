using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Attendence;
using SchoolManagement.Application.Features.Attendences.Requests.Queries;

namespace SchoolManagement.Application.Features.Attendences.Handlers.Queries
{
    public class GetAttendenceDetailRequestHandler : IRequestHandler<GetAttendenceDetailRequest, AttendenceDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.Attendence> _AttendenceRepository;
        public GetAttendenceDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.Attendence> AttendenceRepository, IMapper mapper)
        {
            _AttendenceRepository = AttendenceRepository;
            _mapper = mapper;
        }
        public async Task<AttendenceDto> Handle(GetAttendenceDetailRequest request, CancellationToken cancellationToken)
        {
            var Attendence = await _AttendenceRepository.Get(request.AttendenceId);
            return _mapper.Map<AttendenceDto>(Attendence);
        }
    }
}
