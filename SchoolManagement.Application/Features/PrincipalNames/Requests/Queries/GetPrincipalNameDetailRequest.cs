using MediatR;
using SchoolManagement.Application.DTOs.PrincipalName;

namespace SchoolManagement.Application.Features.PrincipalNames.Requests.Queries
{
    public class GetPrincipalNameDetailRequest : IRequest<PrincipalNameDto>
    {
        public int PrincipalNameId { get; set; }
    }
}
