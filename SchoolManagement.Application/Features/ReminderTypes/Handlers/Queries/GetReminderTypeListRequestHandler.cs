using SchoolManagement.Application.Features.ReminderTypes.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ReminderType;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.ReminderTypes.Handlers.Queries
{
    public class GetReminderTypeListRequestHandler : IRequestHandler<GetReminderTypeListRequest, PagedResult<ReminderTypeDto>>
    {

        private readonly ISchoolManagementRepository<ReminderType> _ReminderTypeRepository;

        private readonly IMapper _mapper;

        public GetReminderTypeListRequestHandler(ISchoolManagementRepository<ReminderType> ReminderTypeRepository, IMapper mapper)
        {
            _ReminderTypeRepository = ReminderTypeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<ReminderTypeDto>> Handle(GetReminderTypeListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<ReminderType> ReminderTypes = _ReminderTypeRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = ReminderTypes.Count();
            ReminderTypes = ReminderTypes.OrderByDescending(x => x.ReminderTypeId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var ReminderTypeDtos = _mapper.Map<List<ReminderTypeDto>>(ReminderTypes);
            var result = new PagedResult<ReminderTypeDto>(ReminderTypeDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
