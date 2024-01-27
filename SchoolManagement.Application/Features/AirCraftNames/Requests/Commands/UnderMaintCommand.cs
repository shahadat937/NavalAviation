using MediatR;

namespace SchoolManagement.Application.Features.AirCraftNames.Requests.Commands
{
    public class UnderMaintCommand : IRequest
    {
        public int AcStatusId { get; set; }  
    }
}
