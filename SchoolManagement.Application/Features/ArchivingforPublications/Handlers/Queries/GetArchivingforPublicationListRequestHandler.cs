using SchoolManagement.Application.Features.ArchivingforPublications.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ArchivingforPublication;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;


namespace SchoolManagement.Application.Features.ArchivingforPublications.Handlers.Queries
{
    public class GetArchivingforPublicationListRequestHandler : IRequestHandler<GetArchivingforPublicationListRequest, PagedResult<ArchivingforPublicationDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.ArchivingforPublication> _ArchivingforPublicationRepository;

        private readonly IMapper _mapper;

        public GetArchivingforPublicationListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.ArchivingforPublication> ArchivingforPublicationRepository, IMapper mapper)
        {
            _ArchivingforPublicationRepository = ArchivingforPublicationRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<ArchivingforPublicationDto>> Handle(GetArchivingforPublicationListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.ArchivingforPublication> UTOfficerCategories = _ArchivingforPublicationRepository.FilterWithInclude(x => (x.DocumentName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = UTOfficerCategories.Count();
            UTOfficerCategories = UTOfficerCategories.OrderByDescending(x => x.ArchivingforPublicationId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var ArchivingforPublicationDtos = _mapper.Map<List<ArchivingforPublicationDto>>(UTOfficerCategories);
            var result = new PagedResult<ArchivingforPublicationDto>(ArchivingforPublicationDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
