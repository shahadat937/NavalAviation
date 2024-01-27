using MediatR;
using SchoolManagement.Application.DTOs.CodeValues;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text; 

namespace SchoolManagement.Application.Features.MaintenancePlannings.Requests.Queries
{
    public class GetAllowedNestInspDateByMaintenancePlanningIdRequest : IRequest<List<SelectedModel>>
    {
        public int MaintenancePlanningId { get; set; }    
    }
} 
