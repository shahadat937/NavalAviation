using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ShelfLifeCategory.Validators;
using SchoolManagement.Application.Features.ShelfLifeCategorys.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.ShelfLifeCategorys.Handlers.Commands
{
    public class CreateShelfLifeCategoryCommandHandler : IRequestHandler<CreateShelfLifeCategoryCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateShelfLifeCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateShelfLifeCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateShelfLifeCategoryDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ShelfLifeCategoryDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var ShelfLifeCategory = _mapper.Map<ShelfLifeCategory>(request.ShelfLifeCategoryDto);

                ShelfLifeCategory = await _unitOfWork.Repository<ShelfLifeCategory>().Add(ShelfLifeCategory);
               
                    await _unitOfWork.Save();
                
               


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = ShelfLifeCategory.ShelfLifeCategoryId;
            }

            return response;
        }
    }
}
