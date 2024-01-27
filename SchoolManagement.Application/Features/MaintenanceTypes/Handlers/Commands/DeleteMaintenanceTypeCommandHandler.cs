using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.MaintenanceTypes.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.MaintenanceTypes.Handlers.Commands
{
    public class DeleteMaintenanceTypeCommandHandler : IRequestHandler<DeleteMaintenanceTypeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteMaintenanceTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteMaintenanceTypeCommand request, CancellationToken cancellationToken)
        {
            var MaintenanceType = await _unitOfWork.Repository<MaintenanceType>().Get(request.MaintenanceTypeId);

            if (MaintenanceType == null)
                throw new NotFoundException(nameof(MaintenanceType), request.MaintenanceTypeId);

            await _unitOfWork.Repository<MaintenanceType>().Delete(MaintenanceType);
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
