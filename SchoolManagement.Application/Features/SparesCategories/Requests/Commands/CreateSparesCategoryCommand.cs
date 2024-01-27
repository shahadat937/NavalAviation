using MediatR;
using SchoolManagement.Application.DTOs.SparesCategorys; 
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.SparesCategories.Requests.Commands
{
    public class CreateSparesCategoryCommand : IRequest<BaseCommandResponse>
    {
        public CreateSparesCategoryDto SparesCategoryDto { get; set; }
    }
} 
