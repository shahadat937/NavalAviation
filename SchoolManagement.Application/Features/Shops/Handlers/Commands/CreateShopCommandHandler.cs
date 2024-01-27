using AutoMapper;
using SchoolManagement.Application.DTOs.Shop.Validators;
using SchoolManagement.Application.Features.Shops.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.Shops.Handlers.Commands
{
    public class CreateShopCommandHandler : IRequestHandler<CreateShopCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateShopCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateShopCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateShopDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ShopDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var Shop = _mapper.Map<Shop>(request.ShopDto);

                Shop = await _unitOfWork.Repository<Shop>().Add(Shop);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = Shop.ShopId;
            }

            return response;
        }
    }
}
