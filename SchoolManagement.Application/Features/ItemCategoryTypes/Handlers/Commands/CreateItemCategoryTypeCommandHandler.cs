using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ItemCategoryType.Validators;
using SchoolManagement.Application.Features.ItemCategoryTypes.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.ItemCategoryTypes.Handlers.Commands
{
    public class CreateItemCategoryTypeCommandHandler : IRequestHandler<CreateItemCategoryTypeCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateItemCategoryTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateItemCategoryTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateItemCategoryTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ItemCategoryTypeDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var ItemCategoryType = _mapper.Map<ItemCategoryType>(request.ItemCategoryTypeDto);

                ItemCategoryType = await _unitOfWork.Repository<ItemCategoryType>().Add(ItemCategoryType);
               
                    await _unitOfWork.Save();
                
               


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = ItemCategoryType.ItemCategoryTypeId;
            }

            return response;
        }
    }
}
