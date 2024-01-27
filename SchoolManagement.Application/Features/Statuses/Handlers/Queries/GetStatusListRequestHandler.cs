using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.DTOs.Status;
using SchoolManagement.Application.Features.Statuses.Requests.Queries;

namespace SchoolManagement.Application.Features.Statuses.Handlers.Queries
{
    public class GetStatusListRequestHandler : IRequestHandler<GetStatusListRequest, PagedResult<StatusDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.Status> _StatusRepository;

        private readonly IMapper _mapper;

        public GetStatusListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.Status> StatusRepository, IMapper mapper)
        {
            _StatusRepository = StatusRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<StatusDto>> Handle(GetStatusListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.Status> Statuss = _StatusRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = Statuss.Count();
            Statuss = Statuss.OrderByDescending(x => x.StatusId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var StatusDtos = _mapper.Map<List<StatusDto>>(Statuss);
            var result = new PagedResult<StatusDto>(StatusDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
