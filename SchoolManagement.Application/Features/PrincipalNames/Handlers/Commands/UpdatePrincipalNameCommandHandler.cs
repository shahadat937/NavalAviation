using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.PrincipalName.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.PrincipalNames.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;

namespace SchoolManagement.Application.Features.PrincipalNames.Handlers.Commands
{
    public class UpdatePrincipalNameCommandHandler : IRequestHandler<UpdatePrincipalNameCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdatePrincipalNameCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdatePrincipalNameCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdatePrincipalNameDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.PrincipalNameDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var PrincipalName = await _unitOfWork.Repository<PrincipalName>().Get(request.PrincipalNameDto.PrincipalNameId);

            if (PrincipalName is null)
                throw new NotFoundException(nameof(PrincipalName), request.PrincipalNameDto.PrincipalNameId);

            _mapper.Map(request.PrincipalNameDto, PrincipalName);

            await _unitOfWork.Repository<PrincipalName>().Update(PrincipalName);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
