using MediatR;
using SchoolManagement.Application.DTOs.RoleFeature;

namespace SchoolManagement.Application.Features.RoleFeatures.Requests.Queries
{
    public class GetRoleFeatureDetailRequest : IRequest<RoleFeatureDto>
    {
        public string RoleId { get; set; }
        public int FeatureId { get; set; }
    }
}
