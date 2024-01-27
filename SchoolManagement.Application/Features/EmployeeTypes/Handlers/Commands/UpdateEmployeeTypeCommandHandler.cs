using AutoMapper;
using SchoolManagement.Application.DTOs.EmployeeType.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.EmployeeTypes.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;

namespace SchoolManagement.Application.Features.EmployeeTypes.Handlers.Commands
{
    public class UpdateEmployeeTypeCommandHandler : IRequestHandler<UpdateEmployeeTypeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateEmployeeTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateEmployeeTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateEmployeeTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.EmployeeTypeDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var EmployeeTypes = await _unitOfWork.Repository<EmployeeType>().Get(request.EmployeeTypeDto.EmployeeTypeId);

            if (EmployeeTypes is null)
                throw new NotFoundException(nameof(EmployeeType), request.EmployeeTypeDto.EmployeeTypeId);

            _mapper.Map(request.EmployeeTypeDto, EmployeeTypes);

            await _unitOfWork.Repository<EmployeeType>().Update(EmployeeTypes);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
