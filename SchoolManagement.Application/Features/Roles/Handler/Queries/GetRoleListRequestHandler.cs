using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Role;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Features.Roles.Requests.Queries;
using SchoolManagement.Application.Models;
using SchoolManagement.Domain;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Application.Features.Roles.Handler.Queries
{
    public class GetRoleListRequestHandler : IRequestHandler<GetRoleListRequest, PagedResult<RoleDto>>
    { 

        private readonly ISchoolManagementRepository<Role> _branchRepository; 

        private readonly IMapper _mapper;

        public GetRoleListRequestHandler(ISchoolManagementRepository<Role> branchRepository, IMapper mapper)
        {
            _branchRepository = branchRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<RoleDto>> Handle(GetRoleListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult.ToString());

            IQueryable<Role> branches = _branchRepository.FilterWithInclude(x => (x.RoleName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = branches.Count();
            branches = branches.OrderByDescending(x => x.RoleId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var branchesDtos = _mapper.Map<List<RoleDto>>(branches);
            var result = new PagedResult<RoleDto>(branchesDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;
        }
    }
}
