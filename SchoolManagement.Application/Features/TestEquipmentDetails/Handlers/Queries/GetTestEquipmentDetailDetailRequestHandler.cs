using AutoMapper;
using SchoolManagement.Application.DTOs.TestEquipmentDetail;
using SchoolManagement.Application.Features.TestEquipmentDetails.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.TestEquipmentDetails.Handlers.Queries
{
    public class GetTestEquipmentDetailDetailRequestHandler : IRequestHandler<GetTestEquipmentDetailDetailRequest, TestEquipmentDetailDto>
    {
       // private readonly IUTOfficerTypeRepository _UTOfficerTypeRepository;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<TestEquipmentDetail> _TestEquipmentDetailRepository;
        public GetTestEquipmentDetailDetailRequestHandler(ISchoolManagementRepository<TestEquipmentDetail> TestEquipmentDetailRepository, IMapper mapper)
        {
            _TestEquipmentDetailRepository = TestEquipmentDetailRepository;
            _mapper = mapper;
        }
        public async Task<TestEquipmentDetailDto> Handle(GetTestEquipmentDetailDetailRequest request, CancellationToken cancellationToken)
        {
            var TestEquipmentDetail = await _TestEquipmentDetailRepository.Get(request.TestEquipmentDetailId);
            return _mapper.Map<TestEquipmentDetailDto>(TestEquipmentDetail);
        }
    }
}
