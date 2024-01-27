using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Status.Validators;
using SchoolManagement.Application.Features.Statuses.Requests.Commands;

namespace SchoolManagement.Application.Features.Statuses.Handlers.Commands
{
    public class UpdateStatusCommandHandler : IRequestHandler<UpdateStatusCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateStatusCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateStatusDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.StatusDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var Status = await _unitOfWork.Repository<Status>().Get(request.StatusDto.StatusId);

            if (Status is null)
                throw new NotFoundException(nameof(Status), request.StatusDto.StatusId);

            _mapper.Map(request.StatusDto, Status);

            await _unitOfWork.Repository<Status>().Update(Status);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
