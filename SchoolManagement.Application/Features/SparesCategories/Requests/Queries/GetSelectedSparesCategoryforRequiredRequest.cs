using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.SparesCategories.Requests.Queries
{
    public class GetSelectedSparesCategoryforRequiredRequest : IRequest<List<SelectedModel>>
    {
    }
} 
