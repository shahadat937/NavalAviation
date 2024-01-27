using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Procurement;
using SchoolManagement.Application.Features.Procurements.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.Procurements.Handlers.Queries
{
    public class GetSelectedProcurementByIdRequestHandler :  IRequestHandler<GetSelectedProcurementByIdRequest, List<ProcurementDto>>
    {
        private readonly ISchoolManagementRepository<Procurement> _ProcurementRepository;
        private readonly IMapper _mapper;


        public GetSelectedProcurementByIdRequestHandler(ISchoolManagementRepository<Procurement> ProcurementRepository, IMapper mapper)
        {
            _ProcurementRepository = ProcurementRepository;
            _mapper = mapper;
        }

        

        public async Task<List<ProcurementDto>> Handle(GetSelectedProcurementByIdRequest request, CancellationToken cancellationToken)
        {
            IQueryable<Procurement> Procurements = _ProcurementRepository.FilterWithInclude(x => x.ProcurementId == request.ProcurementId, "ItemDetail");
            

            var ProcurementDtos = _mapper.Map<List<ProcurementDto>>(Procurements);

            return ProcurementDtos;
        }
    }
}
