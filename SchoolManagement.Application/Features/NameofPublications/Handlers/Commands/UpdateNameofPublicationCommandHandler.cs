using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.NameofPublication.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.NameofPublications.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;

namespace SchoolManagement.Application.Features.NameofPublications.Handlers.Commands
{
    public class UpdateNameofPublicationCommandHandler : IRequestHandler<UpdateNameofPublicationCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateNameofPublicationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateNameofPublicationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateNameofPublicationDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.NameofPublicationDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var NameofPublication = await _unitOfWork.Repository<NameofPublication>().Get(request.NameofPublicationDto.NameofPublicationId);

            if (NameofPublication is null)
                throw new NotFoundException(nameof(NameofPublication), request.NameofPublicationDto.NameofPublicationId);

            _mapper.Map(request.NameofPublicationDto, NameofPublication);

            await _unitOfWork.Repository<NameofPublication>().Update(NameofPublication);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
