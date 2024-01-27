using SchoolManagement.Application.Features.NameofPublications.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.NameofPublication;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;


namespace SchoolManagement.Application.Features.NameofPublications.Handlers.Queries
{
    public class GetNameofPublicationListRequestHandler : IRequestHandler<GetNameofPublicationListRequest, PagedResult<NameofPublicationDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.NameofPublication> _NameofPublicationRepository;

        private readonly IMapper _mapper;

        public GetNameofPublicationListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.NameofPublication> NameofPublicationRepository, IMapper mapper)
        {
            _NameofPublicationRepository = NameofPublicationRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<NameofPublicationDto>> Handle(GetNameofPublicationListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.NameofPublication> UTOfficerCategories = _NameofPublicationRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "DepartmentName");
            var totalCount = UTOfficerCategories.Count();
            UTOfficerCategories = UTOfficerCategories.OrderByDescending(x => x.NameofPublicationId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var NameofPublicationDtos = _mapper.Map<List<NameofPublicationDto>>(UTOfficerCategories);
            var result = new PagedResult<NameofPublicationDto>(NameofPublicationDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
