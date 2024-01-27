using MediatR;
using SchoolManagement.Application.DTOs.ShelfLifeCategory;

namespace SchoolManagement.Application.Features.ShelfLifeCategorys.Requests.Commands
{
    public class UpdateShelfLifeCategoryCommand : IRequest<Unit>
    {
        public ShelfLifeCategoryDto ShelfLifeCategoryDto { get; set; }
    }
}
