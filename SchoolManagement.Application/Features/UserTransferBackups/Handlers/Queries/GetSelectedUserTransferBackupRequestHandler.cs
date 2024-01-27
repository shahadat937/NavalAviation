using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.UserTransferBackups.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.UserTransferBackups.Handlers.Queries
{
    public class GetSelectedUserTransferBackupRequestHandler : IRequestHandler<GetSelectedUserTransferBackupRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<UserTransferBackup> _UserTransferBackupRepository;


        public GetSelectedUserTransferBackupRequestHandler(ISchoolManagementRepository<UserTransferBackup> UserTransferBackupRepository)
        {
            _UserTransferBackupRepository = UserTransferBackupRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedUserTransferBackupRequest request, CancellationToken cancellationToken)
        {
            ICollection<UserTransferBackup> codeValues = await _UserTransferBackupRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.FirstName,
                Value = x.Id
            }).ToList();
            return selectModels;
        }
    }
}
