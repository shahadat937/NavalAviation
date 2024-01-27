using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Acceptances.Requests.Queries
{
    public class GetSelectedPartNoFromAcceptanceByDepartmentNameRequest : IRequest<List<SelectedModel>>
    {
        public int DepartmentNameId { get; set; } 
        public int SparesCategoryId { get; set; } 
    }
}   
   