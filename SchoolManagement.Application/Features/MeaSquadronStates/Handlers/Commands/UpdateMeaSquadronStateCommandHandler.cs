using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.MeaSquadronState.Validators;
using SchoolManagement.Application.Features.MeaSquadronStates.Requests.Commands;

namespace SchoolManagement.Application.Features.MeaSquadronStates.Handlers.Commands
{
    public class UpdateMeaSquadronStateCommandHandler : IRequestHandler<UpdateMeaSquadronStateCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateMeaSquadronStateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateMeaSquadronStateCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateMeaSquadronStateDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.MeaSquadronStateDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var MeaSquadronState = await _unitOfWork.Repository<MeaSquadronState>().Get(request.MeaSquadronStateDto.MeaSquadronStateId);

            if (MeaSquadronState is null)
                throw new NotFoundException(nameof(MeaSquadronState), request.MeaSquadronStateDto.MeaSquadronStateId);

            _mapper.Map(request.MeaSquadronStateDto, MeaSquadronState);

            await _unitOfWork.Repository<MeaSquadronState>().Update(MeaSquadronState);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
