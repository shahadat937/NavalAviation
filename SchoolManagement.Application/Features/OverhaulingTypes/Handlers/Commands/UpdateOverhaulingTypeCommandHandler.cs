using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.OverhaulingType.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.OverhaulingTypes.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;

namespace SchoolManagement.Application.Features.OverhaulingTypes.Handlers.Commands
{
    public class UpdateOverhaulingTypeCommandHandler : IRequestHandler<UpdateOverhaulingTypeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateOverhaulingTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateOverhaulingTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateOverhaulingTypeDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.OverhaulingTypeDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var OverhaulingType = await _unitOfWork.Repository<OverhaulingType>().Get(request.OverhaulingTypeDto.OverhaulingTypeId);

            if (OverhaulingType is null)
                throw new NotFoundException(nameof(OverhaulingType), request.OverhaulingTypeDto.OverhaulingTypeId);

            _mapper.Map(request.OverhaulingTypeDto, OverhaulingType);

            await _unitOfWork.Repository<OverhaulingType>().Update(OverhaulingType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
