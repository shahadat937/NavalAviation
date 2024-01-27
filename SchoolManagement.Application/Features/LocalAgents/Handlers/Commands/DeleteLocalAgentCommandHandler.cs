using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.LocalAgents.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.LocalAgents.Handlers.Commands
{
    public class DeleteLocalAgentCommandHandler : IRequestHandler<DeleteLocalAgentCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteLocalAgentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteLocalAgentCommand request, CancellationToken cancellationToken)
        {
            var LocalAgent = await _unitOfWork.Repository<LocalAgent>().Get(request.LocalAgentId);

            if (LocalAgent == null)
                throw new NotFoundException(nameof(LocalAgent), request.LocalAgentId);

            await _unitOfWork.Repository<LocalAgent>().Delete(LocalAgent);
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
