using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.UserTransferBackups.Validators;
using SchoolManagement.Application.Features.UserTransferBackups.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.UserTransferBackups.Handlers.Commands
{
    public class CreateUserTransferBackupCommandHandler : IRequestHandler<CreateUserTransferBackupCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateUserTransferBackupCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateUserTransferBackupCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

              var userBackuplist = request.UserTransferBackupDto.Select(q => new UserTransferBackup()
              {
                  Id = q.Id,
                  FirstName = q.FirstName,
                  LastName = q.LastName,
                  UserName = q.UserName,
                  NormalizedUserName = q.NormalizedUserName,
                  Email = q.Email,
                  NormalizedEmail = q.NormalizedEmail,
                  EmailConfirmed = q.EmailConfirmed,
                  PasswordHash = q.PasswordHash,
                  SecurityStamp = q.SecurityStamp,
                  ConcurrencyStamp = q.ConcurrencyStamp,
                  PhoneNumber = q.PhoneNumber,
                  PhoneNumberConfirmed = q.PhoneNumberConfirmed,
                  TwoFactorEnabled = q.TwoFactorEnabled,
                  LockoutEnd = q.LockoutEnd,
                  LockoutEnabled = q.LockoutEnabled,
                  AccessFailedCount = q.AccessFailedCount,
                  CreatedBy = q.CreatedBy,
                  CreatedDate = q.CreatedDate,
                  InActiveBy = q.InActiveBy,
                  InActiveDate = q.InActiveDate,
                  TraineeId = q.TraineeId,
                  IsActive = q.IsActive,
                  RoleName = q.RoleName,
                  BranchId = q.BranchId,
                  TransferDate = DateTime.Now
              });

            await _unitOfWork.Repository<UserTransferBackup>().AddRangeAsync(userBackuplist);
            await _unitOfWork.Save();

            return response;
        }
    }
}
