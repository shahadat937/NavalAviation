using MediatR;
using SchoolManagement.Application.DTOs.MaintenanceCategory;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text; 

namespace SchoolManagement.Application.Features.EquipmentNames.Requests.Queries
{
    public class GetEquipmentNameBySparesCategoryIdRequest : IRequest<List<SelectedModel>>
    {
        public int SparesCategoryId { get; set; }
    }
} 
