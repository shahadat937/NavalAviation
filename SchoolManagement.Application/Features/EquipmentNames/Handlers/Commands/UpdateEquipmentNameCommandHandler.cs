using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.EquipmentName.Validators;
using SchoolManagement.Application.Features.EquipmentNames.Requests.Commands;

namespace SchoolManagement.Application.Features.EquipmentNames.Handlers.Commands
{
    public class UpdateEquipmentNameCommandHandler : IRequestHandler<UpdateEquipmentNameCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateEquipmentNameCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateEquipmentNameCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateEquipmentNameDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.EquipmentNameDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var EquipmentName = await _unitOfWork.Repository<EquipmentName>().Get(request.EquipmentNameDto.EquipmentNameId);

            if (EquipmentName is null)
                throw new NotFoundException(nameof(EquipmentName), request.EquipmentNameDto.EquipmentNameId);

            _mapper.Map(request.EquipmentNameDto, EquipmentName);

            await _unitOfWork.Repository<EquipmentName>().Update(EquipmentName);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
