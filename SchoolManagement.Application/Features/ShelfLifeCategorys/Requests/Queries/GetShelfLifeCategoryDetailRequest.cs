using MediatR;
using SchoolManagement.Application.DTOs.ShelfLifeCategory;

namespace SchoolManagement.Application.Features.ShelfLifeCategorys.Requests.Queries
{
    public class GetShelfLifeCategoryDetailRequest : IRequest<ShelfLifeCategoryDto>
    {
        public int ShelfLifeCategoryId { get; set; }
    }
}
