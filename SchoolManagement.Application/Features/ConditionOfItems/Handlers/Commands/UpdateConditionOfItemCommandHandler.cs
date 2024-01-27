using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ConditionOfItems.Validators;
using SchoolManagement.Application.Features.ConditionOfItems.Requests.Commands;

namespace SchoolManagement.Application.Features.ConditionOfItems.Handlers.Commands
{
    public class UpdateConditionOfItemCommandHandler : IRequestHandler<UpdateConditionOfItemCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateConditionOfItemCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateConditionOfItemCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateConditionOfItemDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.ConditionOfItemDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var ConditionOfItem = await _unitOfWork.Repository<ConditionOfItem>().Get(request.ConditionOfItemDto.ConditionOfItemId);

            if (ConditionOfItem is null)
                throw new NotFoundException(nameof(ConditionOfItem), request.ConditionOfItemDto.ConditionOfItemId);

            _mapper.Map(request.ConditionOfItemDto, ConditionOfItem);

            await _unitOfWork.Repository<ConditionOfItem>().Update(ConditionOfItem);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
