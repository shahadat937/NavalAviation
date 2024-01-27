using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.DemandCompleteStatuses.Validators;
using SchoolManagement.Application.Features.DemandCompleteStatuses.Requests.Commands;

namespace SchoolManagement.Application.Features.DemandCompleteStatuses.Handlers.Commands
{
    public class UpdateDemandCompleteStatusCommandHandler : IRequestHandler<UpdateDemandCompleteStatusCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateDemandCompleteStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateDemandCompleteStatusCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateDemandCompleteStatusDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.DemandCompleteStatusDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var DemandCompleteStatus = await _unitOfWork.Repository<DemandCompleteStatus>().Get(request.DemandCompleteStatusDto.DemandCompleteStatusId);

            if (DemandCompleteStatus is null)
                throw new NotFoundException(nameof(DemandCompleteStatus), request.DemandCompleteStatusDto.DemandCompleteStatusId);

            _mapper.Map(request.DemandCompleteStatusDto, DemandCompleteStatus);

            await _unitOfWork.Repository<DemandCompleteStatus>().Update(DemandCompleteStatus);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
