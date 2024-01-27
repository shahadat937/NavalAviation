using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.ItemInspection.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ItemInspections.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;

namespace SchoolManagement.Application.Features.ItemInspections.Handlers.Commands
{
    public class UpdateItemInspectionCommandHandler : IRequestHandler<UpdateItemInspectionCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateItemInspectionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateItemInspectionCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateItemInspectionDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.ItemInspectionDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var ItemInspection = await _unitOfWork.Repository<ItemInspection>().Get(request.ItemInspectionDto.ItemInspectionId);

            if (ItemInspection is null)
                throw new NotFoundException(nameof(ItemInspection), request.ItemInspectionDto.ItemInspectionId);

            _mapper.Map(request.ItemInspectionDto, ItemInspection);

            await _unitOfWork.Repository<ItemInspection>().Update(ItemInspection);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
