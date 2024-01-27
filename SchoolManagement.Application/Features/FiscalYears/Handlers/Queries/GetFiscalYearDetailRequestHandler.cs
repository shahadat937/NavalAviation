using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.FiscalYears;
using SchoolManagement.Application.Features.FiscalYears.Requests.Queries;

namespace SchoolManagement.Application.Features.FiscalYears.Handlers.Queries
{
    public class GetFiscalYearDetailRequestHandler : IRequestHandler<GetFiscalYearDetailRequest, FiscalYearDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.FiscalYear> _FiscalYearRepository;
        public GetFiscalYearDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.FiscalYear> FiscalYearRepository, IMapper mapper)
        {
            _FiscalYearRepository = FiscalYearRepository;
            _mapper = mapper;
        }
        public async Task<FiscalYearDto> Handle(GetFiscalYearDetailRequest request, CancellationToken cancellationToken)
        {
            var FiscalYear = await _FiscalYearRepository.Get(request.FiscalYearId);
            return _mapper.Map<FiscalYearDto>(FiscalYear);
        }
    }
}
