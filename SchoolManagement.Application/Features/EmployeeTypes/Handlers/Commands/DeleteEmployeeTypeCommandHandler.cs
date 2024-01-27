using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.EmployeeTypes.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;

namespace SchoolManagement.Application.Features.EmployeeTypes.Handlers.Commands
{
    public class DeleteEmployeeTypeCommandHandler : IRequestHandler<DeleteEmployeeTypeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteEmployeeTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteEmployeeTypeCommand request, CancellationToken cancellationToken)
        {
            var EmployeeTypes = await _unitOfWork.Repository<EmployeeType>().Get(request.EmployeeTypeId);

            if (EmployeeTypes == null)
                throw new NotFoundException(nameof(EmployeeType), request.EmployeeTypeId);

            await _unitOfWork.Repository<EmployeeType>().Delete(EmployeeTypes);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
