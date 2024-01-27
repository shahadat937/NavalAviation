using MediatR;
using SchoolManagement.Application.DTOs.FiscalYears;

namespace SchoolManagement.Application.Features.FiscalYears.Requests.Queries
{
    public class GetFiscalYearDetailRequest : IRequest<FiscalYearDto>
    {
        public int FiscalYearId { get; set; }
    }
}
