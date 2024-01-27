using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.MaintenanceSubCategory.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.MaintenanceSubCategorys.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;

namespace SchoolManagement.Application.Features.MaintenanceSubCategorys.Handlers.Commands
{
    public class UpdateMaintenanceSubCategoryCommandHandler : IRequestHandler<UpdateMaintenanceSubCategoryCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateMaintenanceSubCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateMaintenanceSubCategoryCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateMaintenanceSubCategoryDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.MaintenanceSubCategoryDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var MaintenanceSubCategory = await _unitOfWork.Repository<MaintenanceSubCategory>().Get(request.MaintenanceSubCategoryDto.MaintenanceSubCategoryId);

            if (MaintenanceSubCategory is null)
                throw new NotFoundException(nameof(MaintenanceSubCategory), request.MaintenanceSubCategoryDto.MaintenanceSubCategoryId);

            _mapper.Map(request.MaintenanceSubCategoryDto, MaintenanceSubCategory);

            await _unitOfWork.Repository<MaintenanceSubCategory>().Update(MaintenanceSubCategory);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
