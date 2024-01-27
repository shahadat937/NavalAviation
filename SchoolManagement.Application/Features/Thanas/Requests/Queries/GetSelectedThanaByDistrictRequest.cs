using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.Thanas.Requests.Queries
{
    public class GetSelectedThanaByDistrictRequest : IRequest<List<SelectedModel>>
    {
        public int DistrictId { get; set; } 
    }
}
