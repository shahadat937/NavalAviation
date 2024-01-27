using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.DemandAuthorities.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.DemandAuthorities.Handlers.Commands
{
    public class DeleteDemandAuthorityCommandHandler : IRequestHandler<DeleteDemandAuthorityCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteDemandAuthorityCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteDemandAuthorityCommand request, CancellationToken cancellationToken)
        {
            var DemandAuthority = await _unitOfWork.Repository<DemandAuthority>().Get(request.DemandAuthorityId);

            if (DemandAuthority == null)
                throw new NotFoundException(nameof(DemandAuthority), request.DemandAuthorityId);

            await _unitOfWork.Repository<DemandAuthority>().Delete(DemandAuthority);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
