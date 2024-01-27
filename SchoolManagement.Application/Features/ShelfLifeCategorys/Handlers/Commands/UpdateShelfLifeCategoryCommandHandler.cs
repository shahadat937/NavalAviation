using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.ShelfLifeCategory.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ShelfLifeCategorys.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;

namespace SchoolManagement.Application.Features.ShelfLifeCategorys.Handlers.Commands
{
    public class UpdateShelfLifeCategoryCommandHandler : IRequestHandler<UpdateShelfLifeCategoryCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateShelfLifeCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateShelfLifeCategoryCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateShelfLifeCategoryDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.ShelfLifeCategoryDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var ShelfLifeCategory = await _unitOfWork.Repository<ShelfLifeCategory>().Get(request.ShelfLifeCategoryDto.ShelfLifeCategoryId);

            if (ShelfLifeCategory is null)
                throw new NotFoundException(nameof(ShelfLifeCategory), request.ShelfLifeCategoryDto.ShelfLifeCategoryId);

            _mapper.Map(request.ShelfLifeCategoryDto, ShelfLifeCategory);

            await _unitOfWork.Repository<ShelfLifeCategory>().Update(ShelfLifeCategory);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
