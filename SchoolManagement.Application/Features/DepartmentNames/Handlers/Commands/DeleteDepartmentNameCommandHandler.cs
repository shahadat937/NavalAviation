using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.DepartmentNames.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.DepartmentNames.Handlers.Commands
{
    public class DeleteDepartmentNameCommandHandler : IRequestHandler<DeleteDepartmentNameCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteDepartmentNameCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteDepartmentNameCommand request, CancellationToken cancellationToken)
        {
            var DepartmentName = await _unitOfWork.Repository<DepartmentName>().Get(request.DepartmentNameId);

            if (DepartmentName == null)
                throw new NotFoundException(nameof(DepartmentName), request.DepartmentNameId);

            await _unitOfWork.Repository<DepartmentName>().Delete(DepartmentName);
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
