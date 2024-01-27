using MediatR;

namespace SchoolManagement.Application.Features.AirCraftNames.Requests.Commands
{
    public class OperationalCommand : IRequest
    {
        public int AirCraftNameId { get; set; }  
    }
}
