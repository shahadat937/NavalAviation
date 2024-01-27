using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ItemCategory.Validators;
using SchoolManagement.Application.Features.ItemCategories.Requests.Commands;
using SchoolManagement.Application.Responses; 
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.ItemCategories.Handlers.Commands
{
    public class CreateItemCategoryCommandHandler : IRequestHandler<CreateItemCategoryCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateItemCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateItemCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateItemCategoryDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ItemCategoryDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var ItemCategory = _mapper.Map<ItemCategory>(request.ItemCategoryDto);

                ItemCategory = await _unitOfWork.Repository<ItemCategory>().Add(ItemCategory);

                try
                {
                    await _unitOfWork.Save();
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex);
                }


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = ItemCategory.ItemCategoryId;
            }

            return response;
        }
    }
}
