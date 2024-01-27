using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.AirCraftNames.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.AirCraftNames.Handlers.Commands
{
    public class OperationalCommandHandler : IRequestHandler<OperationalCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OperationalCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(OperationalCommand request, CancellationToken cancellationToken)
        {
            var AirCraftName = await _unitOfWork.Repository<AirCraftName>().Get(request.AirCraftNameId);
            AirCraftName.AircraftStatus = 0;

            if (AirCraftName == null)
                throw new NotFoundException(nameof(AirCraftName), request.AirCraftNameId);

            await _unitOfWork.Repository<AirCraftName>().Update(AirCraftName);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
