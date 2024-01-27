using MediatR;
using SchoolManagement.Application.DTOs.ShelfLifeCategory;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.ShelfLifeCategorys.Requests.Commands
{
    public class CreateShelfLifeCategoryCommand : IRequest<BaseCommandResponse>
    {
        public CreateShelfLifeCategoryDto ShelfLifeCategoryDto { get; set; }
    }
}
