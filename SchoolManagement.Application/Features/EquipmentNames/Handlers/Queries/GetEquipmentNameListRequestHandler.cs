using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.DTOs.EquipmentName;
using SchoolManagement.Application.Features.EquipmentNames.Requests.Queries;

namespace SchoolManagement.Application.Features.EquipmentNames.Handlers.Queries
{
    public class GetEquipmentNameListRequestHandler : IRequestHandler<GetEquipmentNameListRequest, PagedResult<EquipmentNameDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.EquipmentName> _EquipmentNameRepository;

        private readonly IMapper _mapper;

        public GetEquipmentNameListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.EquipmentName> EquipmentNameRepository, IMapper mapper)
        {
            _EquipmentNameRepository = EquipmentNameRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<EquipmentNameDto>> Handle(GetEquipmentNameListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.EquipmentName> EquipmentNames = _EquipmentNameRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = EquipmentNames.Count();
            EquipmentNames = EquipmentNames.OrderByDescending(x => x.EquipmentNameId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var EquipmentNameDtos = _mapper.Map<List<EquipmentNameDto>>(EquipmentNames);
            var result = new PagedResult<EquipmentNameDto>(EquipmentNameDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
