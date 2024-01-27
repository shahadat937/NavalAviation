using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.ItemCategories.Requests.Commands;
using SchoolManagement.Application.DTOs.ItemCategory.Validators;

namespace SchoolManagement.Application.Features.ItemCategories.Handlers.Commands
{
    public class UpdateItemCategoryCommandHandler : IRequestHandler<UpdateItemCategoryCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateItemCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateItemCategoryCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateItemCategoryDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.ItemCategoryDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var ItemCategory = await _unitOfWork.Repository<ItemCategory>().Get(request.ItemCategoryDto.ItemCategoryId);

            if (ItemCategory is null)
                throw new NotFoundException(nameof(ItemCategory), request.ItemCategoryDto.ItemCategoryId);

            _mapper.Map(request.ItemCategoryDto, ItemCategory);

            await _unitOfWork.Repository<ItemCategory>().Update(ItemCategory);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
