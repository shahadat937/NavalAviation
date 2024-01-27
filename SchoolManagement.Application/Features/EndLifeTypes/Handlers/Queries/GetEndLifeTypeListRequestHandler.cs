using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.DTOs.EndLifeTypes;
using SchoolManagement.Application.Features.EndLifeTypes.Requests.Queries;

namespace SchoolManagement.Application.Features.EndLifeTypes.Handlers.Queries
{
    public class GetEndLifeTypeListRequestHandler : IRequestHandler<GetEndLifeTypeListRequest, PagedResult<EndLifeTypeDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.EndLifeType> _EndLifeTypeRepository;

        private readonly IMapper _mapper;

        public GetEndLifeTypeListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.EndLifeType> EndLifeTypeRepository, IMapper mapper)
        {
            _EndLifeTypeRepository = EndLifeTypeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<EndLifeTypeDto>> Handle(GetEndLifeTypeListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.EndLifeType> EndLifeTypes = _EndLifeTypeRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = EndLifeTypes.Count();
            EndLifeTypes = EndLifeTypes.OrderByDescending(x => x.EndLifeTypeId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var EndLifeTypeDtos = _mapper.Map<List<EndLifeTypeDto>>(EndLifeTypes);
            var result = new PagedResult<EndLifeTypeDto>(EndLifeTypeDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
