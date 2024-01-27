using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.DTOs.PresentBillets;
using SchoolManagement.Application.Features.PresentBillets.Requests.Queries;

namespace SchoolManagement.Application.Features.PresentBillets.Handlers.Queries
{
    public class GetPresentBilletListRequestHandler : IRequestHandler<GetPresentBilletListRequest, PagedResult<PresentBilletDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.PresentBillet> _PresentBilletRepository;

        private readonly IMapper _mapper;

        public GetPresentBilletListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.PresentBillet> PresentBilletRepository, IMapper mapper)
        {
            _PresentBilletRepository = PresentBilletRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<PresentBilletDto>> Handle(GetPresentBilletListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.PresentBillet> PresentBillets = _PresentBilletRepository.FilterWithInclude(x => (x.PresentBilletName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = PresentBillets.Count();
            PresentBillets = PresentBillets.OrderByDescending(x => x.PresentBilletId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var PresentBilletDtos = _mapper.Map<List<PresentBilletDto>>(PresentBillets);
            var result = new PagedResult<PresentBilletDto>(PresentBilletDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
