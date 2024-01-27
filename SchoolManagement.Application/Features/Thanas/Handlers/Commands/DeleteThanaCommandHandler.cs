using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Thanas.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;

namespace SchoolManagement.Application.Features.Thanas.Handlers.Commands
{
    public class DeleteThanaCommandHandler : IRequestHandler<DeleteThanaCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteThanaCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteThanaCommand request, CancellationToken cancellationToken)
        {
            var Thanas = await _unitOfWork.Repository<Thana>().Get(request.ThanaId);

            if (Thanas == null)
                throw new NotFoundException(nameof(Thana), request.ThanaId);

            await _unitOfWork.Repository<Thana>().Delete(Thanas);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
