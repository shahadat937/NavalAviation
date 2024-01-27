using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.LifeLimitItem.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.LifeLimitItems.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;

namespace SchoolManagement.Application.Features.LifeLimitItems.Handlers.Commands
{
    public class UpdateLifeLimitItemCommandHandler : IRequestHandler<UpdateLifeLimitItemCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateLifeLimitItemCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateLifeLimitItemCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLifeLimitItemDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.LifeLimitItemDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var LifeLimitItem = await _unitOfWork.Repository<LifeLimitItem>().Get(request.LifeLimitItemDto.LifeLimitItemId);

            if (LifeLimitItem is null)
                throw new NotFoundException(nameof(LifeLimitItem), request.LifeLimitItemDto.LifeLimitItemId);

            _mapper.Map(request.LifeLimitItemDto, LifeLimitItem);

            await _unitOfWork.Repository<LifeLimitItem>().Update(LifeLimitItem);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
