using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.EndLifeTypes.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.EndLifeTypes.Handlers.Commands
{
    public class DeleteEndLifeTypeCommandHandler : IRequestHandler<DeleteEndLifeTypeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteEndLifeTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteEndLifeTypeCommand request, CancellationToken cancellationToken)
        {
            var EndLifeType = await _unitOfWork.Repository<EndLifeType>().Get(request.EndLifeTypeId);

            if (EndLifeType == null)
                throw new NotFoundException(nameof(EndLifeType), request.EndLifeTypeId);

            await _unitOfWork.Repository<EndLifeType>().Delete(EndLifeType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
