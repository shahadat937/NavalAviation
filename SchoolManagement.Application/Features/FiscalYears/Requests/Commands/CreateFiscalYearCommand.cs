using MediatR;
using SchoolManagement.Application.DTOs.FiscalYears;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.FiscalYears.Requests.Commands
{
    public class CreateFiscalYearCommand : IRequest<BaseCommandResponse>
    {
        public CreateFiscalYearDto FiscalYearDto { get; set; }
    }
}
