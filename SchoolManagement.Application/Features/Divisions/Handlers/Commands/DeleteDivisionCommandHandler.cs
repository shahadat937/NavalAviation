using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Divisions.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;

namespace SchoolManagement.Application.Features.Divisions.Handlers.Commands
{
    public class DeleteDivisionCommandHandler : IRequestHandler<DeleteDivisionCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteDivisionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteDivisionCommand request, CancellationToken cancellationToken)
        {
            var Divisions = await _unitOfWork.Repository<Division>().Get(request.DivisionId);

            if (Divisions == null)
                throw new NotFoundException(nameof(Division), request.DivisionId);

            await _unitOfWork.Repository<Division>().Delete(Divisions);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
