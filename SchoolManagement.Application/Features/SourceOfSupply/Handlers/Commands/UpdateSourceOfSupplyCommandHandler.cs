using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.SourceOfSupply.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.SourceOfSupplys.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;

namespace SchoolManagement.Application.Features.SourceOfSupplys.Handlers.Commands
{
    public class UpdateSourceOfSupplyCommandHandler : IRequestHandler<UpdateSourceOfSupplyCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateSourceOfSupplyCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateSourceOfSupplyCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateSourceOfSupplyDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.SourceOfSupplyDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var SourceOfSupply = await _unitOfWork.Repository<SourceOfSupply>().Get(request.SourceOfSupplyDto.SourceOfSupplyId);

            if (SourceOfSupply is null)
                throw new NotFoundException(nameof(SourceOfSupply), request.SourceOfSupplyDto.SourceOfSupplyId);

            _mapper.Map(request.SourceOfSupplyDto, SourceOfSupply);

            await _unitOfWork.Repository<SourceOfSupply>().Update(SourceOfSupply);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
