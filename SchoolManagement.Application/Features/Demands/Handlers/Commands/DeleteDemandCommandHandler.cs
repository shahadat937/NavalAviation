using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Demands.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.Demands.Handlers.Commands
{
    public class DeleteDemandCommandHandler : IRequestHandler<DeleteDemandCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteDemandCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteDemandCommand request, CancellationToken cancellationToken)
        {
            var Demand = await _unitOfWork.Repository<Demand>().Get(request.DemandId);

            if (Demand == null)
                throw new NotFoundException(nameof(Demand), request.DemandId);

            await _unitOfWork.Repository<Demand>().Delete(Demand);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
