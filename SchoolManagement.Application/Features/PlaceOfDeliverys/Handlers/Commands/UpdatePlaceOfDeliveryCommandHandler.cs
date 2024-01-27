using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.PlaceOfDelivery.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.PlaceOfDeliverys.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;

namespace SchoolManagement.Application.Features.PlaceOfDeliverys.Handlers.Commands
{
    public class UpdatePlaceOfDeliveryCommandHandler : IRequestHandler<UpdatePlaceOfDeliveryCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdatePlaceOfDeliveryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdatePlaceOfDeliveryCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdatePlaceOfDeliveryDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.PlaceOfDeliveryDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var PlaceOfDelivery = await _unitOfWork.Repository<PlaceOfDelivery>().Get(request.PlaceOfDeliveryDto.PlaceOfDeliveryId);

            if (PlaceOfDelivery is null)
                throw new NotFoundException(nameof(PlaceOfDelivery), request.PlaceOfDeliveryDto.PlaceOfDeliveryId);

            _mapper.Map(request.PlaceOfDeliveryDto, PlaceOfDelivery);

            await _unitOfWork.Repository<PlaceOfDelivery>().Update(PlaceOfDelivery);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
