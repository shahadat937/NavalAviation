using SchoolManagement.Application.Features.Attendences.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Attendence;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;


namespace SchoolManagement.Application.Features.Attendences.Handlers.Queries
{
    public class GetAttendenceListRequestHandler : IRequestHandler<GetAttendenceListRequest, PagedResult<AttendenceDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.Attendence> _AttendenceRepository;

        private readonly IMapper _mapper;

        public GetAttendenceListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.Attendence> AttendenceRepository, IMapper mapper)
        {
            _AttendenceRepository = AttendenceRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<AttendenceDto>> Handle(GetAttendenceListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.Attendence> UTOfficerCategories = _AttendenceRepository.FilterWithInclude(x => (x.Remarks.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = UTOfficerCategories.Count();
            UTOfficerCategories = UTOfficerCategories.OrderByDescending(x => x.AttendenceId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var AttendenceDtos = _mapper.Map<List<AttendenceDto>>(UTOfficerCategories);
            var result = new PagedResult<AttendenceDto>(AttendenceDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
