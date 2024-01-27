using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.LocalAgent.Validators;
using SchoolManagement.Application.Features.LocalAgents.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.LocalAgents.Handlers.Commands
{
    public class CreateLocalAgentCommandHandler : IRequestHandler<CreateLocalAgentCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateLocalAgentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateLocalAgentCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateLocalAgentDtoValidator();
            var validationResult = await validator.ValidateAsync(request.LocalAgentDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var LocalAgent = _mapper.Map<LocalAgent>(request.LocalAgentDto);

                LocalAgent = await _unitOfWork.Repository<LocalAgent>().Add(LocalAgent);
               
                    await _unitOfWork.Save();
                
               


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = LocalAgent.LocalAgentId;
            }

            return response;
        }
    }
}
