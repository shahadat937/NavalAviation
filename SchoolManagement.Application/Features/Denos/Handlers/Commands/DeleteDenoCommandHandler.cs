using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Denos.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.Denos.Handlers.Commands
{
    public class DeleteDenoCommandHandler : IRequestHandler<DeleteDenoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteDenoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteDenoCommand request, CancellationToken cancellationToken)
        {
            var Deno = await _unitOfWork.Repository<Deno>().Get(request.DenoId);

            if (Deno == null)
                throw new NotFoundException(nameof(Deno), request.DenoId);

            await _unitOfWork.Repository<Deno>().Delete(Deno);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
