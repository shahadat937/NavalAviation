using AutoMapper;
using SchoolManagement.Application.DTOs.Caste;
using SchoolManagement.Application.Features.Castes.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using SchoolManagement.Application.Models;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;

namespace SchoolManagement.Application.Features.Castes.Handlers.Queries
{
    public class GetCasteListRequestHandler : IRequestHandler<GetCasteListRequest, PagedResult<CasteDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.Caste> _CasteRepository;

        private readonly IMapper _mapper;

        public GetCasteListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.Caste> CasteRepository, IMapper mapper)
        {
            _CasteRepository = CasteRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<CasteDto>> Handle(GetCasteListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.Caste> Castes = _CasteRepository.FilterWithInclude(x => (x.CastName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "Religion");
            var totalCount = Castes.Count();
            Castes = Castes.OrderByDescending(x => x.CasteId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var CasteDtos = _mapper.Map<List<CasteDto>>(Castes);
            var result = new PagedResult<CasteDto>(CasteDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
