using SchoolManagement.Application.Features.Manufactures.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Manufacture;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.Manufactures.Handlers.Queries
{
    public class GetManufactureListRequestHandler : IRequestHandler<GetManufactureListRequest, PagedResult<ManufactureDto>>
    {

        private readonly ISchoolManagementRepository<Manufacture> _ManufactureRepository;

        private readonly IMapper _mapper;

        public GetManufactureListRequestHandler(ISchoolManagementRepository<Manufacture> ManufactureRepository, IMapper mapper)
        {
            _ManufactureRepository = ManufactureRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<ManufactureDto>> Handle(GetManufactureListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<Manufacture> UTOfficerCategories = _ManufactureRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = UTOfficerCategories.Count();
            UTOfficerCategories = UTOfficerCategories.OrderByDescending(x => x.ManufactureId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var ManufactureDtos = _mapper.Map<List<ManufactureDto>>(UTOfficerCategories);
            var result = new PagedResult<ManufactureDto>(ManufactureDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
