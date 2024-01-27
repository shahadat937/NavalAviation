using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.ItemStatuses.Requests.Commands;
using SchoolManagement.Application.DTOs.ItemStatuses.Validators;

namespace SchoolManagement.Application.Features.ItemStatuses.Handlers.Commands
{
    public class UpdateItemStatusCommandHandler : IRequestHandler<UpdateItemStatusCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateItemStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateItemStatusCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateItemStatusDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.ItemStatusDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var ItemStatus = await _unitOfWork.Repository<ItemStatus>().Get(request.ItemStatusDto.ItemStatusId);

            if (ItemStatus is null)
                throw new NotFoundException(nameof(ItemStatus), request.ItemStatusDto.ItemStatusId);

            _mapper.Map(request.ItemStatusDto, ItemStatus);

            await _unitOfWork.Repository<ItemStatus>().Update(ItemStatus);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
