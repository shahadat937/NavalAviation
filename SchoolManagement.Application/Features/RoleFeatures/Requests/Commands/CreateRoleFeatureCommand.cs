using MediatR;
using SchoolManagement.Application.DTOs.RoleFeature;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.RoleFeatures.Requests.Commands
{
    public class CreateRoleFeatureCommand : IRequest<BaseCommandResponse>
    {
        public CreateRoleFeatureDto RoleFeatureDto { get; set; } 

    }
}
