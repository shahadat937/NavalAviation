using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.ToolsLocation.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.ToolsLocations.Requests.Commands;

namespace SchoolManagement.Application.Features.ToolsLocations.Handlers.Commands
{
    public class UpdateToolsLocationCommandHandler : IRequestHandler<UpdateToolsLocationCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateToolsLocationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateToolsLocationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateToolsLocationDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.ToolsLocationDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var ToolsLocation = await _unitOfWork.Repository<ToolsLocation>().Get(request.ToolsLocationDto.ToolsLocationId);

            if (ToolsLocation is null)
                throw new NotFoundException(nameof(ToolsLocation), request.ToolsLocationDto.ToolsLocationId);

            _mapper.Map(request.ToolsLocationDto, ToolsLocation);

            await _unitOfWork.Repository<ToolsLocation>().Update(ToolsLocation);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
