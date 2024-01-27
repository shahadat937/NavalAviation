using MediatR;

namespace SchoolManagement.Application.Features.DegitalArchieves.Requests.Commands
{
    public class DeleteDegitalArchieveCommand : IRequest
    {
        public int DegitalArchieveId { get; set; }
    }
}
