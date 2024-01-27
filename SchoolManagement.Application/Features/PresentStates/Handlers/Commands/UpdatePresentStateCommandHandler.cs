using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.PresentState.Validators;
using SchoolManagement.Application.Features.PresentStates.Requests.Commands;

namespace SchoolManagement.Application.Features.PresentStates.Handlers.Commands
{
    public class UpdatePresentStateCommandHandler : IRequestHandler<UpdatePresentStateCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdatePresentStateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdatePresentStateCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdatePresentStateDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.PresentStateDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var PresentState = await _unitOfWork.Repository<PresentState>().Get(request.PresentStateDto.PresentStateId);

            if (PresentState is null)
                throw new NotFoundException(nameof(PresentState), request.PresentStateDto.PresentStateId);

            _mapper.Map(request.PresentStateDto, PresentState);

            await _unitOfWork.Repository<PresentState>().Update(PresentState);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
