using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.Manufacture.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Manufactures.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;

namespace SchoolManagement.Application.Features.Manufactures.Handlers.Commands
{
    public class UpdateManufactureCommandHandler : IRequestHandler<UpdateManufactureCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateManufactureCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateManufactureCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateManufactureDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.ManufactureDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var Manufacture = await _unitOfWork.Repository<Manufacture>().Get(request.ManufactureDto.ManufactureId);

            if (Manufacture is null)
                throw new NotFoundException(nameof(Manufacture), request.ManufactureDto.ManufactureId);

            _mapper.Map(request.ManufactureDto, Manufacture);

            await _unitOfWork.Repository<Manufacture>().Update(Manufacture);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
