using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.DTOs.CstTec;
using SchoolManagement.Application.Features.CstTecs.Requests.Queries;

namespace SchoolManagement.Application.Features.CstTecs.Handlers.Queries
{
    public class GetCstTecListRequestHandler : IRequestHandler<GetCstTecListRequest, PagedResult<CstTecDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.CstTec> _CstTecRepository;

        private readonly IMapper _mapper;

        public GetCstTecListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.CstTec> CstTecRepository, IMapper mapper)
        {
            _CstTecRepository = CstTecRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<CstTecDto>> Handle(GetCstTecListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.CstTec> CstTecs = _CstTecRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = CstTecs.Count();
            CstTecs = CstTecs.OrderByDescending(x => x.CstTecId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var CstTecDtos = _mapper.Map<List<CstTecDto>>(CstTecs);
            var result = new PagedResult<CstTecDto>(CstTecDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
