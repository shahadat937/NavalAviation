using MediatR;
using SchoolManagement.Application.DTOs.ItemCategorys;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ItemCategories.Requests.Queries
{
    public class GetItemCategoryDetailRequest : IRequest<ItemCategoryDto>
    {
        public int ItemCategoryId { get; set; }
    }
}
