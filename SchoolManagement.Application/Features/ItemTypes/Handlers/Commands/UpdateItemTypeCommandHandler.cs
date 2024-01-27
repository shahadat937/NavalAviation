using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ItemTypes.Validators;
using SchoolManagement.Application.Features.ItemTypes.Requests.Commands;

namespace SchoolManagement.Application.Features.ItemTypes.Handlers.Commands
{
    public class UpdateItemTypeCommandHandler : IRequestHandler<UpdateItemTypeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateItemTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateItemTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateItemTypeDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.ItemTypeDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var ItemType = await _unitOfWork.Repository<ItemType>().Get(request.ItemTypeDto.ItemTypeId);

            if (ItemType is null)
                throw new NotFoundException(nameof(ItemType), request.ItemTypeDto.ItemTypeId);

            _mapper.Map(request.ItemTypeDto, ItemType);

            await _unitOfWork.Repository<ItemType>().Update(ItemType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
