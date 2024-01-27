using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.Authority.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Authoritys.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;

namespace SchoolManagement.Application.Features.Authoritys.Handlers.Commands
{
    public class UpdateAuthorityCommandHandler : IRequestHandler<UpdateAuthorityCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateAuthorityCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateAuthorityCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateAuthorityDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.AuthorityDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var Authority = await _unitOfWork.Repository<Authority>().Get(request.AuthorityDto.AuthorityId);

            if (Authority is null)
                throw new NotFoundException(nameof(Authority), request.AuthorityDto.AuthorityId);

            _mapper.Map(request.AuthorityDto, Authority);

            await _unitOfWork.Repository<Authority>().Update(Authority);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
