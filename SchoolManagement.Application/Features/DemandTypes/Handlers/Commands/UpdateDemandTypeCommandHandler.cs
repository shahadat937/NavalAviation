using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.DemandType.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.DemandTypes.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;

namespace SchoolManagement.Application.Features.DemandTypes.Handlers.Commands
{
    public class UpdateDemandTypeCommandHandler : IRequestHandler<UpdateDemandTypeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateDemandTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateDemandTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateDemandTypeDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.DemandTypeDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var DemandType = await _unitOfWork.Repository<DemandType>().Get(request.DemandTypeDto.DemandTypeId);

            if (DemandType is null)
                throw new NotFoundException(nameof(DemandType), request.DemandTypeDto.DemandTypeId);

            _mapper.Map(request.DemandTypeDto, DemandType);

            await _unitOfWork.Repository<DemandType>().Update(DemandType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
