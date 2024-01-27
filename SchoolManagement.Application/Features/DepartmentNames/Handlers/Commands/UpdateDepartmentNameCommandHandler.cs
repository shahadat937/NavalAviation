using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.DepartmentName.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.DepartmentNames.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;

namespace SchoolManagement.Application.Features.DepartmentNames.Handlers.Commands
{
    public class UpdateDepartmentNameCommandHandler : IRequestHandler<UpdateDepartmentNameCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateDepartmentNameCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateDepartmentNameCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateDepartmentNameDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.DepartmentNameDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var DepartmentName = await _unitOfWork.Repository<DepartmentName>().Get(request.DepartmentNameDto.DepartmentNameId);

            if (DepartmentName is null)
                throw new NotFoundException(nameof(DepartmentName), request.DepartmentNameDto.DepartmentNameId);

            _mapper.Map(request.DepartmentNameDto, DepartmentName);

            await _unitOfWork.Repository<DepartmentName>().Update(DepartmentName);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
