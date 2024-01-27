using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.OfficersStatus.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.OfficersStatuses.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;

namespace SchoolManagement.Application.Features.OfficersStatuses.Handlers.Commands
{
    public class UpdateOfficersStatusCommandHandler : IRequestHandler<UpdateOfficersStatusCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateOfficersStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateOfficersStatusCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateOfficersStatusDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.OfficersStatusDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var OfficersStatus = await _unitOfWork.Repository<OfficersStatus>().Get(request.OfficersStatusDto.OfficersStatusId);

            if (OfficersStatus is null)
                throw new NotFoundException(nameof(OfficersStatus), request.OfficersStatusDto.OfficersStatusId);

            _mapper.Map(request.OfficersStatusDto, OfficersStatus);

            await _unitOfWork.Repository<OfficersStatus>().Update(OfficersStatus);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
