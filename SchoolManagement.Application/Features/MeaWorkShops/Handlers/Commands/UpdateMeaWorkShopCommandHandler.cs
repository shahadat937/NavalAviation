using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.MeaWorkShop.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.MeaWorkShops.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;

namespace SchoolManagement.Application.Features.MeaWorkShops.Handlers.Commands
{
    public class UpdateMeaWorkShopCommandHandler : IRequestHandler<UpdateMeaWorkShopCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateMeaWorkShopCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateMeaWorkShopCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateMeaWorkShopDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.MeaWorkShopDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var MeaWorkShop = await _unitOfWork.Repository<MeaWorkShop>().Get(request.MeaWorkShopDto.MeaWorkShopId);

            if (MeaWorkShop is null)
                throw new NotFoundException(nameof(MeaWorkShop), request.MeaWorkShopDto.MeaWorkShopId);

            _mapper.Map(request.MeaWorkShopDto, MeaWorkShop);

            await _unitOfWork.Repository<MeaWorkShop>().Update(MeaWorkShop);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
