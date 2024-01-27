using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.IssueRegisters.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.IssueRegisters.Handlers.Commands
{
    public class DeleteIssueRegisterCommandHandler : IRequestHandler<DeleteIssueRegisterCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteIssueRegisterCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteIssueRegisterCommand request, CancellationToken cancellationToken)
        {
            var IssueRegister = await _unitOfWork.Repository<IssueRegister>().Get(request.IssueRegisterId);

            if (IssueRegister == null)
                throw new NotFoundException(nameof(IssueRegister), request.IssueRegisterId);

            await _unitOfWork.Repository<IssueRegister>().Delete(IssueRegister);
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
