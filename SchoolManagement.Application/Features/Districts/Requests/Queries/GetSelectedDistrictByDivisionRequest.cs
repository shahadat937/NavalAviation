using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.Districts.Requests.Queries
{
    public class GetSelectedDistrictByDivisionRequest : IRequest<List<SelectedModel>>
    {
        public int DivisionId { get; set; } 
    }
}
