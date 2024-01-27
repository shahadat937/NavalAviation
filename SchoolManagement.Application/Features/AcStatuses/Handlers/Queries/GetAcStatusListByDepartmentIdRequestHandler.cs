using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.AcStatus;
using SchoolManagement.Application.Features.AcStatuses.Requests.Queries;
using SchoolManagement.Application.Features.AcStatuses.Requests.Queries;

namespace SchoolManagement.Application.Features.AcStatuses.Handlers.Queries
{
    public class GetAcStatusListByDepartmentIdRequestHandler : IRequestHandler<GetAcStatusListByDepartmentIdRequest, List<AcStatusDto>>
    {
        private readonly ISchoolManagementRepository<AcStatus> _AcStatusRepository;

        private readonly IMapper _mapper;
        public GetAcStatusListByDepartmentIdRequestHandler(ISchoolManagementRepository<AcStatus> AcStatusRepository, IMapper mapper)
        {
            _AcStatusRepository = AcStatusRepository;
            _mapper = mapper;
        }

        public async Task<List<AcStatusDto>> Handle(GetAcStatusListByDepartmentIdRequest request, CancellationToken cancellationToken)
        {
            IQueryable<AcStatus> AcStatuss = _AcStatusRepository.FilterWithInclude(x => x.DepartmentNameId == request.DepartmentNameId , "AirCraftName", "Status");

            var AcStatusDtos = _mapper.Map<List<AcStatusDto>>(AcStatuss);

            return AcStatusDtos;
        }

    }
}
