using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Castes.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;

namespace SchoolManagement.Application.Features.Castes.Handlers.Commands
{
    public class DeleteCasteCommandHandler : IRequestHandler<DeleteCasteCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteCasteCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteCasteCommand request, CancellationToken cancellationToken)
        {
            var Castes = await _unitOfWork.Repository<Caste>().Get(request.CasteId);

            if (Castes == null)
                throw new NotFoundException(nameof(Caste), request.CasteId);

            await _unitOfWork.Repository<Caste>().Delete(Castes);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
