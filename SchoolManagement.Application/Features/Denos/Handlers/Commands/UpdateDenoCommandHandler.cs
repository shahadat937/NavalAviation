using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Denos.Validators;
using SchoolManagement.Application.Features.Denos.Requests.Commands;

namespace SchoolManagement.Application.Features.Denos.Handlers.Commands
{
    public class UpdateDenoCommandHandler : IRequestHandler<UpdateDenoCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateDenoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateDenoCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateDenoDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.DenoDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var Deno = await _unitOfWork.Repository<Deno>().Get(request.DenoDto.DenoId);

            if (Deno is null)
                throw new NotFoundException(nameof(Deno), request.DenoDto.DenoId);

            _mapper.Map(request.DenoDto, Deno);

            await _unitOfWork.Repository<Deno>().Update(Deno);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
