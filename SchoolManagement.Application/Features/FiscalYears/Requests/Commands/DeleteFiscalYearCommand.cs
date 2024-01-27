using MediatR;

namespace SchoolManagement.Application.Features.FiscalYears.Requests.Commands
{
    public class DeleteFiscalYearCommand : IRequest
    {
        public int FiscalYearId { get; set; }
    }
} 
