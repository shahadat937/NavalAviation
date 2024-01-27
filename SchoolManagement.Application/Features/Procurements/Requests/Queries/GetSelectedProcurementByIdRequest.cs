using MediatR;
using SchoolManagement.Application.DTOs.Procurement;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Procurements.Requests.Queries
{

    public class GetSelectedProcurementByIdRequest : IRequest<List<ProcurementDto>>
    {
        public int ProcurementId { get; set; }
    }
}   
   