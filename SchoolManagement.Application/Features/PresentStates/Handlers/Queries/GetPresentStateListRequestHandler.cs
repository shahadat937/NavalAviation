using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.DTOs.PresentState;
using SchoolManagement.Application.Features.PresentStates.Requests.Queries;

namespace SchoolManagement.Application.Features.PresentStates.Handlers.Queries
{
    public class GetPresentStateListRequestHandler : IRequestHandler<GetPresentStateListRequest, PagedResult<PresentStateDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.PresentState> _PresentStateRepository;

        private readonly IMapper _mapper;

        public GetPresentStateListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.PresentState> PresentStateRepository, IMapper mapper)
        {
            _PresentStateRepository = PresentStateRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<PresentStateDto>> Handle(GetPresentStateListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.PresentState> PresentStates = _PresentStateRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = PresentStates.Count();
            PresentStates = PresentStates.OrderByDescending(x => x.PresentStateId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var PresentStateDtos = _mapper.Map<List<PresentStateDto>>(PresentStates);
            var result = new PagedResult<PresentStateDto>(PresentStateDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
