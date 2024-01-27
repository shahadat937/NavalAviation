using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.FiscalYears.Requests.Commands;
using SchoolManagement.Application.DTOs.FiscalYears.Validators;

namespace SchoolManagement.Application.Features.FiscalYears.Handlers.Commands
{
    public class UpdateFiscalYearCommandHandler : IRequestHandler<UpdateFiscalYearCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateFiscalYearCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateFiscalYearCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateFiscalYearDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.FiscalYearDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var FiscalYear = await _unitOfWork.Repository<FiscalYear>().Get(request.FiscalYearDto.FiscalYearId);

            if (FiscalYear is null)
                throw new NotFoundException(nameof(FiscalYear), request.FiscalYearDto.FiscalYearId);

            _mapper.Map(request.FiscalYearDto, FiscalYear);

            await _unitOfWork.Repository<FiscalYear>().Update(FiscalYear);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
