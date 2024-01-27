using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ProcurementStatus;
using SchoolManagement.Application.Features.ProcurementStatuses.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.ProcurementStatuses.Handlers.Queries
{
    public class GetProcurementStatusDetailRequestHandler : IRequestHandler<GetProcurementStatusDetailRequest, ProcurementStatusDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<ProcurementStatus> _ProcurementStatusRepository;
        public GetProcurementStatusDetailRequestHandler(ISchoolManagementRepository<ProcurementStatus> ProcurementStatusRepository, IMapper mapper)
        {
            _ProcurementStatusRepository = ProcurementStatusRepository;
            _mapper = mapper;
        }
        public async Task<ProcurementStatusDto> Handle(GetProcurementStatusDetailRequest request, CancellationToken cancellationToken)
        {
            var ProcurementStatus = await _ProcurementStatusRepository.Get(request.ProcurementStatusId);
            return _mapper.Map<ProcurementStatusDto>(ProcurementStatus);
        }
    }
}
