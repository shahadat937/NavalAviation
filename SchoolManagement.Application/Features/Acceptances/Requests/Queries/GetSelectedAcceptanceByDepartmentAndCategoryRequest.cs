using MediatR;
using SchoolManagement.Application.DTOs.Acceptances;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Acceptances.Requests.Queries
{

    public class GetSelectedAcceptanceByDepartmentAndCategoryRequest : IRequest<List<AcceptanceDto>>
    {
        public int AcceptanceId { get; set; }
    }
}   
   