using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.ItemDetail.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ItemDetails.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;

namespace SchoolManagement.Application.Features.ItemDetails.Handlers.Commands
{
    public class UpdateItemDetailCommandHandler : IRequestHandler<UpdateItemDetailCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateItemDetailCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateItemDetailCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateItemDetailDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.ItemDetailDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var ItemDetail = await _unitOfWork.Repository<ItemDetail>().Get(request.ItemDetailDto.ItemDetailId);

            if (ItemDetail is null)
                throw new NotFoundException(nameof(ItemDetail), request.ItemDetailDto.ItemDetailId);

            _mapper.Map(request.ItemDetailDto, ItemDetail);

            await _unitOfWork.Repository<ItemDetail>().Update(ItemDetail);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
