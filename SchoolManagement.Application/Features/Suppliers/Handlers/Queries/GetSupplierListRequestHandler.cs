using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.DTOs.Suppliers;
using SchoolManagement.Application.Features.Suppliers.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.Suppliers.Handlers.Queries
{
    public class GetSupplierListRequestHandler : IRequestHandler<GetSupplierListRequest, PagedResult<SupplierDto>>
    {

        private readonly ISchoolManagementRepository<Supplier> _SupplierRepository;

        private readonly IMapper _mapper;

        public GetSupplierListRequestHandler(ISchoolManagementRepository<Supplier> SupplierRepository, IMapper mapper)
        {
            _SupplierRepository = SupplierRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<SupplierDto>> Handle(GetSupplierListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<Supplier> Suppliers = _SupplierRepository.FilterWithInclude(x => (x.CompanyName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = Suppliers.Count();
            Suppliers = Suppliers.OrderByDescending(x => x.SupplierId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var SupplierDtos = _mapper.Map<List<SupplierDto>>(Suppliers);
            var result = new PagedResult<SupplierDto>(SupplierDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
