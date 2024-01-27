using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.MaintenanceCategory.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.MaintenanceCategories.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;

namespace SchoolManagement.Application.Features.MaintenanceCategories.Handlers.Commands
{
    public class UpdateMaintenanceCategoryCommandHandler : IRequestHandler<UpdateMaintenanceCategoryCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateMaintenanceCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateMaintenanceCategoryCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateMaintenanceCategoryDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.MaintenanceCategoryDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var MaintenanceCategory = await _unitOfWork.Repository<MaintenanceCategory>().Get(request.MaintenanceCategoryDto.MaintenanceCategoryId);

            if (MaintenanceCategory is null)
                throw new NotFoundException(nameof(MaintenanceCategory), request.MaintenanceCategoryDto.MaintenanceCategoryId);

            _mapper.Map(request.MaintenanceCategoryDto, MaintenanceCategory);

            await _unitOfWork.Repository<MaintenanceCategory>().Update(MaintenanceCategory);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
