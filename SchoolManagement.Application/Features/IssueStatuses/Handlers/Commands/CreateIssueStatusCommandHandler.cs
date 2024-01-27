using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.IssueStatus.Validators;
using SchoolManagement.Application.Features.IssueStatuses.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.IssueStatuses.Handlers.Commands
{
    public class CreateIssueStatusCommandHandler : IRequestHandler<CreateIssueStatusCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateIssueStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateIssueStatusCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateIssueStatusDtoValidator();
            var validationResult = await validator.ValidateAsync(request.IssueStatusDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var IssueStatus = _mapper.Map<IssueStatus>(request.IssueStatusDto);

                IssueStatus = await _unitOfWork.Repository<IssueStatus>().Add(IssueStatus);
               
                    await _unitOfWork.Save();
                
               


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = IssueStatus.IssueStatusId;
            }

            return response;
        }
    }
}
