using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.MaintenanceSubCategory.Validators;
using SchoolManagement.Application.Features.MaintenanceSubCategorys.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.MaintenanceSubCategorys.Handlers.Commands
{
    public class CreateMaintenanceSubCategoryCommandHandler : IRequestHandler<CreateMaintenanceSubCategoryCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateMaintenanceSubCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateMaintenanceSubCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateMaintenanceSubCategoryDtoValidator();
            var validationResult = await validator.ValidateAsync(request.MaintenanceSubCategoryDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var MaintenanceSubCategory = _mapper.Map<MaintenanceSubCategory>(request.MaintenanceSubCategoryDto);

                MaintenanceSubCategory = await _unitOfWork.Repository<MaintenanceSubCategory>().Add(MaintenanceSubCategory);
               
                    await _unitOfWork.Save();
                
               


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = MaintenanceSubCategory.MaintenanceSubCategoryId;
            }

            return response;
        }
    }
}
