using MediatR;

namespace SchoolManagement.Application.Features.SparesCategories.Requests.Commands
{
    public class DeleteSparesCategoryCommand : IRequest
    {
        public int SparesCategoryId { get; set; }
    }
} 
