using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Role.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Roles.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.Roles.Handler.Commands
{
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateRoleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateRoleDtoValidator();
            var validationResult = await validator.ValidateAsync(request.RoleDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var role = await _unitOfWork.Repository<Role>().Get(request.RoleDto.RoleId);

            if (role is null)
                throw new NotFoundException(nameof(role), request.RoleDto.RoleId);

            _mapper.Map(request.RoleDto, role);

            await _unitOfWork.Repository<Role>().Update(role);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}