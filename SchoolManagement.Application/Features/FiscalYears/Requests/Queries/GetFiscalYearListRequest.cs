using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.FiscalYears;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.FiscalYears.Requests.Queries
{
    public class GetFiscalYearListRequest : IRequest<PagedResult<FiscalYearDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
