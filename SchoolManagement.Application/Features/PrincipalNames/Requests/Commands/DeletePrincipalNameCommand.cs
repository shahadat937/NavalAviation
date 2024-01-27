using MediatR;

namespace SchoolManagement.Application.Features.PrincipalNames.Requests.Commands
{
    public class DeletePrincipalNameCommand : IRequest
    {
        public int PrincipalNameId { get; set; }
    }
}
