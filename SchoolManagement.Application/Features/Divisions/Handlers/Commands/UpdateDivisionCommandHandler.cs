using AutoMapper;
using SchoolManagement.Application.DTOs.Division.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Divisions.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;

namespace SchoolManagement.Application.Features.Divisions.Handlers.Commands
{
    public class UpdateDivisionCommandHandler : IRequestHandler<UpdateDivisionCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateDivisionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateDivisionCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateDivisionDtoValidator();
            var validationResult = await validator.ValidateAsync(request.DivisionDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var Divisions = await _unitOfWork.Repository<Division>().Get(request.DivisionDto.DivisionId);

            if (Divisions is null)
                throw new NotFoundException(nameof(Division), request.DivisionDto.DivisionId);

            _mapper.Map(request.DivisionDto, Divisions);

            await _unitOfWork.Repository<Division>().Update(Divisions);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
