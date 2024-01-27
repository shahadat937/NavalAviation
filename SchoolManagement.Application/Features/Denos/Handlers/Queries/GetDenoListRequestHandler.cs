using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.DTOs.Denos;
using SchoolManagement.Application.Features.Denos.Requests.Queries;

namespace SchoolManagement.Application.Features.Denos.Handlers.Queries
{
    public class GetDenoListRequestHandler : IRequestHandler<GetDenoListRequest, PagedResult<DenoDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.Deno> _DenoRepository;

        private readonly IMapper _mapper;

        public GetDenoListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.Deno> DenoRepository, IMapper mapper)
        {
            _DenoRepository = DenoRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<DenoDto>> Handle(GetDenoListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.Deno> Denos = _DenoRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = Denos.Count();
            Denos = Denos.OrderByDescending(x => x.DenoId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var DenoDtos = _mapper.Map<List<DenoDto>>(Denos);
            var result = new PagedResult<DenoDto>(DenoDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
