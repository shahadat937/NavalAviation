using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Procurements.Requests.Queries
{
    public class GetSelectedPartNoFromProcurementForUpdateByDepartmentNameRequest : IRequest<List<SelectedModel>>
    {
        public int DepartmentNameId { get; set; }
        public int SparesCategoryId { get; set; }
    }
}   
   