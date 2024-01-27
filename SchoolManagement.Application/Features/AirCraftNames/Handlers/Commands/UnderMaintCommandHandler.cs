using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.AirCraftNames.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.AirCraftNames.Handlers.Commands
{
    public class UnderMaintCommandHandler : IRequestHandler<UnderMaintCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UnderMaintCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UnderMaintCommand request, CancellationToken cancellationToken)
        {
            var AcStatusCheck = await _unitOfWork.Repository<AcStatus>().Get(request.AcStatusId);
            AcStatusCheck.AircraftStatusCheck = 1;

            await _unitOfWork.Repository<AcStatus>().Update(AcStatusCheck);
            await _unitOfWork.Save();

            var AirCraftName = await _unitOfWork.Repository<AirCraftName>().Get(AcStatusCheck.AirCraftNameId);
            AirCraftName.AircraftStatus = 1;

            if (AirCraftName == null)
                throw new NotFoundException(nameof(AirCraftName), AcStatusCheck.AirCraftNameId);

            await _unitOfWork.Repository<AirCraftName>().Update(AirCraftName);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
