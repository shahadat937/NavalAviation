using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.TestEquipmentDetails.Requests.Queries
{
    public class GetSelectedTestEquipmentDetailRequest : IRequest<List<SelectedModel>>
    {
    }
}
