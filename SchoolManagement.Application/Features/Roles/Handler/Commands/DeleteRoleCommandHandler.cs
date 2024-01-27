using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Roles.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.Roles.Handler.Commands
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteRoleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await _unitOfWork.Repository<Role>().Get(request.RoleId);

            if (role == null)
                throw new NotFoundException(nameof(Role), request.RoleId);

            await _unitOfWork.Repository<Role>().Delete(role);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}