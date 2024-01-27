using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.FiscalYears.Requests.Queries
{
    public class GetSelectedFiscalYearRequest : IRequest<List<SelectedModel>>
    {
    }
} 
