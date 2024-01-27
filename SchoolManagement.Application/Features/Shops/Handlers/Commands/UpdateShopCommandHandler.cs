using AutoMapper;
using SchoolManagement.Application.DTOs.Shop.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Shops.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;

namespace SchoolManagement.Application.Features.Shops.Handlers.Commands
{
    public class UpdateShopCommandHandler : IRequestHandler<UpdateShopCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateShopCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateShopCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateShopDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ShopDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var Shop = await _unitOfWork.Repository<Shop>().Get(request.ShopDto.ShopId);

            if (Shop is null)
                throw new NotFoundException(nameof(Shop), request.ShopDto.ShopId);

            _mapper.Map(request.ShopDto, Shop);

            await _unitOfWork.Repository<Shop>().Update(Shop);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
