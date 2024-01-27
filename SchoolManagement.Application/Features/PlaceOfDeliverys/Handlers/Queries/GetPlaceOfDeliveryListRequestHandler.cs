using SchoolManagement.Application.Features.PlaceOfDeliverys.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.PlaceOfDelivery;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.PlaceOfDeliverys.Handlers.Queries
{
    public class GetPlaceOfDeliveryListRequestHandler : IRequestHandler<GetPlaceOfDeliveryListRequest, PagedResult<PlaceOfDeliveryDto>>
    {

        private readonly ISchoolManagementRepository<PlaceOfDelivery> _PlaceOfDeliveryRepository;

        private readonly IMapper _mapper;

        public GetPlaceOfDeliveryListRequestHandler(ISchoolManagementRepository<PlaceOfDelivery> PlaceOfDeliveryRepository, IMapper mapper)
        {
            _PlaceOfDeliveryRepository = PlaceOfDeliveryRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<PlaceOfDeliveryDto>> Handle(GetPlaceOfDeliveryListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<PlaceOfDelivery> UTOfficerCategories = _PlaceOfDeliveryRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = UTOfficerCategories.Count();
            UTOfficerCategories = UTOfficerCategories.OrderByDescending(x => x.PlaceOfDeliveryId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var PlaceOfDeliveryDtos = _mapper.Map<List<PlaceOfDeliveryDto>>(UTOfficerCategories);
            var result = new PagedResult<PlaceOfDeliveryDto>(PlaceOfDeliveryDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
