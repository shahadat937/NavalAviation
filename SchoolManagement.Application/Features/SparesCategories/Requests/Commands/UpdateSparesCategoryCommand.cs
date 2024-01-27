using MediatR;
using SchoolManagement.Application.DTOs.SparesCategorys;

namespace SchoolManagement.Application.Features.SparesCategories.Requests.Commands
{
    public class UpdateSparesCategoryCommand : IRequest<Unit> 
    { 
        public SparesCategoryDto SparesCategoryDto { get; set; }
    }
}
 