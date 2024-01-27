using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.ItemCategoryType.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ItemCategoryTypes.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;

namespace SchoolManagement.Application.Features.ItemCategoryTypes.Handlers.Commands
{
    public class UpdateItemCategoryTypeCommandHandler : IRequestHandler<UpdateItemCategoryTypeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateItemCategoryTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateItemCategoryTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateItemCategoryTypeDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.ItemCategoryTypeDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var ItemCategoryType = await _unitOfWork.Repository<ItemCategoryType>().Get(request.ItemCategoryTypeDto.ItemCategoryTypeId);

            if (ItemCategoryType is null)
                throw new NotFoundException(nameof(ItemCategoryType), request.ItemCategoryTypeDto.ItemCategoryTypeId);

            _mapper.Map(request.ItemCategoryTypeDto, ItemCategoryType);

            await _unitOfWork.Repository<ItemCategoryType>().Update(ItemCategoryType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
