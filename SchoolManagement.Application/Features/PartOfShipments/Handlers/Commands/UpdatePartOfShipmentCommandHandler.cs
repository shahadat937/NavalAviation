using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.PartOfShipment.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.PartOfShipments.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;

namespace SchoolManagement.Application.Features.PartOfShipments.Handlers.Commands
{
    public class UpdatePartOfShipmentCommandHandler : IRequestHandler<UpdatePartOfShipmentCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdatePartOfShipmentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdatePartOfShipmentCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdatePartOfShipmentDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.PartOfShipmentDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var PartOfShipment = await _unitOfWork.Repository<PartOfShipment>().Get(request.PartOfShipmentDto.PartOfShipmentId);

            if (PartOfShipment is null)
                throw new NotFoundException(nameof(PartOfShipment), request.PartOfShipmentDto.PartOfShipmentId);

            _mapper.Map(request.PartOfShipmentDto, PartOfShipment);

            await _unitOfWork.Repository<PartOfShipment>().Update(PartOfShipment);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
