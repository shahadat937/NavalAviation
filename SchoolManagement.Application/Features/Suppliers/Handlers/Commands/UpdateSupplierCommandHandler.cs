using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Suppliers.Validators;
using SchoolManagement.Application.Features.Suppliers.Requests.Commands;

namespace SchoolManagement.Application.Features.Suppliers.Handlers.Commands
{
    public class UpdateSupplierCommandHandler : IRequestHandler<UpdateSupplierCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateSupplierCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateSupplierDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.SupplierDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var Supplier = await _unitOfWork.Repository<Supplier>().Get(request.SupplierDto.SupplierId);

            if (Supplier is null)
                throw new NotFoundException(nameof(Supplier), request.SupplierDto.SupplierId);

            _mapper.Map(request.SupplierDto, Supplier);

            await _unitOfWork.Repository<Supplier>().Update(Supplier);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
