using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.IssueStatuses.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.IssueStatuses.Handlers.Commands
{
    public class DeleteIssueStatusCommandHandler : IRequestHandler<DeleteIssueStatusCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteIssueStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteIssueStatusCommand request, CancellationToken cancellationToken)
        {
            var IssueStatus = await _unitOfWork.Repository<IssueStatus>().Get(request.IssueStatusId);

            if (IssueStatus == null)
                throw new NotFoundException(nameof(IssueStatus), request.IssueStatusId);

            await _unitOfWork.Repository<IssueStatus>().Delete(IssueStatus);
            try
            {
                await _unitOfWork.Save();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
            //await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
