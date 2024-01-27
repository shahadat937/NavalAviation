using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.GseMaintenanceScheduleNames.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.GseMaintenanceScheduleNames.Handlers.Commands
{
    public class DeleteGseMaintenanceScheduleNameCommandHandler : IRequestHandler<DeleteGseMaintenanceScheduleNameCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteGseMaintenanceScheduleNameCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteGseMaintenanceScheduleNameCommand request, CancellationToken cancellationToken)
        {
            var GseMaintenanceScheduleName = await _unitOfWork.Repository<GseMaintenanceScheduleName>().Get(request.GseMaintenanceScheduleNameId);

            if (GseMaintenanceScheduleName == null)
                throw new NotFoundException(nameof(GseMaintenanceScheduleName), request.GseMaintenanceScheduleNameId);

            await _unitOfWork.Repository<GseMaintenanceScheduleName>().Delete(GseMaintenanceScheduleName);
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
