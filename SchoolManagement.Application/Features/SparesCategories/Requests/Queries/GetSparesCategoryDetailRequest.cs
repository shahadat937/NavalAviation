using MediatR;
using SchoolManagement.Application.DTOs.SparesCategorys;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.SparesCategories.Requests.Queries
{
    public class GetSparesCategoryDetailRequest : IRequest<SparesCategoryDto>
    {
        public int SparesCategoryId { get; set; }
    }
}
