using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ToolsBoxNames.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.ToolsBoxNames.Handlers.Commands
{
    public class DeleteToolsBoxNameCommandHandler : IRequestHandler<DeleteToolsBoxNameCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteToolsBoxNameCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteToolsBoxNameCommand request, CancellationToken cancellationToken)
        {
            var ToolsBoxName = await _unitOfWork.Repository<ToolsBoxName>().Get(request.ToolsBoxNameId);

            if (ToolsBoxName == null)
                throw new NotFoundException(nameof(ToolsBoxName), request.ToolsBoxNameId);

            await _unitOfWork.Repository<ToolsBoxName>().Delete(ToolsBoxName);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
