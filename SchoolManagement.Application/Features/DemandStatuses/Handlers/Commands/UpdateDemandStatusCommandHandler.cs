using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.DemandStatus.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.DemandStatuses.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;

namespace SchoolManagement.Application.Features.DemandStatuses.Handlers.Commands
{
    public class UpdateDemandStatusCommandHandler : IRequestHandler<UpdateDemandStatusCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateDemandStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateDemandStatusCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateDemandStatusDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.DemandStatusDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var DemandStatus = await _unitOfWork.Repository<DemandStatus>().Get(request.DemandStatusDto.DemandStatusId);

            if (DemandStatus is null)
                throw new NotFoundException(nameof(DemandStatus), request.DemandStatusDto.DemandStatusId);

            _mapper.Map(request.DemandStatusDto, DemandStatus);

            await _unitOfWork.Repository<DemandStatus>().Update(DemandStatus);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
