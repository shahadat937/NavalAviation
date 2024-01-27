using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ServiceLifeTypes.Validators;
using SchoolManagement.Application.Features.ServiceLifeTypes.Requests.Commands;

namespace SchoolManagement.Application.Features.ServiceLifeTypes.Handlers.Commands
{
    public class UpdateServiceLifeTypeCommandHandler : IRequestHandler<UpdateServiceLifeTypeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateServiceLifeTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateServiceLifeTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateServiceLifeTypeDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.ServiceLifeTypeDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var ServiceLifeType = await _unitOfWork.Repository<ServiceLifeType>().Get(request.ServiceLifeTypeDto.ServiceLifeTypeId);

            if (ServiceLifeType is null)
                throw new NotFoundException(nameof(ServiceLifeType), request.ServiceLifeTypeDto.ServiceLifeTypeId);

            _mapper.Map(request.ServiceLifeTypeDto, ServiceLifeType);

            await _unitOfWork.Repository<ServiceLifeType>().Update(ServiceLifeType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
