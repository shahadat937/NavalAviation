using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.MaintenanceSubCategorys.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.MaintenanceSubCategorys.Handlers.Commands
{
    public class DeleteMaintenanceSubCategoryCommandHandler : IRequestHandler<DeleteMaintenanceSubCategoryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteMaintenanceSubCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteMaintenanceSubCategoryCommand request, CancellationToken cancellationToken)
        {
            var MaintenanceSubCategory = await _unitOfWork.Repository<MaintenanceSubCategory>().Get(request.MaintenanceSubCategoryId);

            if (MaintenanceSubCategory == null)
                throw new NotFoundException(nameof(MaintenanceSubCategory), request.MaintenanceSubCategoryId);

            await _unitOfWork.Repository<MaintenanceSubCategory>().Delete(MaintenanceSubCategory);
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
