using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.AccountType;
using SchoolManagement.Application.Features.AccountTypes.Requests.Queries;

namespace SchoolManagement.Application.Features.AccountTypes.Handlers.Queries
{
    public class GetAccountTypeDetailRequestHandler : IRequestHandler<GetAccountTypeDetailRequest, AccountTypeDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.AccountType> _AccountTypeRepository;
        public GetAccountTypeDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.AccountType> AccountTypeRepository, IMapper mapper)
        {
            _AccountTypeRepository = AccountTypeRepository;
            _mapper = mapper;
        }
        public async Task<AccountTypeDto> Handle(GetAccountTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var AccountType = await _AccountTypeRepository.Get(request.AccountTypeId);
            return _mapper.Map<AccountTypeDto>(AccountType);
        }
    }
}
