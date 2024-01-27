using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.MaintenanceCategory.Validators;
using SchoolManagement.Application.Features.MaintenanceCategories.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.MaintenanceCategories.Handlers.Commands
{
    public class CreateMaintenanceCategoryCommandHandler : IRequestHandler<CreateMaintenanceCategoryCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateMaintenanceCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateMaintenanceCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateMaintenanceCategoryDtoValidator();
            var validationResult = await validator.ValidateAsync(request.MaintenanceCategoryDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var MaintenanceCategory = _mapper.Map<MaintenanceCategory>(request.MaintenanceCategoryDto);

                MaintenanceCategory = await _unitOfWork.Repository<MaintenanceCategory>().Add(MaintenanceCategory);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = MaintenanceCategory.MaintenanceCategoryId;
            }

            return response;
        }
    }
}
