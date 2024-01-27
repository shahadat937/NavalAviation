using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.DTOs.UserTransferBackups;
using SchoolManagement.Application.Features.UserTransferBackups.Requests.Queries;

namespace SchoolManagement.Application.Features.UserTransferBackups.Handlers.Queries
{
    public class GetUserTransferBackupListRequestHandler : IRequestHandler<GetUserTransferBackupListRequest, PagedResult<UserTransferBackupDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.UserTransferBackup> _UserTransferBackupRepository;

        private readonly IMapper _mapper;

        public GetUserTransferBackupListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.UserTransferBackup> UserTransferBackupRepository, IMapper mapper)
        {
            _UserTransferBackupRepository = UserTransferBackupRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<UserTransferBackupDto>> Handle(GetUserTransferBackupListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.UserTransferBackup> UserTransferBackups = _UserTransferBackupRepository.FilterWithInclude(x => (x.FirstName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = UserTransferBackups.Count();
            UserTransferBackups = UserTransferBackups.OrderByDescending(x => x.Id).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var UserTransferBackupDtos = _mapper.Map<List<UserTransferBackupDto>>(UserTransferBackups);
            var result = new PagedResult<UserTransferBackupDto>(UserTransferBackupDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
