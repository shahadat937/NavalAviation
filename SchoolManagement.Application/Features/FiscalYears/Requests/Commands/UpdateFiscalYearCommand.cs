using MediatR;
using SchoolManagement.Application.DTOs.FiscalYears;

namespace SchoolManagement.Application.Features.FiscalYears.Requests.Commands
{
    public class UpdateFiscalYearCommand : IRequest<Unit>
    { 
        public FiscalYearDto FiscalYearDto { get; set; }
    }
}
