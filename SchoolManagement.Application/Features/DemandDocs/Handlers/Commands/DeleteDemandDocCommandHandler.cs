using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.DemandDocs.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.DemandDocs.Handlers.Commands
{
    public class DeleteDemandDocCommandHandler : IRequestHandler<DeleteDemandDocCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteDemandDocCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteDemandDocCommand request, CancellationToken cancellationToken)
        {
            var DemandDoc = await _unitOfWork.Repository<DemandDoc>().Get(request.DemandDocId);

            if (DemandDoc == null)
                throw new NotFoundException(nameof(DemandDoc), request.DemandDocId);

            await _unitOfWork.Repository<DemandDoc>().Delete(DemandDoc);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
