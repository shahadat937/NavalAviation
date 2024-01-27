using AutoMapper;
using SchoolManagement.Application.DTOs.Thana.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Thanas.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;

namespace SchoolManagement.Application.Features.Thanas.Handlers.Commands
{
    public class UpdateThanaCommandHandler : IRequestHandler<UpdateThanaCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateThanaCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateThanaCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateThanaDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ThanaDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var Thanas = await _unitOfWork.Repository<Thana>().Get(request.ThanaDto.ThanaId);

            if (Thanas is null)
                throw new NotFoundException(nameof(Thana), request.ThanaDto.ThanaId);

            _mapper.Map(request.ThanaDto, Thanas);

            await _unitOfWork.Repository<Thana>().Update(Thanas);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
