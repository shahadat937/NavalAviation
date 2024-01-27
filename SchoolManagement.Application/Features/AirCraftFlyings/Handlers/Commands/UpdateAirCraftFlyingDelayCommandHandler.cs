using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.AirCraftFlying.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.AirCraftFlyings.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;

namespace SchoolManagement.Application.Features.AirCraftFlyings.Handlers.Commands
{
    public class UpdateAirCraftFlyingDelayCommandHandler : IRequestHandler<UpdateAirCraftFlyingDelayCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateAirCraftFlyingDelayCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateAirCraftFlyingDelayCommand request, CancellationToken cancellationToken)
        {
        //    var validator = new UpdateAirCraftFlyingDtoValidator(); 
        //     var validationResult = await validator.ValidateAsync(request.AirCraftFlyingDto);

        //    if (validationResult.IsValid == false)
        //        throw new ValidationException(validationResult);

            var AirCraftFlying = await _unitOfWork.Repository<AirCraftFlying>().Get(request.AirCraftFlyingDto.AirCraftFlyingId);

            if (AirCraftFlying is null)
                throw new NotFoundException(nameof(AirCraftFlying), request.AirCraftFlyingDto.AirCraftFlyingId);

            // AirCraftFlying.StartUpDelay = AirCraftFlying.StartUp;
           // AirCraftFlying.StartUp = request.AirCraftFlyingDto.

            _mapper.Map(request.AirCraftFlyingDto, AirCraftFlying);
            AirCraftFlying.StartUpStatus = 0;
            
            
            await _unitOfWork.Repository<AirCraftFlying>().Update(AirCraftFlying);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
