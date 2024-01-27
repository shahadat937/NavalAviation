using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ToolsTypes.Validators;
using SchoolManagement.Application.Features.ToolsTypes.Requests.Commands;

namespace SchoolManagement.Application.Features.ToolsTypes.Handlers.Commands
{
    public class UpdateToolsTypeCommandHandler : IRequestHandler<UpdateToolsTypeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateToolsTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateToolsTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateToolsTypeDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.ToolsTypeDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var ToolsType = await _unitOfWork.Repository<ToolsType>().Get(request.ToolsTypeDto.ToolsTypeId);

            if (ToolsType is null)
                throw new NotFoundException(nameof(ToolsType), request.ToolsTypeDto.ToolsTypeId);

            _mapper.Map(request.ToolsTypeDto, ToolsType);

            await _unitOfWork.Repository<ToolsType>().Update(ToolsType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
