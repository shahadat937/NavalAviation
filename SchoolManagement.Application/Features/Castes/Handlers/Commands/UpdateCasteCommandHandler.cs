using AutoMapper;
using SchoolManagement.Application.DTOs.Caste.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Castes.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;

namespace SchoolManagement.Application.Features.Castes.Handlers.Commands
{
    public class UpdateCasteCommandHandler : IRequestHandler<UpdateCasteCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCasteCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCasteCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCasteDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CasteDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var Castes = await _unitOfWork.Repository<Caste>().Get(request.CasteDto.CasteId);

            if (Castes is null)
                throw new NotFoundException(nameof(Caste), request.CasteDto.CasteId);

            _mapper.Map(request.CasteDto, Castes);

            await _unitOfWork.Repository<Caste>().Update(Castes);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
