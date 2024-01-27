using MediatR;

namespace SchoolManagement.Application.Features.RoleFeatures.Requests.Commands
{
    public class DeleteRoleFeatureCommand : IRequest
    {
        public string RoleId { get; set; }
        public int FeatureId { get; set; }
    }
}
