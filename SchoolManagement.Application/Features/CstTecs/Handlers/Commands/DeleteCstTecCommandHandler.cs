using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.CstTecs.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.CstTecs.Handlers.Commands
{
    public class DeleteCstTecCommandHandler : IRequestHandler<DeleteCstTecCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteCstTecCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteCstTecCommand request, CancellationToken cancellationToken)
        {
            var CstTec = await _unitOfWork.Repository<CstTec>().Get(request.CstTecId);

            if (CstTec == null)
                throw new NotFoundException(nameof(CstTec), request.CstTecId);

            await _unitOfWork.Repository<CstTec>().Delete(CstTec);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
