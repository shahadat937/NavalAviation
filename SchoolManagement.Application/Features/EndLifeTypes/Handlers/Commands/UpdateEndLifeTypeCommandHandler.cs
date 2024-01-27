using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.EndLifeTypes.Validators;
using SchoolManagement.Application.Features.EndLifeTypes.Requests.Commands;

namespace SchoolManagement.Application.Features.EndLifeTypes.Handlers.Commands
{
    public class UpdateEndLifeTypeCommandHandler : IRequestHandler<UpdateEndLifeTypeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateEndLifeTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateEndLifeTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateEndLifeTypeDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.EndLifeTypeDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var EndLifeType = await _unitOfWork.Repository<EndLifeType>().Get(request.EndLifeTypeDto.EndLifeTypeId);

            if (EndLifeType is null)
                throw new NotFoundException(nameof(EndLifeType), request.EndLifeTypeDto.EndLifeTypeId);

            _mapper.Map(request.EndLifeTypeDto, EndLifeType);

            await _unitOfWork.Repository<EndLifeType>().Update(EndLifeType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
