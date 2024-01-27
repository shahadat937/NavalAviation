using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.DegitalArchieveDocType.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.DegitalArchieveDocTypes.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;

namespace SchoolManagement.Application.Features.DegitalArchieveDocTypes.Handlers.Commands
{
    public class UpdateDegitalArchieveDocTypeCommandHandler : IRequestHandler<UpdateDegitalArchieveDocTypeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateDegitalArchieveDocTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateDegitalArchieveDocTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateDegitalArchieveDocTypeDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.DegitalArchieveDocTypeDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var DegitalArchieveDocType = await _unitOfWork.Repository<DegitalArchieveDocType>().Get(request.DegitalArchieveDocTypeDto.DegitalArchieveDocTypeId);

            if (DegitalArchieveDocType is null)
                throw new NotFoundException(nameof(DegitalArchieveDocType), request.DegitalArchieveDocTypeDto.DegitalArchieveDocTypeId);

            _mapper.Map(request.DegitalArchieveDocTypeDto, DegitalArchieveDocType);

            await _unitOfWork.Repository<DegitalArchieveDocType>().Update(DegitalArchieveDocType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
