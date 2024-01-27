using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.GseMaintenances.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.GseMaintenances.Handlers.Commands
{
    public class DeleteGseMaintenanceCommandHandler : IRequestHandler<DeleteGseMaintenanceCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteGseMaintenanceCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteGseMaintenanceCommand request, CancellationToken cancellationToken)
        {
            var GseMaintenance = await _unitOfWork.Repository<GseMaintenance>().Get(request.GseMaintenanceId);

            if (GseMaintenance == null)
                throw new NotFoundException(nameof(GseMaintenance), request.GseMaintenanceId);

            await _unitOfWork.Repository<GseMaintenance>().Delete(GseMaintenance);
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
