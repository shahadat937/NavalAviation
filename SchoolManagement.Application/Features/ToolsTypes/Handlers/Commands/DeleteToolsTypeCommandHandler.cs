using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ToolsTypes.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.ToolsTypes.Handlers.Commands
{
    public class DeleteToolsTypeCommandHandler : IRequestHandler<DeleteToolsTypeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteToolsTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteToolsTypeCommand request, CancellationToken cancellationToken)
        {
            var ToolsType = await _unitOfWork.Repository<ToolsType>().Get(request.ToolsTypeId);

            if (ToolsType == null)
                throw new NotFoundException(nameof(ToolsType), request.ToolsTypeId);

            await _unitOfWork.Repository<ToolsType>().Delete(ToolsType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
