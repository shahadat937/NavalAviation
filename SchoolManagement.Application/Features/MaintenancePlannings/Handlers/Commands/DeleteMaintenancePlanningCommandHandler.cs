using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.MaintenancePlannings.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.MaintenancePlannings.Handlers.Commands
{
    public class DeleteMaintenancePlanningCommandHandler : IRequestHandler<DeleteMaintenancePlanningCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteMaintenancePlanningCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteMaintenancePlanningCommand request, CancellationToken cancellationToken)
        {
            var MaintenancePlanning = await _unitOfWork.Repository<MaintenancePlanning>().Get(request.MaintenancePlanningId);

            if (MaintenancePlanning == null)
                throw new NotFoundException(nameof(MaintenancePlanning), request.MaintenancePlanningId);

            await _unitOfWork.Repository<MaintenancePlanning>().Delete(MaintenancePlanning);
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
