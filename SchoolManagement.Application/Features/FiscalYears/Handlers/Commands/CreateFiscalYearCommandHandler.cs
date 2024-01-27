using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.FiscalYears.Validators;
using SchoolManagement.Application.Features.FiscalYears.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.FiscalYears.Handlers.Commands
{
    public class CreateFiscalYearCommandHandler : IRequestHandler<CreateFiscalYearCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateFiscalYearCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateFiscalYearCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateFiscalYearDtoValidator();
            var validationResult = await validator.ValidateAsync(request.FiscalYearDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var FiscalYear = _mapper.Map<FiscalYear>(request.FiscalYearDto);

                FiscalYear = await _unitOfWork.Repository<FiscalYear>().Add(FiscalYear);

                try
                {
                    await _unitOfWork.Save();
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex);
                }


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = FiscalYear.FiscalYearId;
            }

            return response;
        }
    }
}
