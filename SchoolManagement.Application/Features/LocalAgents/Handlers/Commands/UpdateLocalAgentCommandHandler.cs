using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.LocalAgent.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.LocalAgents.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;

namespace SchoolManagement.Application.Features.LocalAgents.Handlers.Commands
{
    public class UpdateLocalAgentCommandHandler : IRequestHandler<UpdateLocalAgentCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateLocalAgentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateLocalAgentCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLocalAgentDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.LocalAgentDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var LocalAgent = await _unitOfWork.Repository<LocalAgent>().Get(request.LocalAgentDto.LocalAgentId);

            if (LocalAgent is null)
                throw new NotFoundException(nameof(LocalAgent), request.LocalAgentDto.LocalAgentId);

            _mapper.Map(request.LocalAgentDto, LocalAgent);

            await _unitOfWork.Repository<LocalAgent>().Update(LocalAgent);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
