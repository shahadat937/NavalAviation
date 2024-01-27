using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.RetirementType.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.RetirementTypes.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;

namespace SchoolManagement.Application.Features.RetirementTypes.Handlers.Commands
{
    public class UpdateRetirementTypeCommandHandler : IRequestHandler<UpdateRetirementTypeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateRetirementTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateRetirementTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateRetirementTypeDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.RetirementTypeDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var RetirementType = await _unitOfWork.Repository<RetirementType>().Get(request.RetirementTypeDto.RetirementTypeId);

            if (RetirementType is null)
                throw new NotFoundException(nameof(RetirementType), request.RetirementTypeDto.RetirementTypeId);

            _mapper.Map(request.RetirementTypeDto, RetirementType);

            await _unitOfWork.Repository<RetirementType>().Update(RetirementType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
