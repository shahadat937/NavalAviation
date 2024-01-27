using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ReminderType;
using SchoolManagement.Application.Features.ReminderTypes.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.ReminderTypes.Handlers.Queries
{
    public class GetReminderTypeDetailRequestHandler : IRequestHandler<GetReminderTypeDetailRequest, ReminderTypeDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<ReminderType> _ReminderTypeRepository;
        public GetReminderTypeDetailRequestHandler(ISchoolManagementRepository<ReminderType> ReminderTypeRepository, IMapper mapper)
        {
            _ReminderTypeRepository = ReminderTypeRepository;
            _mapper = mapper;
        }
        public async Task<ReminderTypeDto> Handle(GetReminderTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var ReminderType = await _ReminderTypeRepository.Get(request.ReminderTypeId);
            return _mapper.Map<ReminderTypeDto>(ReminderType);
        }
    }
}
