using SchoolManagement.Application.Features.PartOfShipments.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.PartOfShipment;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.PartOfShipments.Handlers.Queries
{
    public class GetPartOfShipmentListRequestHandler : IRequestHandler<GetPartOfShipmentListRequest, PagedResult<PartOfShipmentDto>>
    {

        private readonly ISchoolManagementRepository<PartOfShipment> _PartOfShipmentRepository;

        private readonly IMapper _mapper;

        public GetPartOfShipmentListRequestHandler(ISchoolManagementRepository<PartOfShipment> PartOfShipmentRepository, IMapper mapper)
        {
            _PartOfShipmentRepository = PartOfShipmentRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<PartOfShipmentDto>> Handle(GetPartOfShipmentListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<PartOfShipment> UTOfficerCategories = _PartOfShipmentRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = UTOfficerCategories.Count();
            UTOfficerCategories = UTOfficerCategories.OrderByDescending(x => x.PartOfShipmentId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var PartOfShipmentDtos = _mapper.Map<List<PartOfShipmentDto>>(UTOfficerCategories);
            var result = new PagedResult<PartOfShipmentDto>(PartOfShipmentDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
