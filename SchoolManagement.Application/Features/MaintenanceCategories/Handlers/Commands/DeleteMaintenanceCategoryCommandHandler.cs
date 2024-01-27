using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.MaintenanceCategories.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.MaintenanceCategories.Handlers.Commands
{
    public class DeleteMaintenanceCategoryCommandHandler : IRequestHandler<DeleteMaintenanceCategoryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteMaintenanceCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteMaintenanceCategoryCommand request, CancellationToken cancellationToken)
        {
            var MaintenanceCategory = await _unitOfWork.Repository<MaintenanceCategory>().Get(request.MaintenanceCategoryId);

            if (MaintenanceCategory == null)
                throw new NotFoundException(nameof(MaintenanceCategory), request.MaintenanceCategoryId);

            await _unitOfWork.Repository<MaintenanceCategory>().Delete(MaintenanceCategory);
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
