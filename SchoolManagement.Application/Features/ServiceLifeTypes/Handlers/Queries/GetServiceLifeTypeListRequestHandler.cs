using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.DTOs.ServiceLifeTypes;
using SchoolManagement.Application.Features.ServiceLifeTypes.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.ServiceLifeTypes.Handlers.Queries
{
    public class GetServiceLifeTypeListRequestHandler : IRequestHandler<GetServiceLifeTypeListRequest, PagedResult<ServiceLifeTypeDto>>
    {

        private readonly ISchoolManagementRepository<ServiceLifeType> _ServiceLifeTypeRepository;

        private readonly IMapper _mapper;

        public GetServiceLifeTypeListRequestHandler(ISchoolManagementRepository<ServiceLifeType> ServiceLifeTypeRepository, IMapper mapper)
        {
            _ServiceLifeTypeRepository = ServiceLifeTypeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<ServiceLifeTypeDto>> Handle(GetServiceLifeTypeListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<ServiceLifeType> ServiceLifeTypes = _ServiceLifeTypeRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = ServiceLifeTypes.Count();
            ServiceLifeTypes = ServiceLifeTypes.OrderByDescending(x => x.ServiceLifeTypeId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var ServiceLifeTypeDtos = _mapper.Map<List<ServiceLifeTypeDto>>(ServiceLifeTypes);
            var result = new PagedResult<ServiceLifeTypeDto>(ServiceLifeTypeDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
