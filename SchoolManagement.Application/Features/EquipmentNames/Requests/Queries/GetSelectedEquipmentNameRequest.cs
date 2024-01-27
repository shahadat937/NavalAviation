using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.EquipmentNames.Requests.Queries
{
    public class GetSelectedEquipmentNameRequest : IRequest<List<SelectedModel>>
    {
    }
} 
