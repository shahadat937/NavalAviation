using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Religions.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;

namespace SchoolManagement.Application.Features.Religions.Handlers.Commands
{
    public class DeleteReligionCommandHandler : IRequestHandler<DeleteReligionCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteReligionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteReligionCommand request, CancellationToken cancellationToken)
        {
            var Religion = await _unitOfWork.Repository<Religion>().Get(request.ReligionId);

            if (Religion == null)
                throw new NotFoundException(nameof(Religion), request.ReligionId);

            await _unitOfWork.Repository<Religion>().Delete(Religion);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
