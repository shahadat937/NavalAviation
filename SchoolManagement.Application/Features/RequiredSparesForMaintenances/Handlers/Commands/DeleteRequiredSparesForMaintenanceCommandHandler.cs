using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.RequiredSparesForMaintenances.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.RequiredSparesForMaintenances.Handlers.Commands
{
    public class DeleteRequiredSparesForMaintenanceCommandHandler : IRequestHandler<DeleteRequiredSparesForMaintenanceCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteRequiredSparesForMaintenanceCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteRequiredSparesForMaintenanceCommand request, CancellationToken cancellationToken)
        {
            var RequiredSparesForMaintenance = await _unitOfWork.Repository<RequiredSparesForMaintenance>().Get(request.RequiredSparesForMaintenanceId);

            if (RequiredSparesForMaintenance == null)
                throw new NotFoundException(nameof(RequiredSparesForMaintenance), request.RequiredSparesForMaintenanceId);

            await _unitOfWork.Repository<RequiredSparesForMaintenance>().Delete(RequiredSparesForMaintenance);
            try
            {
                await _unitOfWork.Save();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
            //await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
