using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.UserTransferBackups;
using SchoolManagement.Application.Features.UserTransferBackups.Requests.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.UserTransferBackups.Handlers.Queries
{
    public class GetUserTransferBackupDetailRequestHandler : IRequestHandler<GetUserTransferBackupDetailRequest, UserTransferBackupDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.UserTransferBackup> _UserTransferBackupRepository;
        public GetUserTransferBackupDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.UserTransferBackup> UserTransferBackupRepository, IMapper mapper)
        {
            _UserTransferBackupRepository = UserTransferBackupRepository;
            _mapper = mapper;
        }
        public async Task<UserTransferBackupDto> Handle(GetUserTransferBackupDetailRequest request, CancellationToken cancellationToken)
        {
            var UserTransferBackup = await _UserTransferBackupRepository.Get(request.Id);
            return _mapper.Map<UserTransferBackupDto>(UserTransferBackup);
        }
    }
}
