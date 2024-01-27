using MediatR;
using SchoolManagement.Application.DTOs.AirCraftName;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text; 

namespace SchoolManagement.Application.Features.AirCraftNames.Requests.Queries
{
    public class GetAirCraftNameByDepartmentNameIdRequest : IRequest<List<SelectedModel>>
    {
        public int DepartmentNameId { get; set; }    
    }
} 
