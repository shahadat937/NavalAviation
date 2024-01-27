using AutoMapper;
using SchoolManagement.Application.DTOs.TestEquipmentDetail;
using SchoolManagement.Application.Features.TestEquipmentDetails.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using SchoolManagement.Application.Models;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.TestEquipmentDetails.Handlers.Queries
{
    public class GetTestEquipmentDetailListRequestHandler : IRequestHandler<GetTestEquipmentDetailListRequest, PagedResult<TestEquipmentDetailDto>>
    {

        private readonly ISchoolManagementRepository<TestEquipmentDetail> _TestEquipmentDetailRepository;

        private readonly IMapper _mapper;

        public GetTestEquipmentDetailListRequestHandler(ISchoolManagementRepository<TestEquipmentDetail> TestEquipmentDetailRepository, IMapper mapper)
        {
            _TestEquipmentDetailRepository = TestEquipmentDetailRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<TestEquipmentDetailDto>> Handle(GetTestEquipmentDetailListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<TestEquipmentDetail> TestEquipmentDetails = _TestEquipmentDetailRepository.FilterWithInclude(x => (x.PattNo.Contains(request.QueryParams.SearchText) || x.EquipmentName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "Shop");
            var totalCount = TestEquipmentDetails.Count();
            TestEquipmentDetails = TestEquipmentDetails.OrderByDescending(x => x.TestEquipmentDetailId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var TestEquipmentDetailDtos = _mapper.Map<List<TestEquipmentDetailDto>>(TestEquipmentDetails);
            var result = new PagedResult<TestEquipmentDetailDto>(TestEquipmentDetailDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
