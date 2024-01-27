using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ToolsBoxNames.Validators;
using SchoolManagement.Application.Features.ToolsBoxNames.Requests.Commands;

namespace SchoolManagement.Application.Features.ToolsBoxNames.Handlers.Commands
{
    public class UpdateToolsBoxNameCommandHandler : IRequestHandler<UpdateToolsBoxNameCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateToolsBoxNameCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateToolsBoxNameCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateToolsBoxNameDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.ToolsBoxNameDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var ToolsBoxName = await _unitOfWork.Repository<ToolsBoxName>().Get(request.ToolsBoxNameDto.ToolsBoxNameId);

            if (ToolsBoxName is null)
                throw new NotFoundException(nameof(ToolsBoxName), request.ToolsBoxNameDto.ToolsBoxNameId);

            _mapper.Map(request.ToolsBoxNameDto, ToolsBoxName);

            await _unitOfWork.Repository<ToolsBoxName>().Update(ToolsBoxName);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
