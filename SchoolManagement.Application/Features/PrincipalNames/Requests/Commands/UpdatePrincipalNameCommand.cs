using MediatR;
using SchoolManagement.Application.DTOs.PrincipalName;

namespace SchoolManagement.Application.Features.PrincipalNames.Requests.Commands
{
    public class UpdatePrincipalNameCommand : IRequest<Unit>
    {
        public PrincipalNameDto PrincipalNameDto { get; set; }
    }
}
