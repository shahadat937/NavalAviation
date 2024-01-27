using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.Attendence.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Attendences.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;

namespace SchoolManagement.Application.Features.Attendences.Handlers.Commands
{
    public class UpdateAttendenceCommandHandler : IRequestHandler<UpdateAttendenceCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateAttendenceCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateAttendenceCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateAttendenceDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.AttendenceDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var Attendence = await _unitOfWork.Repository<Attendence>().Get(request.AttendenceDto.AttendenceId);

            if (Attendence is null)
                throw new NotFoundException(nameof(Attendence), request.AttendenceDto.AttendenceId);

            _mapper.Map(request.AttendenceDto, Attendence);

            await _unitOfWork.Repository<Attendence>().Update(Attendence);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
