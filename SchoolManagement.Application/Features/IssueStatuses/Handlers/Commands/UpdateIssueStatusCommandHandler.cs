using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.IssueStatus.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.IssueStatuses.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;

namespace SchoolManagement.Application.Features.IssueStatuses.Handlers.Commands
{
    public class UpdateIssueStatusCommandHandler : IRequestHandler<UpdateIssueStatusCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateIssueStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateIssueStatusCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateIssueStatusDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.IssueStatusDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var IssueStatus = await _unitOfWork.Repository<IssueStatus>().Get(request.IssueStatusDto.IssueStatusId);

            if (IssueStatus is null)
                throw new NotFoundException(nameof(IssueStatus), request.IssueStatusDto.IssueStatusId);

            _mapper.Map(request.IssueStatusDto, IssueStatus);

            await _unitOfWork.Repository<IssueStatus>().Update(IssueStatus);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
